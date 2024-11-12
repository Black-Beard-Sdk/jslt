using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Jslt.Services
{

    /// <summary>
    /// Source to append in the transformation process.
    /// </summary>
    public class Sources
    {

        public Sources(EnvironmentVariableTarget target = EnvironmentVariableTarget.Machine) 
            : this(null, EnvironmentVariableTarget.Machine)
        {

        }

        /// <summary>
        /// Initialize a new instance of Sources
        /// </summary>
        /// <param name="source">Source to append in global source</param>
        /// <param name="target"></param>
        public Sources(SourceJson? source, EnvironmentVariableTarget target = EnvironmentVariableTarget.Machine)
        {

            this.Source = source;

            if (source != null && !string.IsNullOrEmpty(source.Name))
                this._datas = new Dictionary<string, SourceJson>() { { source.Name, source } };
            else
                this._datas = new Dictionary<string, SourceJson>();

            this.Variables = new VariableManager(new VariableSourceResolver(this, new VariableEnvironmentResolver(target)));
        }

        /// <summary>
        /// return a new empty source
        /// </summary>
        /// <returns></returns>
        public static Sources GetEmpty()
        {
            return new Sources(SourceJson.GetFromText(String.Empty));
        }

        /// <summary>
        /// Principal source
        /// </summary>
        public SourceJson Source { get; private set; }

        /// <summary>
        /// Append the source. Note if the source haven't name, the source is write in the principal source.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Sources Add(SourceJson source)
        {
            if (string.IsNullOrEmpty(source.Name))
                Source = source;
            this._datas.Add(source.Name, source);
            return this;
        }

        public bool TryGetValue(string key, out object source)
        {
            source = null;

            if (this._datas.TryGetValue(key, out var s))
                source = s.Datas;

            return source != null;

        }

        /// <summary>
        /// return source by specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SourceJson this[string name]
        {
            get
            {
                if (name == null)
                    return this.Source;

                return _datas[name];
            }
        }

        /// <summary>
        /// Variable manager <see cref="VariableManager "/>
        /// </summary>
        public VariableManager Variables { get; }

        #region operators

        public static implicit operator Sources(StringBuilder sb)
        {
            return new Sources(sb);
        }


        public static implicit operator Sources(string payload)
        {
            return new Sources(payload);
        }


        public static implicit operator Sources(JToken datas)
        {
            return new Sources(datas);
        }


        public static implicit operator Sources(FileInfo file)
        {
            return new Sources(file);
        }


        public static implicit operator Sources(SourceJson datas)
        {
            return new Sources(datas);
        }


        private readonly Dictionary<string, SourceJson> _datas;

        #endregion operators

    }

}
