using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{

    public class JChained : JArray
    {

        public JChained()
        {

        }

        public JChained(JChained other) : base (other)
        {

        }
 
        public JChained(params object[] content) : base (content)
        {

        }
 
        public JChained(object content) : base(content)
        {

        }

    }

}
