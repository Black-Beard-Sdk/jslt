using Antlr4.Runtime.Tree;

namespace Bb.Elastic.Runtimes
{

    public class ResultMessageModel
    {

        public ResultMessageModel()
        {

        }

        public string Message { get; set; }

        public string Text { get; set; }

        public Locator Position {get;set;}

        public ResultMessageModelEnum Code { get; set; }

        public ResultMessageModelSeverityEnum Severity { get; set; }

        public override string ToString()
        {
            return Message.ToString();
        }

    }

    public enum ResultMessageModelEnum
    {
        Undefined,
        SyntaxtError,
    }

    public enum ResultMessageModelSeverityEnum
    {
        Undefined,
        Error,
        Warning,
        Infomation,
        Verbose,
        Debug,
    }


    public class Locator
    {

        public Locator()
        {

        }

        public Locator(Antlr4.Runtime.ParserRuleContext e)
        {
            
            Line = e.Start.Line;
            StartIndex = e.Start.StartIndex;
            Column = e.Start.Column;
            Length = e.Stop.StopIndex - e.Start.StartIndex;
        }

        public Locator(ITerminalNode e)
        {
            Line = e.Symbol.Line;
            StartIndex = e.Symbol.StartIndex;
            Column = e.Symbol.Column;
            Length = e.Symbol.StopIndex - e.Symbol.StartIndex;
        }

        public int Column { get; set; }
        public int Length { get; set; }
        public int StartIndex { get; set; }
        public int Line { get; set; }
        public string Filename { get; set; }

    }

}
