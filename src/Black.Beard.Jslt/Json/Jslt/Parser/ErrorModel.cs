namespace Bb.Json.Jslt.Parser
{

    public class ErrorModel
    {

        public ErrorModel()
        {

        }

        public string Message { get; set; }
        public string Text { get; internal set; }
        public int Column { get; internal set; }
        public int StartIndex { get; internal set; }
        public int Line { get; internal set; }
        public string Filename { get; internal set; }

        public SeverityEnum Severity { get; set; }

        public string Location => $"({Line}, {Column})";

        public override string ToString()
        {
            return Message.ToString();
        }

    }


    public enum SeverityEnum
    {
        Information = 0,
        Warning = 1,
        Error = 2,
    }


}
