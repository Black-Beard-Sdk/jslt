namespace Bb.Contracts
{

    /// <summary>
    /// Contract for resolving variables
    /// </summary>
    public interface IVariableResolver
    {

        /// <summary>
        /// Try to resolve the variable
        /// </summary>
        /// <param name="key">variable name</param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool Get(string key, out object result);

        /// <summary>
        /// Set the next resolver
        /// </summary>
        /// <param name="resolver"></param>
        void SetNext(IVariableResolver resolver);

    }


}
