using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.ConvertToDatables
{

    /// <summary>
    /// Class to write data to a csv file
    /// </summary>
    public sealed class CsvWriter : IDisposable
    {

        public CsvWriter(string fileTarget)
            : this(new FileInfo(fileTarget))
        {

        }

        public CsvWriter(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
            if (fileInfo.Exists)
                throw new Exception($"{fileInfo.FullName} already exists");

        }

        #region Properties

        /// <summary>
        /// Gets or sets whether carriage returns and line feeds should be removed from 
        /// field values, the default is true 
        /// </summary>

        public string FieldSeparator { get; set; } = ";";

        public string QuoteField { get; set; } = @"""";

        public bool WriteQuote { get; set; } = true;

        public bool WriteHeader { get; set; } = true;

        public string NewLine { get; set; } = Environment.NewLine;

        public Encoding Encoding { get; set; } = Encoding.UTF8;


        #endregion Properties

        #region Methods


        #region DataTable write methods

        /// <summary>
        /// Writes a DataTable to a file
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="filePath">File path</param>
        /// <param name="encoding">Encoding</param>
        public void Open()
        {

            this._writer = new StreamWriter(this.fileInfo.FullName, false, this.Encoding);

        }

        /// <summary>
        /// Writes the Csv File
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="writer">TextWriter</param>
        public void WriteToStream(DataTable dataTable)
        {

            this._quote = this.QuoteField[0];
            this._separator = FieldSeparator[0];

            List<string> fields = new List<string>();

            if (WriteHeader)
                WriteRecord((from DataColumn column in dataTable.Columns select column.ColumnName).ToList());

            foreach (DataRow row in dataTable.Rows)
            {
                fields.Clear();
                fields.AddRange(row.ItemArray.Select(o => o.ToString()));
                WriteRecord(fields);
            }

        }

        /// <summary>
        /// Writes the record to the underlying stream
        /// </summary>
        /// <param name="fields">Fields</param>
        /// <param name="writer">TextWriter</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void WriteRecord(IList<string> fields)
        {

            bool Notfirst = false;

            for (int i = 0; i < fields.Count; i++)
            {

                if (Notfirst)
                    this._writer.Write(this.FieldSeparator);
                else
                    Notfirst = true;

                var fieldValue = fields[i];

                if (fieldValue != null)
                {

                    if (this.WriteQuote)
                    {
                        fieldValue = fieldValue.Trim(this.QuoteField[0]);
                        this._writer.Write(_quote);
                    }
                    char old = '\0';

                    for (int charIndex = 0; charIndex < fieldValue.Length; charIndex++)
                    {
                        var c = fieldValue[charIndex];
                        Write(old, c);
                        old = c;
                    }

                    if (WriteQuote)
                        this._writer.Write(_quote);
                }

            }

            this._writer.Write(this.NewLine);

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Write(char old, char c)
        {

            if (WriteQuote)
            {
                if (c == _quote && old != '\\')
                    this._writer.Write('\\');
            }
            else
            {
                if (c == this._separator && old != '\\')
                    this._writer.Write('\\');
            }

            this._writer.Write(c);

        }

        #endregion DataTable write methods

        /// <summary>
        /// Disposes of all unmanaged resources
        /// </summary>
        public void Dispose()
        {

            if (_writer != null)
                Close();

        }

        public void Close()
        {

            if (_writer != null)
            {
                this._writer.Flush();
                this._writer.Close();
                this._writer.Dispose();

                _writer = null;

            }
        }

        #endregion Methods

        private FileInfo fileInfo;
        private StreamWriter _writer;
        private char _quote;
        private char _separator;
    }

}
