using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Bb.ConvertToDatables
{

    [DebuggerDisplay("{Name}")]
    public class StructureTable
    {

        public string Name { get; set; }

        public List<StructureColumn> Columns { get; set; } = new List<StructureColumn>();

        public List<StructureColumn> InitializingColumns { get => _initializingColumns ?? (_initializingColumns = Columns.Where(c => c.Initialize != null).ToList()); }

        public List<StructureColumn> PrimaryKey
        {
            get
            {
                return this.Columns
                        .Where(c => c.IsPrimary)
                        .OrderBy(c => c.Ordinal)
                        .ToList();
            }
        }

        public StructureSchema Schema { get; internal set; }

        internal DataRow GetNewRow()
        {

            var rowTarget = DataTable.NewRow();

            foreach (StructureColumn column in InitializingColumns)
            {
                var o = column.Initialize();
                rowTarget[column.DataColumn] = o;
            }

            return rowTarget;

        }

        public DataTable DataTable { get; internal set; }

        internal StructureColumn GenerateRelationFrom(StructureColumn column)
        {

            var col = column.DataColumn;
            string name = col.Table.TableName + "_" + col.ColumnName;

            string caption = $"ForeignKeyConstraint key to {col.Table.TableName}.{col.ColumnName}";

            var r = new StructureColumn()
            {

                Caption = caption,
                DateTimeMode = column.DateTimeMode,
                DbType = column.DbType,
                DefaultValue = column.DefaultValue,
                IsPrimary = false,
                MaxLength = column.MaxLength,
                IsUnique = false,
                Nullable = false,
                Schema = column.Schema,
                Name = name,

                DataColumn = new DataColumn(name, col.DataType)
                {
                    AllowDBNull = false,
                    Caption = caption,
                    DateTimeMode = col.DateTimeMode,
                    MaxLength = col.MaxLength,
                    Unique = false,
                }
            };

            this.DataTable.Columns.Add(r.DataColumn);
            Columns.Add(r);

            return r;

        }

        List<StructureColumn> _initializingColumns;


    }


}
