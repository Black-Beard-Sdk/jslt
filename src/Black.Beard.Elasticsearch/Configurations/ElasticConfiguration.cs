using Bb.Elastic.Runtimes.Models;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Elasticsearch.Configurations
{


    public class ElasticConfiguration : BaseConfiguration
    {

        public ElasticConfiguration(params string[] uris): this()
        {
            foreach (var item in uris)
                this.Uris.Add(item);
        }

        public ElasticConfiguration()
        {
            this.Uris = new List<string>();
        }

        public List<string> Uris { get; set; }

        /// <summary>
        /// Turns on settings that aid in debugging like DisableDirectStreaming() and PrettyJson()
        /// so that the original request and response JSON can be inspected. It also always
        /// asks the server for the full stack trace on errors
        /// </summary>
        public bool EnableDebugMode { get; set; }

        /// <summary>
        /// Instead of following a c/go like error checking on response.IsValid do throw
        /// an exception (except when Elasticsearch.Net.IApiCallDetails.SuccessOrKnownError
        /// is false) on the client when a call resulted in an exception on either the client
        /// or the Elasticsearch server.
        /// Reasons for such exceptions could be search parser errors, index missing exceptions,
        /// etc...
        /// </summary>
        public bool ThrowExceptions { get; set; }

        /// <summary>
        /// Forces all requests to have ?pretty=true querystring parameter appended, causing
        /// Elasticsearch to return formatted JSON. Defaults to false
        /// </summary>
        public bool PrettyJson { get; set; }

        /// <summary>
        /// Limits the number of concurrent connections that can be opened to an endpoint.
        /// Defaults to 80 for all IConnection implementations that are not based on System.Net.Http.CurlHandler.
        /// For those based on System.Net.Http.CurlHandler, defaults to Environment.ProcessorCount.
        /// For Desktop CLR, this setting applies to the DefaultConnectionLimit property
        /// on the ServicePointManager object when creating ServicePoint objects, affecting
        /// the default Elasticsearch.Net.IConnection implementation.
        /// For Core CLR, this setting applies to the MaxConnectionsPerServer property on
        /// the HttpClientHandler instances used by the HttpClient inside the default Elasticsearch.Net.IConnection
        /// implementation
        /// </summary>
        public int ConnectionLimit { get; set; }

        /// <summary>
        /// Sets the default timeout in milliseconds for each request to Elasticsearch. Defaults to 60 seconds.
        /// NOTE: You can set this to a high value here, and specify a timeout on Elasticsearch's side.
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// The maximum number of retries for a given request
        /// </summary>
        public int MaximumRetries { get; set; }


        public string AuthenticationKey1 { get; set; }

        public string AuthenticationKey2 { get; set; }

        public ElasticConfigurationLoginKindEnum AuthenticationKind { get; set; }


        internal override void Append(object list)
        {

            ElasticConnectionList manager = (ElasticConnectionList)list;

            var nodes = Uris.Select(c => new Uri(c)).ToArray();
            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);

            if (this.EnableDebugMode)
                settings.EnableDebugMode();

            settings.ThrowExceptions(alwaysThrow: this.ThrowExceptions); // I like exceptions

            if (this.PrettyJson)
                settings.PrettyJson(); // Good for DEBUG

            if (this.ConnectionLimit > 0)
                settings.ConnectionLimit(this.ConnectionLimit);

            if (this.TimeOut > 0)
                settings.RequestTimeout(new TimeSpan(0, 0, 0, 0, this.TimeOut));

            if (this.MaximumRetries > 0)
                settings.MaximumRetries(maxRetries: MaximumRetries);

            if (!string.IsNullOrEmpty(this.AuthenticationKey1) && !string.IsNullOrEmpty(this.AuthenticationKey2))
            {

                if (this.AuthenticationKind == ElasticConfigurationLoginKindEnum.Login)
                    settings.BasicAuthentication(this.AuthenticationKey1, this.AuthenticationKey2);

                if (this.AuthenticationKind == ElasticConfigurationLoginKindEnum.ApiKey)
                    settings.ApiKeyAuthentication(this.AuthenticationKey1, this.AuthenticationKey2);

            }

            manager.AddConnection(new ElasticProcessor(this.Name, new ElasticLowLevelClient(settings)));

        }


    }


}
