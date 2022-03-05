namespace Bb.Parsers.Intellisense
{
    public class CompletionDataFactory
    {

        public CompletionDataFactory(params string[] names)
        {
            this.Names = names;
        }


        public string[] Names { get; }

        public Exception Exception { get; private set; }

        internal void Populate(IntellisenseKey key, CompletionResult result)
        {

            Exception = null;

            if (this._action == null)
                throw new NullReferenceException("Please intialize the provider with the method SetAction");

            try
            {
                this._action(key, result);
            }
            catch (Exception ex)
            {
                this.Exception = ex;
            }
        }

        public CompletionDataFactory SetAction(Action<IntellisenseKey, CompletionResult> action)
        {
            this._action = action;
            return this;
        }

        private Action<IntellisenseKey, CompletionResult> _action;

    }

}
