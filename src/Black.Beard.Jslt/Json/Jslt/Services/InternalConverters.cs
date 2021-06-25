using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Json.Jslt.Services
{
    
    public static class InternalConverters
    {


        public static string ToString (JToken self)
        {
            
            if (self is JValue v)
                return v.ToString();
            ;
            return self.ToString();

        }


    }
}
