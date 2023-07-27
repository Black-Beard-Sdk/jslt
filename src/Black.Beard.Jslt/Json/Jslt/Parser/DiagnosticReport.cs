using System.Collections.Generic;

namespace Bb.Json.Jslt.Parser
{

    [System.Diagnostics.DebuggerDisplay("[{Severity}] {Message}")]
    public class DiagnosticReport
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticReport"/> class.
        /// </summary>
        /// <param name="locations">The locations.</param>
        public DiagnosticReport(params DiagnosticLocation[] locations) : this()
        {
            Locations.AddRange(locations);
        }

        public DiagnosticReport()
        {
            Locations = new List<DiagnosticLocation>();
        }

        //public string Filename { get; set; }

        //public int StartIndex { get; set; }

        //public int StartColumn { get; set; }

        //public int StartLine { get; set; }


        public List<DiagnosticLocation> Locations { get; set; }


        public string Text { get; set; }

        public string Message { get; set; }

        public string Severity { get; set; }

        public int SeverityLevel { get; set; }

        public bool IsSeverityAsError { get; internal set; }


        // public string Location => $"({StartLine}, {StartColumn})";

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


    public class DiagnosticLocation
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        public DiagnosticLocation()
        {

        }

        public DiagnosticLocation(string filename)
        {
            this.Filename = filename;
        }

        public DiagnosticLocation(string filename, int startIndex, int startline = -1, int startColumn = -1) : this(filename)
        {
            this.StartIndex = startIndex;
            this.StartLine = startline;
            this.StartColumn = startColumn;
        }

        public DiagnosticLocation(string filename, TokenLocation location) : this(filename)
        {
            Filename = filename;
            StartLine = location.Line;
            StartIndex = location.StartIndex;
            StartColumn = location.Column;
        }


        public string Filename { get; internal set; }


        public int StartIndex { get; internal set; }
        public int StartColumn { get; internal set; }
        public int StartLine { get; internal set; }



        public int EndIndex { get; internal set; }
        public int EndColumn { get; internal set; }
        public int EndLine { get; internal set; }



        public override string ToString()
        {
            var file = this.Filename ?? string.Empty;
            return $"{file} from (line {this.StartLine}, column {this.StartColumn}) to (line {this.EndLine}, column {this.EndColumn})";
        }

    }


}
