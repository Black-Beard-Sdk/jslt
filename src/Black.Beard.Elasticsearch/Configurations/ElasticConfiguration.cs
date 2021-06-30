using Bb.Elastic.Runtimes.Models;
using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Elasticsearch.Configurations
{


    public class ElasticConfiguration
    {

        public ElasticConfiguration()
        {
            this.Uris = new List<string>();
            this.Authentication = new ElasticConfigurationLogin();
        }

        /// <summary>
        /// Name of the connectionString
        /// </summary>
        public string Name { get; set; }

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

        public List<string> Uris { get; set; }

        public ElasticConfigurationLogin Authentication { get; set; }

        /// <summary>
        /// Sets the default timeout in milliseconds for each request to Elasticsearch. Defaults to 60 seconds.
        /// NOTE: You can set this to a high value here, and specify a timeout on Elasticsearch's side.
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// The maximum number of retries for a given request
        /// </summary>
        public int MaximumRetries { get; set; }


        public void Append(ElasticConnections manager)
        {

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

            if (!string.IsNullOrEmpty(this.Authentication.Key1) && !string.IsNullOrEmpty(this.Authentication.Key2))
            {

                if (this.Authentication.Kind == ElasticConfigurationLoginKindEnum.Login)
                    settings.BasicAuthentication(this.Authentication.Key1, this.Authentication.Key2);

                if (this.Authentication.Kind == ElasticConfigurationLoginKindEnum.ApiKey)
                    settings.ApiKeyAuthentication(this.Authentication.Key1, this.Authentication.Key2);

            }

            manager.AddConnection(new ConnectionElastic(this.Name, new ElasticLowLevelClient(settings)));

        }

    }


}
