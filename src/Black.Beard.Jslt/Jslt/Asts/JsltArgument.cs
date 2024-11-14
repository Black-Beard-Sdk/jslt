using Bb.Asts;
using Bb.Contracts;
using Bb.Json.Linq;
using System;

namespace Bb.Jslt.Asts
{

    /// <summary>
    /// Represents an argument in a Jslt function.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("arg {Name}={Value}")]
    public class JsltArgument : JsltBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltArgument"/> class.
        /// </summary>
        public JsltArgument()
        {
            this.Kind = JsltKind.Property;
        }

        /// <summary>
        /// Gets or sets the name of the argument.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the argument.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public JsltBase Value
        {
            get => _value;
            set
            {
                _value = value;
                //if (_value != null && _value.Kind == JsltKind.Jpath)
                //    if (_methodType != null)
                //        _value.AddTag(typeof(JToken).IsAssignableFrom(_methodType), TagEnum.ToExecute);
                //    else
                //        _value.DelTag(TagEnum.ToExecute);
            }
        }

        /// <summary>
        /// Gets or sets the type of the method.
        /// </summary>
        public Type MethodType
        {
            get => _methodType;
            internal set
            {
                _methodType = value;
                if (_value != null && _value.Kind == JsltKind.Jpath)
                    _value.AddTag(typeof(JToken).IsAssignableFrom(_methodType), TagEnum.ToExecute);
            }
        }

        /// <summary>
        /// Accepts the specified visitor for parsing the tree.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitArgument(this);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="strategy">The strategy.</param>
        /// <returns></returns>
        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {
            return writer.ToString(Value);
        }

        private JsltBase _value;
        private Type _methodType;

    }


}
