//using Bb.Elastic.Runtimes;
//using Bb.Elastic.Runtimes.Models;
//using Bb.Elasticsearch.Configurations;
//using Bb.Exceptions;
//using Bb.Attributes;
//using Bb.Jslt.Services;
//using Bb.Json.Linq;
//using System.ComponentModel;


//namespace Bb.Jslt.Services.Excels
//{

//    /// <summary>
//    /// get( "document name", 
//    /// </summary>
//    public static partial class Services
//    {

//        [JsltExtensionMethodParameter("connectionName", "connection name. if null or not specified in the configuration an exception is thrown.")]
//        [JsltExtensionMethodParameter("query", "sql query to call elasticsearch")]
//        //[JsltExtensionMethodParameter("pagined", "if null or false, elastic is called just one time, if true all datas are fetch.")]
//        [JsltExtensionMethod("elastic")]
//        public static JToken ExecuteElastic(RuntimeContext ctx, string connectionName, string index, JObject query)
//        {


//            var cnxList = new ConfigurationList();
//            var configuration = new ElasticConfiguration("http://elasticsearch-rest.local")
//            {
//                Name = "srv1",
//                EnableDebugMode = true,
//                ThrowExceptions = true,
//                PrettyJson = true,
//            };

//            cnxList.Add(configuration);

//            var cnxs = cnxList.GetElasticConnections();

//            var e = cnxs.GetExecutor();

//            var responses2 = e.Execute(query, "local file", index, connectionName);

//            return JValue.CreateNull();

//        }

//    }


//}
