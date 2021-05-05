using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Json.Jslt.Asts
{


    public class JsltFunction : JsltJson
    {


        public JsltFunction(JsltObject o)
        {

            this.Kind = JsltKind.Function;
            this._items = new Dictionary<string, JsltMapProperty>();

            foreach (var item in o.Properties.Where(c=> c.Name.StartsWith("$")))
                
                if (item.Name == TransformJsonConstants.Source)
                    this.Type = (item.Value as JsltConstant).Value.ToString();

                else
                    this._items.Add(item.Name, new JsltMapProperty() 
                    {
                        Name = item.Name.Substring(1), 
                        Value = item.Value 
                    });

        }

        public IEnumerable<JsltMapProperty> Properties { get => _items.Values; }

        public string Type { get; internal set; }

        public TransformJsonServiceProvider ServiceProvider { get; internal set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitType(this);
        }

        private readonly Dictionary<string, JsltMapProperty> _items;

    }

}
