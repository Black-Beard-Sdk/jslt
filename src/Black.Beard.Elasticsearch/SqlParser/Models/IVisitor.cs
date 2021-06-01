namespace Bb.Elastic.SqlParser.Models
{

    
    public interface IVisitor
    {

        object Visit(AstBase n);

    }

    public interface IVisitor<T> : IVisitor
    {


        //T Visit(AstBase n);

        T VisitCase(CaseExpression n);
        T VisitCaseWhen(CaseWhenExpression n);
        T VisitCaseExpression(CastExpression n);
        

        T VisitSpecification(Specification n);
        T VisitProjection(SpecificationProjection n);
        T VisitTableSpecificationSource(SpecificationSourceTable n);
        T VisitFunctionSpecificationSource(SpecificationSourceFunction n);
        T VisitSelectSpecificationSource(SpecificationSourceSelect n);
        T SpecificationSourceAlias(SpecificationSourceAlias n);
        T VisitSpecificationFilter(SpecificationFilter n);
        T VisitSpecificationLimit(SpecificationLimit n);
        T VisitSorting(SpecificationSorting n);
        T VisitSpecificationSort(SpecificationSortItem n);

        T VisitList(AstBase n);
        T VisitAlias(AliasAstBase n);
        T VisitParameter(ParameterBind n);
        T VisitLiteral(Literal n);
        T VisitIdentifier(Identifier n);
        T VisitFunctionCall(FunctionCall n);


        T VisitUnaryExpression(UnaryExpression n);
        T VisitBinaryExpression(BinaryExpression n);

    }

}