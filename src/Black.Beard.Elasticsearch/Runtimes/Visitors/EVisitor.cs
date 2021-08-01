using Bb.Elastic.Runtimes.Models;
using Bb.Elastic.SqlParser.Models;
using System;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes.Visitors
{

    public class EVisitor : IVisitor<object>
    {

        public EVisitor(ElasticConnectionList connections)
        {
            this._connections = connections;
        }

        public object Visit(AstBase n)
        {
            return n.Accept(this);
        }

        public object SpecificationSourceAlias(SpecificationSourceAlias n)
        {
            return n.Alias.Accept(this);
        }

        public object VisitUnaryExpression(UnaryExpression n)
        {

            switch (n.Operator)
            {
                case UnaryOperatorEnum.Undefined:
                    break;
                case UnaryOperatorEnum.Not:
                    break;
                case UnaryOperatorEnum.Exists:
                    break;
                case UnaryOperatorEnum.IsNull:
                    break;
                case UnaryOperatorEnum.IsNotNull:
                    break;
                case UnaryOperatorEnum.Distinct:
                    break;
                default:
                    break;
            }

            Stop();
            throw new NotImplementedException();
        }



        public object VisitAlias(AliasReferenceAst n)
        {

            var v = n.Value.Accept(this);
            // var name = n.AliasName.Accept(this);

            if (v is Action<ECall> a)
            {

            }
            else
            {
                Stop();
            }

            return v;

        }

        public object VisitIdentifier(Identifier n)
        {
            return n.Text;
        }

        public object VisitList(AstBase n)
        {

            List<ECall> result = new List<ECall>();
            var n1 = (IEnumerable<AstBase>)n;

            foreach (AstBase item in n1)
                result.Add((ECall)item.Accept(this));

            return result;
        }

        public object VisitSpecification(Specification n)
        {

            var specification = new ESpecification()
            {

            };

            ECall call = new ECall()
            {
                Query = specification,
            };


            if (n.Source != null)
            {
                var r = (Action<ECall>)n.Source.Accept(this);
                r(call);
            }

            if (n.Limit != null)
            {
                var limit = (Action<ESpecification>)n.Limit.Accept(this);
                limit(specification);
            }

            if (n.Sort != null)
            {
                Stop();
                var sort = (Action<ESpecification>)n.Sort.Accept(this);
                sort(specification);
            }

            if (n.Filter != null)
            {
                specification.Query = new EQuery();
                var act = (Action<EQuery>)n.Filter.Accept(this);
                act(specification.Query);
            }


            return call;

        }

        public object VisitLiteral(Literal n)
        {
            return n.Value;
        }



        public object VisitSelectSpecificationSource(SpecificationSourceSelect n)
        {
            Stop();
            return null;
        }

        public object VisitTableSpecificationSource(SpecificationSourceTable n)
        {

            Action<ECall> act = c =>
            {

                var name = n.Name;

                if (name.IsComposite)
                {
                    c.Index = name.TargetRight.Text;
                    c.Connection = this._connections[name.Text];

                }
                else
                {
                    c.Index = name.Text;
                    c.Connection = this._connections[null];
                }

            };

            return act;

        }

        public object VisitFunctionSpecificationSource(SpecificationSourceFunction n)
        {
            Stop();
            return null;
        }

        public object VisitSpecificationLimit(SpecificationLimit n)
        {

            Action<ESpecification> limit = s =>
            {
                s.From = (int)n.Offset.Value;
                s.Size = (int)n.RowCount.Value;
            };

            return limit;

        }

        public object VisitProjection(SpecificationProjection n)
        {

            //if (n.Origin != null)
            //    result = (_specifications<TInferDocument>)n.Origin.Accept(this);

            //foreach (var item in n.Projections)
            //{
            //    if (item is Identifier i)
            //    {
            //        if (i.Text != "*")
            //            result.Add(c => c.StoredFields(i.Text));

            //    }
            //    else
            //    {

            //    }

            //}

            return null;

        }

        public object VisitSorting(SpecificationSorting n)
        {

            //if (n.Origin != null)
            //    result = (_specifications<TInferDocument>)n.Origin.Accept(this);

            //foreach (var item in n.Sorts)
            //    result.Add((Func<SearchDescriptor<TInferDocument>, ISearchRequest>)item.Accept(this));

            return null;

        }

        public object VisitSpecificationSort(SpecificationSortItem n)
        {

            Stop();


            //if (n.AscSort)
            //    function = c => c.Sort(d => d.Ascending(n.Expression.ToString()));
            //else
            //    function = c => c.Sort(d => d.Descending(n.Expression.ToString()));

            return null;

        }

        public object VisitSpecificationFilter(SpecificationFilter n)
        {

            //if (n.Origin != null)
            //    n.Origin.Accept(this);

            var filter = n.Filter.Accept(this);
            if (filter is Action<EBool> a)
            {

                Action<EQuery> act = q =>
                {

                    if (q.Bool == null)
                        q.Bool = new EBool();

                    a(q.Bool);

                };
                return act;

            }



            //   (q) => q.Query(b => b.Bool(m => m.Must(filter)))

            Stop();

            return null;

        }

        public object VisitBinaryExpression(BinaryExpression n)
        {

            var l = n.Left.Accept(this);
            var r = n.Right.Accept(this);

            switch (n.Operator)
            {
                case BinaryOperatorEnum.Undefined:
                    Stop();
                    break;

                case BinaryOperatorEnum.Equal: return GetEqual(l, r);
                case BinaryOperatorEnum.And: return GetAnd(l, r);
                case BinaryOperatorEnum.Or: return GetOr(l, r);
                case BinaryOperatorEnum.NotEqual: return GetNotEqual(l, r);
                case BinaryOperatorEnum.LessThan: return GetLessThan(l, r);
                case BinaryOperatorEnum.GreaterThan: return GetGreaterThan(l, r);
                case BinaryOperatorEnum.LessOrEqualThan: return GetLessOrEqualThan(l, r);
                case BinaryOperatorEnum.GreaterOrEqualThan: return GetGreaterOrEqualThan(l, r);

                case BinaryOperatorEnum.Multiply:
                    Stop();
                    break;
                case BinaryOperatorEnum.Remove:
                    Stop();
                    break;
                case BinaryOperatorEnum.Add:
                    Stop();
                    break;
                case BinaryOperatorEnum.Div:
                    Stop();
                    break;
                case BinaryOperatorEnum.Modulo:
                    Stop();
                    break;

                case BinaryOperatorEnum.Concat:
                    Stop();
                    break;

                case BinaryOperatorEnum.BitwiseOr:
                    Stop();
                    break;
                case BinaryOperatorEnum.BitwiseAnd:
                    Stop();
                    break;
                case BinaryOperatorEnum.LeftShift:
                    Stop();
                    break;
                case BinaryOperatorEnum.RightShift:
                    Stop();
                    break;
                case BinaryOperatorEnum.IsNot:
                    Stop();
                    break;
                case BinaryOperatorEnum.Is:
                    Stop();
                    break;
                case BinaryOperatorEnum.Like:
                    Stop();
                    break;
                case BinaryOperatorEnum.Glob:
                    Stop();
                    break;
                case BinaryOperatorEnum.Match:
                    Stop();
                    break;
                case BinaryOperatorEnum.Regex:
                    Stop();
                    break;
                case BinaryOperatorEnum.In:
                    Stop();
                    break;
                default:
                    Stop();
                    break;
            }

            Stop();

            return null;

        }

        private object GetGreaterOrEqualThan(object l, object r)
        {



            Stop();

            if (l is int left)
            {
                if (r is int right)
                {
                    //queries = (q) => q.MatchNone(m => m.Name(left).Query(right));
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                Stop();
            }

            return null;
        }

        private object GetLessThan(object l, object r)
        {
            Stop();
            throw new NotImplementedException();
        }

        private object GetGreaterThan(object l, object r)
        {
            Stop();
            throw new NotImplementedException();
        }

        private object GetLessOrEqualThan(object l, object r)
        {
            Stop();
            throw new NotImplementedException();
        }

        private object GetNotEqual(object l, object r)
        {

            Stop();

            if (l is string left)
            {
                if (r is string right)
                {
                    // queries = (q) => q.MatchNone(m => m.Field(left).Query(right));
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                Stop();
            }

            return null;
        }

        private object GetOr(object l, object r)
        {
            Stop();
            throw new NotImplementedException();
        }

        private object GetAnd(object l, object r)
        {
            Stop();
            throw new NotImplementedException();
        }

        private static object GetEqual(object l, object r)
        {

            if (l is string left)
            {
                if (r is string right)
                {
                    Action<EBool> act = b =>
                    {
                        if (b.Filter == null)
                            b.Filter = new EFilter();

                        b.Filter.Items.Add(new ETerm() { Name = left, value = right });
                    };
                    return act;

                    //   queries = (q) => q.Match(m => m.Field(left).Query(right));
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                Stop();
            }

            return null;

        }

        public object VisitCase(CaseExpression n)
        {
            Stop();
            throw new NotImplementedException();
        }

        public object VisitCaseWhen(CaseWhenExpression n)
        {
            Stop();
            throw new NotImplementedException();
        }

        public object VisitCaseExpression(CastExpression n)
        {
            Stop();
            throw new NotImplementedException();
        }

        public object VisitParameter(ParameterBind n)
        {
            Stop();
            throw new NotImplementedException();
        }

        public object VisitFunctionCall(FunctionCall n)
        {

            Stop();
            throw new NotImplementedException();
        }


        public object VisitElasticServerReference(ElasticServerReference n)
        {
            Stop();
            throw new NotImplementedException();
        }

        public object VisitElasticTableReference(ElasticTableReference n)
        {
            Stop();
            throw new NotImplementedException();
        }


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void Stop()
        {

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();

        }


        private readonly ElasticConnectionList _connections;


    }

}