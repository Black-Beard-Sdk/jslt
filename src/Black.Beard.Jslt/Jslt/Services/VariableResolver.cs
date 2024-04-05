using Bb.Contracts;
using System;

namespace Bb.Jslt.Services
{

    /// <summary>
    /// Store of variables
    /// </summary>
    public abstract class VariableResolver : IVariableResolver
    {


        /// <summary>
        /// Initialize a new instance of VariableResolver
        /// </summary>
        public VariableResolver(IVariableResolver next = null)
        {
            if (next != null)
                this._next = next;
        }

        /// <summary>
        /// Resolve the variable
        /// </summary>
        /// <param name="key">variable name</param>
        /// <param name="result">data result</param>
        /// <returns></returns>
        public virtual bool Get(string key, out object result)
        {

            if (GetImpl(key, out result))
            {

                if (Intercept != null)
                    Intercept(this, key, true, result);

                return true;

            }

            if (Intercept != null)
                Intercept(this, key, false, result);

            if (_next != null)
                return _next.Get(key, out result);

            return false;

        }

        /// <summary>
        /// real implementation
        /// </summary>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected abstract bool GetImpl(string key, out object result);

        /// <summary>
        /// Set the next resolver
        /// </summary>
        /// <param name="resolver"></param>
        public void SetNext(IVariableResolver resolver)
        {
            if (this._next == null)
                this._next = resolver;
            else
                this._next.SetNext(resolver);
        }


        public static Action<IVariableResolver, string, bool, object> Intercept { get; set;}


        private IVariableResolver _next;

    }


}
