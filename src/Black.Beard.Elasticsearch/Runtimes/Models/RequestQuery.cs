namespace Bb.Elastic.Runtimes.Models
{
    public class RequestQuery
    {

        public object Query { get; set; }
        public string Table { get;  set; }
        public Connection Connection { get; set; }

    }


}