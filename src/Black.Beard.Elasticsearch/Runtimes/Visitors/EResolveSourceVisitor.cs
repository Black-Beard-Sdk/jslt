using Bb.Elastic.Runtimes.Models;
using Bb.Elastic.SqlParser.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Elastic.Runtimes.Visitors
{

    internal class EResolveSourceVisitor : IVisitor<object>
    {

        public EResolveSourceVisitor(ElasticConnectionList connections, ContextExecutor ctx)
        {
            this._connection = connections;
            this._ctx = ctx;
        }

        public object SpecificationSourceAlias(SpecificationSourceAlias n)
        {
            return n.Alias.Accept(this);
        }

        public object Visit(AstBase n)
        {

            n.Accept(this);

            //ResolveTablesStructures();

            //var tables = _ctx.Items.Where(c => c.Kind == ReferenceKindEnum.Table).ToList();
            //foreach (Reference item in tables)
            //{

            //}


            return n;
        }

        //private void ResolveTablesStructures()
        //{
        //    var servers = _ctx.Items.Where(c => c.Kind == ReferenceKindEnum.Server).ToList();
        //    foreach (Reference item in servers)
        //    {
        //        var cnx = _connection[item.Name] as ConnectionElastic;
        //        var items = _ctx.Items.Where(c => c.Parent == item).ToList();
        //        foreach (var item2 in items)
        //        {

        //            ServerTableStructure table = cnx.Tables(_ctx)[item2.Name];
        //            item2.Structure = table.Fields(_ctx);

        //            var items3 = _ctx.Items.Where(c => c.Target == item2).ToList();
        //            foreach (var item4 in items3)
        //            {
        //                item4.Structure = item2.Structure;

        //                var items4 = _ctx.Items.Where(c => c.Kind == ReferenceKindEnum.TableAlias && c.Name == item4.Name).ToList();

        //            }
        //        }
        //    }
        //}



        public object VisitIdentifier(Identifier n)
        {

            if (n.Text != "*")
            {

                ElasticProcessor cnx = null;
                ServerTableStructure table = null;
                var item = n;
                while (item != null)
                {

                    switch (item.Kind)
                    {

                        case IdentifierKindEnum.ServerReference:
                            cnx = _connection[item.Text] as ElasticProcessor;
                            item.Reference = cnx;
                            _ctx.AddReference(new Reference() { Name = item.Text, Value = item, Kind = ReferenceKindEnum.Server });
                            break;

                        case IdentifierKindEnum.TableReference:

                            var t = _ctx.Get(item.Text);
                            if (t.Count == 1)
                            {
                                var alias = t[0].Value as Identifier;
                                if (alias.Reference != null)
                                    table = (ServerTableStructure)alias.Reference;
                            }

                            if (table != null)
                            {
                                if (cnx == null)
                                {
                                    if (_connection.Count == 1)
                                    {
                                        cnx = _connection[0] as ElasticProcessor;
                                    }
                                    else
                                    {
                                        var cnxs = _connection.Resolve<ElasticProcessor>(c => c.Tables(_ctx).Contains(item.Text)).ToList();
                                        if (cnxs.Count > 1)
                                        {
                                            _ctx.Trace.AddError(new ResultMessageModel()
                                            {

                                            });
                                        }
                                    }
                                }

                                table = cnx.Tables(_ctx)[item.Text];
                                _ctx.AddReference(new Reference() { Name = item.Text, Value = item, Kind = ReferenceKindEnum.Table });
                            }

                            item.Reference = table;

                            break;

                        case IdentifierKindEnum.ColumnReference:
                            if (table == null)
                            {
                                // Stop();
                            }
                            _ctx.AddReference(new Reference() { Name = item.Text, Value = item, Kind = ReferenceKindEnum.Column });
                            break;

                        case IdentifierKindEnum.FunctionReference:
                            break;

                        case IdentifierKindEnum.Undefined:
                        default:
                            break;
                    }

                    item = item.TargetRight;

                }



                //var server = n.GetServerName;
                //var table = n.GetTableName;
                //var column = n.GetColumnName;
                //var function = n.GetfunctionName;
                //AstBase p = null;
                //Reference parent = null;
                //if (server != null)
                //{
                //    _ctx.AddReference(parent = new Reference() { Name = server.Text, Kind = ReferenceKindEnum.Server, Value = server });
                //}

                //if (table != null)
                //{
                //    var r = _ctx.Get(table.Text);
                //    if (r.Count == 1)
                //        _ctx.AddReference(parent = new Reference() { Name = table.Text, Kind = r[0].Kind, Value = table, Parent = parent });
                //    else
                //        _ctx.AddReference(parent = new Reference() { Name = table.Text, Kind = ReferenceKindEnum.Table, Value = table, Parent = parent });

                //}

                //if (column != null)
                //    _ctx.AddReference(parent = new Reference() { Name = column.Text, Kind = ReferenceKindEnum.Column, Value = column, Parent = parent });

                //if (function != null)
                //    _ctx.AddReference(parent = new Reference() { Name = function.Text, Kind = ReferenceKindEnum.Function, Value = function, Parent = parent });

            }

            return n;

        }

        public object VisitAlias(AliasAstBase n)
        {

            n.Value.Accept(this);
            Identifier name = ENameResolverSourceVisitor.GetName(n.Value);
            var n2 = name.TargetLast;
            n.Reference = n2;

            ReferenceKindEnum k = ReferenceKindEnum.Undefined;
            switch (n2.Kind)
            {

                case IdentifierKindEnum.ServerReference:
                    k = ReferenceKindEnum.ServerAlias;
                    break;

                case IdentifierKindEnum.TableReference:
                    k = ReferenceKindEnum.TableAlias;
                    break;

                case IdentifierKindEnum.ColumnReference:
                    k = ReferenceKindEnum.ColumnAlias;
                    break;

                case IdentifierKindEnum.FunctionReference:
                    k = ReferenceKindEnum.FunctionAlias;
                    break;

                case IdentifierKindEnum.Undefined:
                default:
                    break;

            }

            _ctx.AddReference(new Reference() { Name = n.AliasName.Text, Value = n2, Kind = k });

            return n;
        }

        public object VisitTableSpecificationSource(SpecificationSourceTable n)
        {
            n.Subs?.Accept(this);
            n.Name.Accept(this);
            n.IndexedBy?.Accept(this);
            return n;
        }

        public object VisitSelectSpecificationSource(SpecificationSourceSelect n)
        {
            Stop();
            n.Subs?.Accept(this);
            n.Select.Accept(this);
            return n;
        }

        public object VisitFunctionSpecificationSource(SpecificationSourceFunction n)
        {
            Stop();
            n.Function.Accept(this);
            return n;
        }


        public object VisitBinaryExpression(BinaryExpression n)
        {
            n.Left.Accept(this);
            n.Right.Accept(this);
            return n;
        }

        public object VisitCase(CaseExpression n)
        {
            n.Cases.Accept(this);
            Stop();
            return n;
        }

        public object VisitCaseExpression(CastExpression n)
        {
            n.Expression.Accept(this);
            Stop();
            return n;
        }

        public object VisitCaseWhen(CaseWhenExpression n)
        {
            n.ThenExpr.Accept(this);
            n.WhenExpr.Accept(this);
            Stop();
            return n;
        }

        public object VisitFunctionCall(FunctionCall n)
        {
            return n;
        }

        public object VisitList(AstBase n)
        {
            var n1 = (IEnumerable<AstBase>)n;
            foreach (AstBase item in n1)
                item.Accept(this);
            return n;
        }

        public object VisitLiteral(Literal n)
        {
            return n;
        }

        public object VisitParameter(ParameterBind n)
        {
            Stop();
            return n;
        }

        public object VisitProjection(SpecificationProjection n)
        {
            n.Projections.Accept(this);
            return n;
        }

        public object VisitSorting(SpecificationSorting n)
        {
            n.Sorts.Accept(this);
            Stop();
            return n;
        }

        public object VisitSpecification(Specification n)
        {
            n.Source.Accept(this);
            n.Filter.Accept(this);
            n.Limit.Accept(this);
            n.Projection.Accept(this);
            n.Sort?.Accept(this);
            return n;
        }

        public object VisitSpecificationFilter(SpecificationFilter n)
        {
            n.Filter.Accept(this);
            return n;
        }

        public object VisitSpecificationLimit(SpecificationLimit n)
        {
            return n;
        }

        public object VisitSpecificationSort(SpecificationSortItem n)
        {
            n.Expression.Accept(this);
            return n;
        }


        public object VisitUnaryExpression(UnaryExpression n)
        {
            n.Expression.Accept(this);
            return n;
        }



        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void Stop()
        {

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();

        }

        private readonly ElasticConnectionList _connection;

        public ContextExecutor _ctx { get; }
    
    }

}