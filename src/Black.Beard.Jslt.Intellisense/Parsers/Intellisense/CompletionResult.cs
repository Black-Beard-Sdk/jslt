namespace Bb.Parsers.Intellisense
{

    public class CompletionResult : List<CompletionData>
    {
        public List<Exception> Exceptions { get; internal set; }
    }

}
