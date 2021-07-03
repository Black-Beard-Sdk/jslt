//using Bb.Elastic.Runtimes;
//using Bb.Elastic.Runtimes.Models;
//using Bb.Elasticsearch.Configurations;
//using Bb.Exceptions;
//using Bb.Json.Attributes;
//using Bb.Json.Configurations;
//using Bb.Json.Jslt.Services;
//using Newtonsoft.Json.Linq;
//using System.ComponentModel;


//namespace Bb.Jslt.Services.Excels
//{

//    /// <summary>
//    /// get( "document name", 
//    /// </summary>
//    public static partial class Services
//    {

//        [JsltExtensionMethodParameter("connectionName", "connection name. if null or not specified in the configuration an exception is thrown.")]
//        [JsltExtensionMethodParameter("sql", "sql query to call elasticsearch")]
//        //[JsltExtensionMethodParameter("pagined", "if null or false, elastic is called just one time, if true all datas are fetch.")]
//        [JsltExtensionMethod("sqlelastic")]
//        public static JToken ExecuteElastic(RuntimeContext ctx, string connectionName, string sql/*, bool? pagined*/)
//        {

//            if (string.IsNullOrEmpty(sql))
//                return JValue.CreateNull();

//            var cnxs = new ElasticConnections();

//            var config = (ElasticConfiguration)Configurations.Instance.GetConfiguration(connectionName);

//            config.Append(cnxs);

//            var exec = cnxs[connectionName];

//            // exec.ExecuteQuery()
//            //if (!pagined.HasValue)
//            //    pagined = false;

//            // ElasticConnections configuration = new ElasticConnections();

//            //var exec = configuration.GetExecutor();

//            //var result = exec.Execute(new System.Text.StringBuilder(sql), string.Empty);

//            return JValue.CreateNull();

//        }

//    }


//}
