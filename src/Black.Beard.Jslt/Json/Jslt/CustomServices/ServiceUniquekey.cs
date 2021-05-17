using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{
    /// <summary>
    /// return a sub part of the initial Text from the 'start' position and from length 'Lenght'
    /// </summary>
    [JsltExtensionMethod("id")]
    public class ServiceUniquekey : ITransformJsonService
    {

        public ServiceUniquekey()
        {

        }



        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token is JValue v && v.Value != null)
            {
                
                var value = v.Value.ToString();

                StringBuilder sb = new StringBuilder(value.Length + 2);
                char old = '\0';
                for (int i = 0; i < value.Length; i++)
                {

                    var c = value[i];

                    if (_availables.Contains(c))
                        sb.Append(c.ToString().ToLowerInvariant());

                    old = c;

                }

                var id = (long)Crc32.Calculate(sb.ToString());
                return new JValue(id.ToString());

            }

            return token;

        }

        private HashSet<char> _availables = new HashSet<char>() 
        { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','0','1','2','3','4','5','6','7','8','9' };

    }

}
