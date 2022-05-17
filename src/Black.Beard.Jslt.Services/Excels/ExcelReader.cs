using ExcelDataReader;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Jslt.Services.Excels
{

    /*
{ "FirstRowHasColumnName" : true, "HeaderLine" : 4, "Tablename": "Table1", "AddRowNumber": true, "ByPassEmptyObject": true }
     */


    public class ExcelReader
    {

        public ExcelReader()
        {
            Columns = new List<Column>();
        }

        public bool FirstRowHasColumnName { get; set; }

        public int HeaderLine { get; set; }

        public string Tablename { get; set; }

        public bool AddRowNumber { get; set; } = true;

        public bool ByPassEmptyObject { get; set; } = true;

        public List<Column> Columns { get; set; }


        public JArray Read(FileInfo file, out string resultText, out int resultCode)
        {

            List<JToken> tokens = new List<JToken>((int)(file.Length / 100));

            if (this._dicColumns == null && this.Columns.Count > 0)
            {
                _dicColumns = new Dictionary<int, Column>();
                foreach (var item in this.Columns)
                    _dicColumns.Add(item.Index, item);
            }

            using (var stream = file.Open(FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {

                var conf = GetConfiguration();

                var dataSet = reader.AsDataSet(conf);
                if (!dataSet.Tables.Contains(Tablename))
                {
                    resultText = $"missing table {Tablename}";
                    resultCode = 2;
                    return null;
                }
                else if (string.IsNullOrEmpty(Tablename))
                {
                    if (dataSet.Tables.Count == 1)
                        Tablename = dataSet.Tables[0].TableName;

                    else
                    {
                        resultText = $"table name not specified and the document has more of one sheet";
                        resultCode = 3;
                        return null;
                    }
                }


                var table = dataSet.Tables[Tablename];

                if (this._dicColumns == null)
                    try
                    {
                        ResolveColumns(table);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                int rowLine = 0;

                foreach (DataRow row in table.Rows)
                {
           
                    if (HeaderLine == 0 || rowLine > HeaderLine)
                    {

                        var items = row.ItemArray;
                        var obj = new JObject();
                        for (int i = 0; i < items.Length; i++)
                        {

                            var column = Columns[i];
                            var value = GetValue(items[i], column);

                            if (value != null && value != DBNull.Value)
                                obj.Add(new JProperty(column.Name, value));

                        }

                        if (obj.Properties().Count() > 0 || !ByPassEmptyObject)
                            tokens.Add(obj);

                        if (AddRowNumber)
                            obj.Add(new JProperty("$row", rowLine));

                    }

                    rowLine++;

                }

            }

            resultText = null;
            resultCode = 0;
            return new JArray(tokens);
            

        }

        private object GetValue(object value, Column column)
        {

            if (column.Type == typeof(string))
            {

                if (value is string txt)
                {
                    if (column.Trimmed)
                        txt = txt.Trim();
                }
                else
                    txt = value.ToString();

                if (column.BypassEmptyValue && string.IsNullOrEmpty(txt))
                    return DBNull.Value;

                value = txt;

            }
            else if (value.GetType() == column.Type)
                return value;
            
            else
            {
                try
                {
                    return Convert.ChangeType(value, column.Type);
                }
                catch (Exception)
                {

                }
            }

            return value;

        }

        private void ResolveColumns(DataTable table)
        {

            this._dicColumns = new Dictionary<int, Column>();
            foreach (var item in this.Columns)
                _dicColumns.Add(item.Index, item);

            if (_dicColumns.Count > 0)
                return;

            HashSet<string> _h = new HashSet<string>(table.Columns.Count);

            if (HeaderLine > 0)
            {
                var row = table.Rows[HeaderLine];
                var columns = row.ItemArray;

                for (int i = 0; i < columns.Length; i++)
                {

                    object Name = columns[i];

                    if (Name is string txt)
                    {
                        txt = txt.Trim(' ', '\t', '\r', '\n');
                        if (!string.IsNullOrEmpty(txt))
                            Name = GetLabel(txt);

                        else
                            Name = "renamed_" + _dicColumns.Count.ToString();
                    }
                    else if (Name != null && Name != DBNull.Value)
                        Name = "renamed_" + _dicColumns.Count.ToString();


                    var column = table.Columns[i];
                    var type = column.DataType;

                    _dicColumns.Add(i, new Column { Index = i, Name = Name.ToString(), Type = type });

                }

            }
            else
            {

                foreach (DataColumn column in table.Columns)
                {

                    int index = column.Ordinal;

                    var name = GetLabel(column.ColumnName);
                    if (!_h.Add(name))
                        name += "_renamed_" + index.ToString();

                    var type = column.DataType;

                    if (type == typeof(double))
                    {
                        bool t = true;
                        foreach (DataRow item in table.Rows)
                        {
                            var obj = item[column];
                            if (!Int64.TryParse(obj.ToString(), out Int64 pp))
                            {
                                t = false;
                                break;
                            }

                        }
                        if (t)
                            type = typeof(Int64);
                    }

                    _dicColumns.Add(index, new Column { Index = index, Name = name.ToString(), Type = type });

                }

            }

            Columns.Clear();

            Columns.AddRange(this._dicColumns.Values);

        }

        private ExcelDataSetConfiguration GetConfiguration()
        {
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = FirstRowHasColumnName,


                    FilterColumn = (s, b) =>
                    {

                        if (_dicColumns == null)
                            return true;

                        return _dicColumns.ContainsKey(b);

                    },

                },
                FilterSheet = (s, b) =>
                {
                    return s.Name == Tablename;
                }
            };

            return conf;

        }

        private static string GetLabel(string n)
        {

            var sb = new StringBuilder(n.Length);

            foreach (var c in n)
            {
                var p = (int)c;

                //if (p == 65279) // Bom // { } 
                if (_accepted.TryGetValue(c, out char v))
                    sb.Append(v);

            }

            return sb.ToString()
                 .Replace("___", "_")
                 .Replace("__", "_");

        }

        #region build

        private static Dictionary<char, char> build()
        {

            var dic = new Dictionary<char, char>();

            Add(dic, (int)'a', (int)'z');
            Add(dic, (int)'A', (int)'Z');
            Add(dic, (int)'0', (int)'9');

            dic.Add(' ', '_');
            dic.Add('\'', '_');
            dic.Add('"', '_');
            dic.Add('é', 'e');
            dic.Add('è', 'e');
            dic.Add('ë', 'e');
            dic.Add('î', 'i');
            dic.Add('ï', 'i');
            dic.Add('Ï', 'I');
            dic.Add('Ö', 'O');
            dic.Add('Ü', 'U');
            dic.Add('ô', 'o');
            dic.Add('à', 'a');
            dic.Add('ê', 'e');
            dic.Add('ñ', 'n');
            dic.Add('Ñ', 'N');
            dic.Add('¡', 'i');
            dic.Add('á', 'a');
            dic.Add('í', 'i');
            dic.Add('ó', 'o');
            dic.Add('ú', 'u');
            dic.Add('Á', 'A');
            dic.Add('É', 'E');
            dic.Add('Í', 'I');
            dic.Add('Ó', 'O');
            dic.Add('Ú', 'U');
            dic.Add('ä', 'a');
            dic.Add('ö', 'o');
            dic.Add('Ä', 'A');
            dic.Add('Ë', 'E');

            return dic;

        }

        private static void Add(Dictionary<char, char> dic, int s, int e)
        {
            for (int i = s; i <= e; i++)
                dic.Add((char)i, (char)i);
        }

        private static Dictionary<char, char> _accepted = build();

        #endregion build

        private Dictionary<int, Column> _dicColumns;
    }


}
