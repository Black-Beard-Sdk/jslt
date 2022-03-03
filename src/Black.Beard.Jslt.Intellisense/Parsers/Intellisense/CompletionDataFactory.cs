namespace Bb.Parsers.Intellisense
{
    public class CompletionDataFactory
    {

        public CompletionDataFactory(params string[] names)
        {
            this.Names = names;
        }


        public string[] Names { get; }


        internal void Populate(IntellisenseKey key, CompletionResult result)
        {
            if (this._action == null)
                throw new NullReferenceException("Please intialize the provider with the method SetAction");

            this._action(key, result);
        }

        public CompletionDataFactory SetAction(Action<IntellisenseKey, CompletionResult> action)
        {
            this._action = action;
            return this;
        }

        private Action<IntellisenseKey, CompletionResult> _action;

    }

}
