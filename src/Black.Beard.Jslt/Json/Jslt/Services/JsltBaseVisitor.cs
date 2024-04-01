using Bb.Json.Jslt.Asts;

namespace Bb.Json.Jslt.Services
{


    public class JsltBaseVisitor : IJsltJsonVisitor
    {

        public JsltBaseVisitor()
        {

        }

        public TranformJsonAstConfiguration Configuration { get; set; }


        public virtual object VisitObject(JsltObject node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            foreach (var item in node.Variables)
                item.Accept(this);

            foreach (var item in node.Properties)
                item.Accept(this);

            return node;

        }

        public virtual object VisitArgument(JsltArgument node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Value != null)
               node.Value.Accept(this);

            return node;

        }

        public virtual object VisitArray(JsltArray node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            foreach (var item in node.Items)
                item.Accept(this);

            return node;
        }

        public virtual object VisitBinaryOperator(JsltBinaryOperator node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            node.Left.Accept(this);
            node.Right.Accept(this);

            return node;
        }

        public virtual object VisitCase(JsltSwitchCase node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.RightExpression != null)
                node.RightExpression.Accept(this);

            if (node.Block != null)
                node.Block.Accept(this);

            return node;
        }

        public virtual object VisitConstant(JsltConstant node)
        {
            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            return node;
        }

        public object VisitMetadata(JsltMetadata node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            return node;

        }

        public virtual object VisitFunction(JsltFunctionCall node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            foreach (var item in node.Arguments)
                item.Accept(this);

            foreach (var item in node.ArgumentsBis)
                item.Accept(this);

            return node;
        }

        public virtual object VisitJPath(JsltPath node)
        {
            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            return node;
        }

        public virtual object VisitJVariable(JsltVariable node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            return node;
        }

        public virtual object VisitLinkedCode(JsltLinkedCode node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            foreach (var item in node.Items)
                item.Accept(this);

            return node;

        }

        public virtual object VisitDirective(JsltDirectives node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            return node;

        }

        public virtual object VisitProperty(JsltProperty node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            foreach (var item in node.Metadatas)
                item.Accept(this);

            return node;

        }

        public virtual object VisitSwitch(JsltSwitch node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Expression != null)
                node.Expression.Accept(this);

            foreach (var item in node.Cases)
                item?.Where?.Accept(this);

            if (node.Default != null)
                node.Default.Accept(this);

            return node;

        }

        public virtual object VisitTranslateVariable(JsltTranslateVariable node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Value != null)
                node.Value.Where?.Accept(this);

            return node;

        }

        public virtual object VisitUnaryOperator(JsltOperator node)
        {

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Source != null)
                node.Source.Accept(this);

            node.Left.Accept(this);

            return node;

        }

        public object VisitComment(JsltComment comment)
        {
            throw new System.NotImplementedException();
        }
    }

}
