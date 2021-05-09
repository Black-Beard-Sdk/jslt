using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{


    /// <summary>
    /// Represents a JSON path
    /// </summary>
    public class JPath : JRaw
	{
        private string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JPath" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JPath(string rawJson)
			: base(rawJson.Trim())
		{
            this._value = rawJson.Trim();
		}

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            writer.WriteRaw("\"");
            writer.WriteRaw(this._value);
            writer.WriteRaw("\" ");
        }

    }

}
