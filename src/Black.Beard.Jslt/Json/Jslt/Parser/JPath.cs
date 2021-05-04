using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{


    /// <summary>
    /// Represents a raw JSON string.
    /// </summary>
    public class JPath : JRaw
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class.
		/// </summary>
		/// <param name="rawJson">The raw json.</param>
		public JPath(string rawJson)
			: base(rawJson)
		{
		}

	}

}
