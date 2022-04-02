using Bb.Json.Jslt.Services;

namespace Bb.Json.Jslt.Asts
{
    public interface IJsltJsonVisitor
    {


        TranformJsonAstConfiguration Configuration { get; set; }


        object VisitArray(JsltArray node);

        object VisitConstant(JsltConstant node);
        object VisitComment(Comment comment);
        object VisitObject(JsltObject node);

        object VisitDirective(JsltDirective node);

        object VisitProperty(JsltProperty node);

        object VisitFunction(JsltFunctionCall node);

        object VisitJPath(JsltPath node);

        object VisitArgument(JsltArgument node);

        object VisitLinkedCode(JsltLinkedCode node);

        object VisitUnaryOperator(JsltOperator node);

        object VisitBinaryOperator(JsltBinaryOperator node);
        
        object VisitCase(JsltCase node);

        object VisitSwitch(JsltSwitch node);
        
        object VisitTranslateVariable(JsltTranslateVariable node);

        object VisitJVariable(JsltVariable node);

        object VisitMetadata(JsltMetadata node);

    }

}
