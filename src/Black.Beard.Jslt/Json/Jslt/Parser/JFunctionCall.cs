using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Json.Jslt.Parser
{


    public class JFunctionCall : JExpression
    {

        public JFunctionCall(string name, params object[] arguments)
            : this(name, arguments.Select(c => Convert(c) ))
        {

        }

        private static JToken Convert(object c)
        {
            return JToken.FromObject(c);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JFunctionCall(string name, IEnumerable<JToken> arguments) 
            : base()
        {
            this.Name = name;
            this.Arguments = new List<JToken>(arguments);
        }

        public string Name { get; }

        public List<JToken> Arguments { get; }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            writer.WriteRaw(".");
            writer.WriteRaw(this.Name);
            writer.WriteRaw("(");
            string comma = string.Empty;
            foreach (var argument in this.Arguments)
            {
                writer.WriteRaw(comma);
                argument.WriteTo(writer, converters);
                comma = ", ";
            }
            writer.WriteRaw(")");
        }

    }



}
