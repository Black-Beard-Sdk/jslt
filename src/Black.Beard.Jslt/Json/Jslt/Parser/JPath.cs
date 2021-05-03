using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{


    /// <summary>
    /// Represents a raw JSON string.
    /// </summary>
    public class JPath : JRaw
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class from another <see cref="T:Newtonsoft.Json.Linq.JRaw" /> object.
		/// </summary>
		/// <param name="other">A <see cref="T:Newtonsoft.Json.Linq.JRaw" /> object to copy from.</param>
		public JPath(JRaw other)
			: base(other)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class.
		/// </summary>
		/// <param name="rawJson">The raw json.</param>
		public JPath(object? rawJson)
			: base(rawJson)
		{
		}

	}

}
