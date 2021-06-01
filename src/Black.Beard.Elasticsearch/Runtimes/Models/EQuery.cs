using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace Bb.Elastic.Runtimes.Models
{


    public class EQuery : ESerialize
    {

        public EBool Bool { get; set; }

        public override JToken Serialize()
        {

            return new JObject()
            {
                new JProperty("bool", Bool.Serialize())
            };

        }

    }


    public class EMust : ESerialize
    {
        public override JToken Serialize()
        {
            throw new System.NotImplementedException();
        }
    }

    public class EShould : ESerialize
    {
        public override JToken Serialize()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ERange : ESerialize
    {

        public ERange()
        {
        }

        public string Name { get; set; }

        public ETerm value { get; set; }

        public override JToken Serialize()
        {
            throw new System.NotImplementedException();
        }

    }

}