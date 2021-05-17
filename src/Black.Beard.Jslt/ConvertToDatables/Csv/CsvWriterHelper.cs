using System.Data;
using System.IO;
using System.Text;

namespace Bb.ConvertToDatables
{
    public static class CsvWriterHelper
    {


        public static void WriteToCsv(this DataSet self
                                    , DirectoryInfo target
                                    , string rootName
                                    , Encoding encoding
                                    , bool writeHeader = true
                                    , char fieldSeparator = ';'
                                    , char quoteField = '\0'
                                )
        {

            if (!target.Exists)
                target.Create();

            foreach (DataTable table in self.Tables)
            {
                var file = new FileInfo(Path.Combine(target.FullName, rootName.Trim('_') + "_" + table.TableName + ".csv"));
                table.WriteToCsv(file, encoding, writeHeader, fieldSeparator, quoteField);
            }

        }

        public static void WriteToCsv(this DataTable self
            , FileInfo file
            , Encoding encoding
            , bool writeHeader = true
            , char fieldSeparator = ';'
            , char quoteField = '\0'
            )
        {

            if (file.Exists)
                file.Delete();

            file.Refresh();

            using (var writer = new CsvWriter(file)
            {
                Encoding = encoding,
                FieldSeparator = fieldSeparator.ToString(),
                QuoteField = quoteField.ToString(),
                WriteQuote = quoteField != '\0',
                WriteHeader = writeHeader,
            })
            {
                writer.Open();
                writer.WriteToStream(self);
            }
        }
    }

}
