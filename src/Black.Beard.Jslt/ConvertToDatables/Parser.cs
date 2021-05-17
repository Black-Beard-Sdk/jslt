using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bb.ConvertToDatables
{
    public class Parser
    {


        public Parser(Parser parent, StructureSchema schema)
        {
            this._parent = parent;
            this._properties = new List<SourceMappingProperty>();
            this._sub = new List<Parser>();
            this._newLines = new List<StructureTable>();
            this._dependencies = new List<StructureTable>();
            this._parentKeys = new List<(StructureColumn, StructureColumn)>();
            this.Schema = schema;
        }

        /// <summary>
        /// Clone in the table child, the relation key from parent.
        /// </summary>
        internal void Initialize()
        {

            if (this._parent != null && this._newLines.Any())
                foreach (StructureTable table in this._newLines)
                    foreach (StructureTable parentTable in this._parent.GetTables())
                        foreach (StructureColumn key in parentTable.PrimaryKey)
                        {
                            StructureColumn foreignKey = table.GenerateRelationFrom(key);
                            this._parentKeys.Add((key, foreignKey));
                        }


            foreach (var item in this._sub)
                item.Initialize();

        }

        public string Name { get; set; }

        public bool IsArray { get; internal set; }

        public IEnumerable<StructureTable> GetTables()
        {

            if (_parent != null)
                foreach (var item in _parent.GetTables())
                    yield return item;

            foreach (var item in this._newLines)
                yield return item;

        }


        #region Build template

        internal SourceMappingProperty AddProperty(string name)
        {
            var p = new SourceMappingProperty() { Name = name };
            this._properties.Add(p);
            return p;
        }

        internal Parser AddSub(string name)
        {
            var p = new Parser(this, this.Schema) { Name = name };
            this._sub.Add(p);
            return p;
        }

        internal void AppendNewLine(string tableName)
        {
            var t = this.Schema.Get<StructureTable>(tableName);
            this._newLines.Add(t);
            AppendDependencies(t);
        }

        private void AppendDependencies(StructureTable t)
        {
            
            if (this._parent != null)
                this._parent.AppendDependencies(t);

            else if (!this._dependencies.Contains(t))
                this._dependencies.Insert(0, t);

        }

        #endregion Build template

        /// <summary>
        /// Create a new context.
        /// </summary>
        /// <param name="flush"></param>
        /// <param name="bulkCount"></param>
        /// <returns></returns>
        public Context Open(Func<Context, DataTable, bool> flush = null, int bulkCount = 50000)
        {
            var ctx = new Context(this.Schema)
                .SetFlush(flush)
                .SetBulkCount(bulkCount)
                .SetDependencies(_dependencies);
            ;
            return ctx;
        }

        public void Load(JToken obj, Context ctx)
        {
            ImportCurrent(obj, ctx);
        }


        private void ImportCurrent(JToken obj, Context ctx)
        {

            ctx.Increment();

            if (this.IsArray)
            {

                var a = obj as JArray;
                foreach (var item in a)
                {
                    OpenNewLines(ctx);

                    ParseProperties(item, ctx);
                    ParseSub(item, ctx);

                    CloseLines(ctx);

                }
            }
            else
            {

                OpenNewLines(ctx);

                ParseProperties(obj, ctx);
                ParseSub(obj, ctx);

                CloseLines(ctx);

            }

            ctx.Decrement();

        }

        private void CloseLines(Context ctx)
        {

            bool result = false;

            foreach (var tableName in this._newLines)
            {
                var r = ctx.Close(tableName);
                if (r)
                    result = true;

            }

            if (result && ctx.IsRootLevel)
                ctx.Flush();

        }

        private void OpenNewLines(Context ctx)
        {
            foreach (var tableName in this._newLines)
                ctx.NewLine(tableName, this._parentKeys);
        }

        private void ParseSub(JToken obj, Context ctx)
        {
            foreach (var item in this._sub)
            {
                JToken t = obj[item.Name];
                if (t != null)
                    item.ImportCurrent(t, ctx);
            }
        }

        private void ParseProperties(JToken obj, Context ctx)
        {

            foreach (var PropertySource in _properties)
            {
                var s = obj[PropertySource.Name];
                ctx.AppendProperty(PropertySource, s);
            }
        }


        private readonly List<SourceMappingProperty> _properties;
        private readonly List<Parser> _sub;
        private List<StructureTable> _newLines;
        private List<StructureTable> _dependencies;
        private List<(StructureColumn, StructureColumn)> _parentKeys;

        public StructureSchema Schema { get; }

        private readonly Parser _parent;


    }






}
