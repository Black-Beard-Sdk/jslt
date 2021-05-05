using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.Services
{

    /// <summary>
    /// Contract for implémentation of the custom service
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
