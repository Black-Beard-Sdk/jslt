namespace Bb.Json.Jslt.Parser
{

    public class ErrorModel
    {

        public ErrorModel()
        {

        }

        public string Message { get; set; }
        public string Text { get; set; }
        public int Column { get; set; }
        public int StartIndex { get; set; }
        public int Line { get; set; }
        public string Filename { get; set; }

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
