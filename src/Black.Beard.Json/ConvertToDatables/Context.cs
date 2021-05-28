using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bb.ConvertToDatables
{

    public class Context : IDisposable
    {

        internal Context(StructureSchema schema)
        {
            this._newRows = new Dictionary<DataTable, DataRow>();
            this._schema = schema;
            this._countLines = 0;
        }

        /// <summary>
        /// Initialize new lines
        /// </summary>
        /// <param name="table"></param>
        /// <param name="parentKeys"></param>
        internal void NewLine(StructureTable table, List<(StructureColumn, StructureColumn)> parentKeys)
        {

            DataRow rowTarget = table.GetNewRow();

            foreach (var item in parentKeys)
            {
                var r1 = this._newRows[item.Item1.DataColumn.Table];
                rowTarget[item.Item2.DataColumn] = r1[item.Item1.DataColumn];
            }

            _newRows.Add(table.DataTable, rowTarget);

        }

        /// <summary>
        /// close current opened lines. return true if the count of lines is greater than BulkCount
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        internal bool Close(StructureTable table)
        {
            var key = table.DataTable;
            table.DataTable.Rows.Add(_newRows[key]);
            _newRows.Remove(key);

            return _flush != null
                && key.Rows.Count >= this.BulkCount;
        }

        internal void Close()
        {
            var l = _newRows.Keys.ToList();
            foreach (var table in l)
                table.Rows.Add(_newRows[table]);

            _newRows.Clear();

        }

        internal void AppendProperty(SourceMappingProperty item, object value)
        {

            foreach (var item2 in item.TargetColumns)
            {
                var r = this._newRows[item2.DataTable];
                r[item2.Column.DataColumn] = value;
            }

        }

        internal bool IsRootLevel { get => this._countLines == 1; }

        internal void Increment()
        {
            this._countLines++;
        }

        internal void Decrement()
        {
            this._countLines--;
        }

        internal void Flush()
        {
            if (_flush != null)
                foreach (StructureTable table in this._dependencies)
                {

                    var t = table.DataTable;

                    if (this._flush(this, t))
                        t.Clear();

                    else
                        break;

                }

        }

        internal Context SetBulkCount(int bulkCount)
        {
            BulkCount = bulkCount;
            return this;
        }

        internal Context SetFlush(Func<Context, DataTable, bool> flush)
        {
            _flush = flush;
            return this;
        }

        internal Context SetDependencies(List<StructureTable> dependencies)
        {
            _dependencies = dependencies;
            return this;
        }

        private Dictionary<DataTable, DataRow> _newRows;

        private DataSet _dataset { get; }

        public int BulkCount { get; private set; }
        public Exception Exception { get; set; }

        private Func<Context, DataTable, bool> _flush;

        private StructureSchema _schema;
        private int _countLines;
        
        private bool disposedValue;
        private List<StructureTable> _dependencies;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Flush();
                    Close();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~Context()
        // {
        //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}