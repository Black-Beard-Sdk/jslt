using Bb.Asts;

namespace Bb.Json.Jslt.Asts
{

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
        public JsltBase Value { get; set; }

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

    }

}
