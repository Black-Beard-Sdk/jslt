using Bb.Json.Jslt.Services;
using Oldtonsoft.Json.Linq;

namespace Bb.Contracts
{

    /// <summary>
    /// Contract for implementation of the custom service
    /// </summary>
    public interface ITransformJsonService
    {

        /// <summary>
        /// Method to execute by the process for convert to Json
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        JToken Execute(RuntimeContext ctx, JToken source);

    }

}
