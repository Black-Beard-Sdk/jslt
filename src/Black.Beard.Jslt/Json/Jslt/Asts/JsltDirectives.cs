using Bb.Asts;
using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{

    public class JsltDirectives : JsltProperty
    {

        public JsltDirectives()
        {
            this.Kind = JsltKind.Property;
            this.Name = "$directives";
        }
       

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitDirective(this);
        }


        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            writer.Append($"{Quote}{Name}{Quote} : ");

            if (Value != null)
            {

                if (Value is JsltObject)
                    writer.AppendEndLine();

                else if (Value is JsltArray)
                    writer.AppendEndLine();

                writer.ToString(Value);

            }
            else
                writer.Append("null");

            return true;

        }


    }

}
