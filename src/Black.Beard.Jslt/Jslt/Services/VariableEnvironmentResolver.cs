using System;
using Bb.Contracts;

namespace Bb.Jslt.Services
{
    /// <summary>
    /// Resolve variables by sources
    /// </summary>
    public class VariableEnvironmentResolver : VariableResolver
    {

        /// <summary>
        /// Initialize a new instance of SourceResolver
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="next"></param>
        public VariableEnvironmentResolver(EnvironmentVariableTarget target, IVariableResolver next = null)
            : base(next)
        {
            this._target = target;
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

            var items = Environment.GetEnvironmentVariables();

            if (items.Contains(key))
            {
                result = Environment.GetEnvironmentVariable(key, _target);
                return true;
            }

            return false;

        }

        private readonly EnvironmentVariableTarget _target;

    }


}
