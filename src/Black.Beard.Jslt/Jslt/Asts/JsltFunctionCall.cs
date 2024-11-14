using Bb.Analysis.DiagTraces;
using Bb.Asts;
using Bb.ComponentModel.Factories;
using Bb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Jslt.Asts
{


    /// <summary>
    /// Represents a function to call.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("call {Name}")]
    public class JsltFunctionCall : JsltBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltFunctionCall"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="arguments">The arguments.</param>
        public JsltFunctionCall(string name, params JsltBase[] arguments) : this(name, arguments.ToList())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltFunctionCall"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="arguments">The arguments.</param>
        public JsltFunctionCall(string name, IEnumerable<JsltBase> arguments) : this(name, arguments?.ToList())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltFunctionCall"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="arguments">The arguments.</param>
        public JsltFunctionCall(string name, List<JsltBase> arguments)
        {

            this.Name = name;
            this.Kind = JsltKind.Function;

            this._items = new List<JsltArgument>();
            this._items2 = new List<JsltArgument>();

            if (arguments != null && arguments.Count > 0)
            {
                foreach (var item in arguments)
                {
                    var argName = "arg" + this._items.Count.ToString();
                    this._items.Add(new JsltArgument()
                    {
                        Name = argName,
                        Value = item,
                        Location = (TextLocation)item?.Location?.Clone() ?? TextLocation.Empty,
                    });
                }
            }

        }

        /// <summary>
        /// Injects the specified argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="position">The position.</param>
        public void Inject(JsltBase argument, int position)
        {

            _items2.Insert(position, new JsltArgument()
            {
                Name = string.Empty,
                Value = argument,
                Location = (TextLocation)argument?.Location?.Clone() ?? TextLocation.Empty,
            });

            int index = 0;
            foreach (var item in _items2)
            {
                var argName = "arg" + (index++).ToString();
                item.Name = argName;
            }

        }

        public IEnumerable<JsltArgument> Arguments { get => _items; }


        public JsltArgument this[int index]
        {
            get => _items[index];
        }

        public int ArgumentCount { get => _items.Count; }

        public List<JsltArgument> ArgumentsBis { get => _items2; }


        public Factory ServiceProvider
        {
            get => _serviceProvider;
            internal set
            {

                _serviceProvider = value;

                int j = 0;
                if (_serviceProvider.Types[0] == typeof(RuntimeContext))
                    j++;

                for (int i = 0; i < ArgumentCount; i++)
                {
                    var current = _items[i];
                    current.MethodType = _serviceProvider.Types[j];
                    j++;
                }

            }
        }

        public Type[] ParameterTypes => _serviceProvider.Types;


        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Accepts the specified visitor for parsing the tree.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitFunction(this);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="strategy">The strategy.</param>
        /// <returns></returns>
        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            writer.Append(Name);
            writer.Append("(");

            if (this._items.Count > 0)
            {

                writer.ToString(_items[0]);

                for (int i = 1; i < _items.Count; i++)
                {
                    writer.Append(", ");
                    writer.ToString(_items[i]);
                }

            }

            writer.Append(")");

            return true;

        }

        private Factory _serviceProvider;
        private readonly List<JsltArgument> _items;
        private readonly List<JsltArgument> _items2;

    }


}

