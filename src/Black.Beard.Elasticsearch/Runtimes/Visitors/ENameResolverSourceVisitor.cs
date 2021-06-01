using Bb.Elastic.SqlParser.Models;
using System;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes.Visitors
{
    internal class ENameResolverSourceVisitor : IVisitor<Identifier>
    {


        private ENameResolverSourceVisitor()
        {

        }

        public static Identifier GetName(AstBase self)
        {
            var v = new ENameResolverSourceVisitor() as IVisitor<Identifier>;
            return (Identifier)v.Visit(self);
        }

        Identifier IVisitor<Identifier>.SpecificationSourceAlias(SpecificationSourceAlias n)
        {
            return n.Alias;
        }

        object IVisitor.Visit(AstBase n)
        {
            return n.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitAlias(AliasAstBase n)
        {
            return n;
        }

        Identifier IVisitor<Identifier>.VisitBinaryExpression(BinaryExpression n)
        {
            return n.Left.Accept(this) ?? n.Right.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitCase(CaseExpression n)
        {
            return n.CaseExpr.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitCaseExpression(CastExpression n)
        {
            return n.Expression.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitCaseWhen(CaseWhenExpression n)
        {
            return n.ThenExpr.Accept(this) ?? n.WhenExpr.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitFunctionCall(FunctionCall n)
        {
            return n.Name;
        }

        Identifier IVisitor<Identifier>.VisitFunctionSpecificationSource(SpecificationSourceFunction n)
        {
            return n.Function.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitIdentifier(Identifier n)
        {
            return n;
        }

        Identifier IVisitor<Identifier>.VisitList(AstBase n)
        {
            var n1 = (IEnumerable<AstBase>)n;
            foreach (AstBase item in n1)
            {
                var r = item.Accept(this);
                if (r != null)
                    return r;
            }
            return null;
        }

        Identifier IVisitor<Identifier>.VisitLiteral(Literal n)
        {
            return null;
        }

        Identifier IVisitor<Identifier>.VisitParameter(ParameterBind n)
        {
            return null;
        }

        Identifier IVisitor<Identifier>.VisitProjection(SpecificationProjection n)
        {
            foreach (var item in n.Projections)
            {
                var r = item.Accept(this);
                if (r != null)
                    return r;
            }
            return null;
        }

        Identifier IVisitor<Identifier>.VisitSelectSpecificationSource(SpecificationSourceSelect n)
        {
            return n.ShortName ?? n.Select.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitSorting(SpecificationSorting n)
        {

            foreach (var item in n.Sorts)
            {
                var r = item.Accept(this);
                if (r != null)
                    return r;
            }

            return null;

        }

        Identifier IVisitor<Identifier>.VisitSpecification(Specification n)
        {
            return n.Source.Accept(this) 
                ?? n.Filter.Accept(this) 
                ?? n.Projection.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitSpecificationFilter(SpecificationFilter n)
        {
            return n.Filter.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitSpecificationLimit(SpecificationLimit n)
        {
            return null;
        }

        Identifier IVisitor<Identifier>.VisitSpecificationSort(SpecificationSortItem n)
        {
            return n.Expression.Accept(this);
        }

        Identifier IVisitor<Identifier>.VisitTableSpecificationSource(SpecificationSourceTable n)
        {
            return n.Name;
        }

        Identifier IVisitor<Identifier>.VisitUnaryExpression(UnaryExpression n)
        {
            return n.Expression.Accept(this);
        }
    }

}