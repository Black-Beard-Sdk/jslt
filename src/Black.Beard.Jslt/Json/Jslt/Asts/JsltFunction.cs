using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Json.Jslt.Asts
{


    public class JsltFunction : JsltJson
    {


        public JsltFunction(List<JsltJson> arguments)
        {

            this.Kind = JsltKind.Function;
            this._items = new Dictionary<string, JsltMapProperty>();
            foreach (var item in arguments)
            {
                var name = "arg" + this._items.Count.ToString();
                this._items.Add(name, new JsltMapProperty()
                {
                    Name = name,
                    Value = item
                });
            }

        }

        public IEnumerable<JsltMapProperty> Properties { get => _items.Values; }

        public string Type { get; internal set; }

        public Factory<ITransformJsonService> ServiceProvider { get; internal set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitFunction(this);
        }

        private readonly Dictionary<string, JsltMapProperty> _items;

    }

}
