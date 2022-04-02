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

            this._items = new List<JsltArgument>();
            this._items2 = new List<JsltArgument>();

            foreach (var item in arguments)
            {
                var argName = "arg" + this._items.Count.ToString();
                this._items.Add(new JsltArgument()
                {
                    Name = argName,
                    Value = item,
                    Start = item.Start.Clone(),
                    Stop = item.Stop.Clone(),
                });
            }

        }

        public void Inject(JsltBase argument, int position)
        {

            _items2.Insert(position, new JsltArgument() 
            {
                Name = string.Empty, 
                Value = argument, 
                Start = argument.Start.Clone(),
                Stop = argument.Stop.Clone() 
            });

            int index = 0;
            foreach (var item in _items2)
            {
                var argName = "arg" + (index++).ToString();
                item.Name = argName;
            }

        }

        public IEnumerable<JsltArgument> Arguments { get => _items; }

        public List<JsltArgument> ArgumentsBis { get => _items2; }

        public Type[] ParameterTypes { get; internal set; }

        public string Type { get; internal set; }

        public Factory ServiceProvider { get; internal set; }

        public string Name { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitFunction(this);
        }

        private readonly List<JsltArgument> _items;
        private readonly List<JsltArgument> _items2;

    }


}

