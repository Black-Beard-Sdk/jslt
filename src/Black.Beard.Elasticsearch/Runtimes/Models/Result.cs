using Elasticsearch.Net;

namespace Bb.Elastic.Runtimes.Models
{

    public class Result<TResponse> : Result
         where TResponse : class, new()
    {
        public RequestQuery Request { get;  set; }
        public new TResponse Datas 
        {
            get
            {
                return (TResponse)base.Datas;
            }
            set
            {
                base.Datas = (TResponse)value;
            }
        }
    }


    public class Result
    {

        public object Datas { get; set; }

        public T GetDatas<T>()
        {
            return (T)Datas;
        }


    }


}