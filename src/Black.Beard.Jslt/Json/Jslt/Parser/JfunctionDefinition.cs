using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.Parser
{

    /// <summary>
    /// Represents a raw JSON string.
    /// </summary>
    public class JfunctionDefinition : JProperty
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class.
		/// </summary>
		/// <param name="rawJson">The raw json.</param>
		public JfunctionDefinition(string functionName, JfunctionBodyDefinition body)
			: base(functionName, body)
		{
			
		}

    }

}
