namespace Bb.Elasticsearch.Configurations
{
    public abstract class BaseConfiguration
    {

        /// <summary>
        /// Name of the connectionString
        /// </summary>
        public string Name { get; set; }

        internal abstract void Append(object list);

    }


}
