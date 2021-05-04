using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.Parser
{

    /// <summary>
    /// Represents a raw JSON string.
    /// </summary>
    public class JfunctionBodyDefinition : JRaw
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class.
		/// </summary>
		/// <param name="rawJson">The raw json.</param>
		public JfunctionBodyDefinition(string language, string rawJson)
			: base(rawJson)
		{
			this.Language = language;
		}

        public string Language { get; }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            writer.WriteRaw("'''");
            writer.WriteRaw(this.Language);
            writer.WriteRaw(Environment.NewLine);
            base.WriteTo(writer, converters);
            writer.WriteRaw("'''");
        }

        public override Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters)
        {
            return base.WriteToAsync(writer, cancellationToken, converters);
        }

    }

}
