using Bb.Elastic.Parser;
using Bb.Elastic.Runtimes.Models;
using Bb.Elastic.Runtimes.Visitors;
using Bb.Elastic.SqlParser.Models;
using Elasticsearch.Net;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Bb.Elastic.Runtimes
{


    public class ElasticExecutor
    {


        internal ElasticExecutor(ElasticConnections connections)
        {

            this._metaVisitor = new MetaVisitor(connections)
                .Append((cnx, ctx) => new EResolveSourceVisitor(cnx, ctx))
                .Append((cnx, ctx) => new EVisitor(cnx))                // translate tree to elastic query
          ;

        }

        /// <summary>
        /// Path where process write output files
        /// </summary>
        public DirectoryInfo WorkingSpace { get; set; }

        /// <summary>
        /// Culture for processing
        /// </summary>
        public CultureInfo Culture { get; set; }


        /// <summary>
        /// Execute the specified query
        /// </summary>
        /// <param name="querySql"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEnumerable<Result> Execute(StringBuilder querySql, string filename)
        {

            var ctx = GetContext(querySql, filename);

            List<Result> results = new List<Result>();
            foreach (ECall item in ctx.Request.ExecuableQuery)
            {
                var result = item.Connection.ExecuteQuery<StringResponse>(ctx, item);
                results.Add(result);
            }

            return results;

        }

        /// <summary>
        /// Evaluate the running plan
        /// </summary>
        /// <param name="querySql"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public ContextExecutor Plan(StringBuilder querySql, string filename = null)
        {

            var ctx = GetContext(querySql, filename);

            foreach (ECall item in ctx.Request.ExecuableQuery)
            {
                RequestQuery req = item.Connection.Plane(ctx, item);
                ctx.Request.AppendRequest(req);
            }

            return ctx;

        }


        private ContextExecutor GetContext(StringBuilder querySql, string filename)
        {

            if (string.IsNullOrEmpty(filename))
                filename = "Text";

            ContextExecutor ctx = new ContextExecutor(this, querySql, filename);

            // Parse sql
            AstBase ast = GetTree(ctx);

            // Convert ast to local model
            SourceParser parser = SourceParser.ParseString(querySql, filename, ctx.Trace.Output, ctx.Trace.OutputError);

            // Execute multiple visitor for resolve server model, evaluate matching type, ...
            var visitor = new ElasticParserVisitorImplemetation(ctx);
            var tree = visitor.Visit(parser.Tree);
            ctx.Request.ExecuableQuery = (List<object>)this._metaVisitor.Visit(tree, ctx);

            return ctx;
        }

        private static AstBase GetTree(ContextExecutor ctx)
        {
            // Parse sql
            SourceParser parser = SourceParser.ParseString(ctx.Request.Query, ctx.Request.Filename, ctx.Trace.Output, ctx.Trace.OutputError);
            var visitor = new ElasticParserVisitorImplemetation(ctx)
            {
            };
            var ast = ctx.Request.Ast = visitor.Visit(parser.Tree);
            return ast;
        }

        
        private readonly MetaVisitor _metaVisitor;


    }


}