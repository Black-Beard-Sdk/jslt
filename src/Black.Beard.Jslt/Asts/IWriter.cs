namespace Bb.Asts
{
    public interface IWriter
    {

        bool ToString(Writer writer, StrategySerializationItem strategy);

        public string RuleName { get; }

    }


}
