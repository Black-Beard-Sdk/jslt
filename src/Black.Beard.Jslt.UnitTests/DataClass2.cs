using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Black.Beard.Jslt.UnitTests
{

    [DisplayName("mult")]
    public class DataClass2 : ITransformJsonService
    {

        public DataClass2(double id1, double id2)
        {
            this.Id1 = id1;
            this.Id2 = id2;
        }

        public double Id1 { get; set; }

        public double Id2 { get; set; }

        public JToken Execute(RuntimeContext ctx, JToken source)
        {
            return new JValue(Id1 * Id2);
        }

    }

}