using Bb.ComponentModel.Factories;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Json.Jslt.Asts
{

   [System.Diagnostics.DebuggerDisplay("call {Name}")]
    public class JsltFunctionCall : JsltBase
    {


        public JsltFunctionCall(string name, List<JsltBase> arguments)
        {

            this.Name = name;
            this.Kind = JsltKind.Function;
            this._items = new Dictionary<string, JsltArgument>();
            foreach (var item in arguments)
            {
                var argName = "arg" + this._items.Count.ToString();
                this._items.Add(argName, new JsltArgument()
                {
                    Name = argName,
                    Value = item,
                });
            }

        }

        public IEnumerable<JsltArgument> Arguments { get => _items.Values; }

        public Type[] ParameterTypes { get; internal set; }

        public string Type { get; internal set; }

        public Factory ServiceProvider { get; internal set; }

        public string Name { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitFunction(this);
        }

        private readonly Dictionary<string, JsltArgument> _items;

    }


}

