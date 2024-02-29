using Bb.Analysis.DiagTraces;
using Bb.Json.Jslt.Asts;

namespace Bb.Json.Jslt.Services
{
    public class JsltIntellisenseVisitor : JsltBaseVisitor
    {


        public static JsltBase Parse(JsltBase self, TranformJsonAstConfiguration configuration, TextLocation location)
        {

            var visitor = new JsltIntellisenseVisitor()
            {
                Configuration = configuration,
                Location = location,
            };

            self.Accept(visitor);

            return visitor.Current;

        }


        private bool Evaluate(JsltBase item)
        {

            if (this.Location.StopEndBefore(item?.Location))
                if (this.Location.StopEndBefore(item?.Location))
                {
                    this.Current = item;
                    return true;
                }

            return false;

        }


        public override object VisitObject(JsltObject node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                foreach (var item in node.Variables)
                    item.Accept(this);

                foreach (var item in node.Properties)
                    item.Accept(this);

            }

            return node;

        }


        public override object VisitArgument(JsltArgument node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.Value != null)
                    node.Value.Accept(this);

            }

            return node;

        }


        public override object VisitArray(JsltArray node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                foreach (var item in node.Items)
                    item.Accept(this);
            }

            return node;

        }

        public override object VisitBinaryOperator(JsltBinaryOperator node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                node.Left.Accept(this);
                node.Right.Accept(this);
            }

            return node;

        }

        public override object VisitCase(JsltCase node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.RightExpression != null)
                    node.RightExpression.Accept(this);

                if (node.Block != null)
                    node.Block.Accept(this);
            }

            return node;

        }

        public override object VisitConstant(JsltConstant node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);
            }

            return node;
        }

        public override object VisitFunction(JsltFunctionCall node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                foreach (var item in node.Arguments)
                    item.Accept(this);

                foreach (var item in node.ArgumentsBis)
                    item.Accept(this);
            }

            return node;
        }

        public override object VisitJPath(JsltPath node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);
            }

            return node;

        }

        public override object VisitJVariable(JsltVariable node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.Value != null)
                    node.Value.Accept(this);
            }

            return node;

        }

        public override object VisitLinkedCode(JsltLinkedCode node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                foreach (var item in node.Items)
                    item.Accept(this);
            }

            return node;

        }

        public override object VisitDirective(JsltDirectives node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.Value != null)
                    node.Value.Accept(this);
            }

            return node;

        }

        public override object VisitProperty(JsltProperty node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.Value != null)
                    node.Value.Accept(this);

            }

            return node;

        }

        public override object VisitSwitch(JsltSwitch node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.Expression != null)
                    node.Expression.Accept(this);

                foreach (var item in node.Cases)
                    item.Where.Accept(this);

                if (node.Default != null)
                    node.Default.Accept(this);
            }

            return node;

        }

        public override object VisitTranslateVariable(JsltTranslateVariable node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                if (node.Value != null)
                    node.Value.Where.Accept(this);
            }

            return node;

        }

        public override object VisitUnaryOperator(JsltOperator node)
        {

            if (Evaluate(node))
            {

                if (node.Where != null)
                    node.Where.Accept(this);

                if (node.Source != null)
                    node.Source.Accept(this);

                node.Left.Accept(this);
            }

            return node;

        }



        public TextLocation Location { get; private set; }
        public JsltBase Current { get; private set; }
    }

}
