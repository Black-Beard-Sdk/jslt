using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bb.ConvertToDatables
{

    internal class DatasetBuilder
    {


        internal static void Build(StructureSchema _schema)
        {

            foreach (var strTable in _schema.Tables)
            {
                strTable.Schema = _schema;
                BuildTable(_schema.DataSet, strTable);
            }

        }

        private static void BuildTable(DataSet dataset, StructureTable strTable)
        {

            DataTable table = dataset.Tables[strTable.Name];

            if (table == null)
            {

                strTable.DataTable = table = new DataTable()
                {
                    TableName = strTable.Name.ToLower().Trim(),
                };

                BuildColumns(table, strTable);
                BuildPrimaryKey(table, strTable);
                dataset.Tables.Add(table);

                strTable.Schema.ReferenceObject(table.TableName, strTable);
            
            }

        }

        private static void BuildPrimaryKey(DataTable table, StructureTable strTable)
        {
            
            if (strTable.PrimaryKey.Count == 0)
            {

                var key = new DataColumn("technicalkey", typeof(Guid));
                table.Columns.Add(key);
                table.PrimaryKey = new DataColumn[] { key };
                
                var s = new StructureColumn()
                {
                    Name = key.ColumnName,
                    DbType = DbType.Guid,
                    Caption = "Auto generated because target structure haven't primary key",
                    IsUnique = true,
                    Nullable = false,
                    Schema = strTable.Schema,
                    DataColumn = key,
                    Initialize = () => Guid.NewGuid(),
                    IsPrimary = true,
                };

                strTable.Schema.ReferenceObject(table.TableName + "." + key.ColumnName, s);
                strTable.Columns.Add(s);

            }

            if (strTable.PrimaryKey.Count > 0)
            {

                List<DataColumn> primaryKey = new List<DataColumn>();

                foreach (var item in strTable.PrimaryKey)
                    primaryKey.Add(table.Columns[item.Name]);

                table.PrimaryKey = primaryKey.ToArray();

            }

        }

        private static void BuildColumns(DataTable table, StructureTable strTable)
        {

            foreach (var strColumn in strTable.Columns)
            {
                strColumn.Schema = strTable.Schema;
                BuildColumn(table, strColumn);
            }

            foreach (var strColumn in strTable.Columns.Where(c => c.Ordinal > 0).OrderBy(c => c.Ordinal))
                table.Columns[strColumn.Name].SetOrdinal(strColumn.Ordinal);

        }

        private static void BuildColumn(DataTable table, StructureColumn strColumn)
        {

            DataColumn column = table.Columns[strColumn.Name.ToLower().Trim()];

            if (column == null)
            {
                table.Columns.Add(column = new DataColumn(strColumn.Name.ToLower().Trim(), strColumn.GetColumnType()));
                strColumn.Schema.ReferenceObject(table.TableName + "." + column.ColumnName, strColumn);
            }
            else
            {

            }

            strColumn.DataColumn = column;

            if (strColumn.DefaultValue != null)
            {
                
                if (strColumn.DefaultValue is JValue v)
                    column.DefaultValue = v.Value;
                
                else
                {
                    //column.AutoIncrement = true;
                    //column.AutoIncrementSeed = 0;
                    //column.AutoIncrementStep = 0;
                }

            }

            column.AllowDBNull = strColumn.Nullable;
            column.Unique = strColumn.IsUnique;

            if (!string.IsNullOrEmpty(strColumn.Caption))
                column.Caption = strColumn.Caption;

            if (column.DataType == typeof(string) && strColumn.MaxLength > 0)
                column.MaxLength = strColumn.MaxLength;

            else if (column.DataType == typeof(DateTime) || column.DataType == typeof(DateTimeOffset))
                column.DateTimeMode = strColumn.DateTimeMode;

        }

    }
}