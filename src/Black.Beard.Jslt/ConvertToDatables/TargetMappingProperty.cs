using System.Data;

namespace Bb.ConvertToDatables
{
    internal class TargetMappingProperty
    {

        public TargetMappingProperty(StructureColumn column)
        {

            this.Column = column;
            this.Schema = column.Schema;
            this.DataColumn = column.DataColumn;
            this.ColumnName = column.DataColumn.ColumnName;
            this.DataTable = column.DataColumn.Table;
            this.TableName = this.DataTable.TableName;
        }

        public StructureColumn Column { get; }

        public DataColumn DataColumn { get; }
        public DataTable DataTable { get; }
        public string TableName { get; }
        public string ColumnName { get; }
        public StructureSchema Schema { get; }


    }

}
