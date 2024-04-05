using Bb.Contracts;

namespace Bb.Jslt.Services
{

    /// <summary>
    /// Resolve variables by sources
    /// </summary>
    public class VariableSourceResolver : VariableResolver
    {

        /// <summary>
        /// Initialize a new instance of SourceResolver
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="next"></param>
        public VariableSourceResolver(Sources sources, IVariableResolver next = null) 
            : base(next)
        {
            this._sources = sources;
        }

        /// <summary>
        /// Try to resolve the variable
        /// </summary>
        /// <param name="key">variable name</param>
        /// <param name="result">value resolved</param>
        /// <returns></returns>
        protected override bool GetImpl(string key, out object result)
        {
            
            result = null;

            if (this._sources.TryGetValue(key, out var source1))
            {
                result = source1;
                return true;
            }

            return false;

        }

        private readonly Sources _sources;

    }


}
