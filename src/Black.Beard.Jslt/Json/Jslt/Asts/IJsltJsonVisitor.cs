using Bb.Json.Jslt.Services;

namespace Bb.Json.Jslt.Asts
{
    public interface IJsltJsonVisitor
    {


        TranformJsonAstConfiguration Configuration { get; set; }


        object VisitArray(JsltArray node);

        object VisitConstant(JsltConstant node);

        object VisitObject(JsltObject node);

        object VisitProperty(JsltProperty node);

        object VisitFunction(JsltFunction node);

        object VisitJPath(JsltPath node);

        object VisitMapProperty(JsltMapProperty node);

        object VisitLinkedCode(JsltLinkedCode node);

        object VisitUnaryOperator(JsltOperator node);

        object VisitBinaryOperator(JsltBinaryOperator node);
        
        object VisitCase(JsltCase node);

        object VisitSwitch(JslSwitch node);

    }

}
