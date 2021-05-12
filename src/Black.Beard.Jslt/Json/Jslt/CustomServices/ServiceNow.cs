using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return the current date
    /// </summary>
    [DisplayName("now")]
    public class ServiceNow : ITransformJsonService
    {

        public ServiceNow()
        {

        }

        public bool Utc { get; set; } = false;

        public JToken Execute(RuntimeContext ctx, JToken token)
        {
            var n = Utc ? DateTime.UtcNow : DateTime.Now;
            return new JValue(n);
        }

    }

}
