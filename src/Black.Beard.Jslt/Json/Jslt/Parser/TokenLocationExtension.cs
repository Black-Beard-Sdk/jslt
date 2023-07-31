using Antlr4.Runtime;
using Bb.Analysis;
using Bb.Compilers;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Bb.Json.Jslt.Parser
{

    public static class TokenLocationExtension
    {


        public static TokenLocation ToLocation(this IToken self, IToken stop)
        {
            return new TokenLocation(new CodeLocation(self.Line, self.Column, self.StartIndex), new CodeLocation(stop.Line, stop.Column, stop.StopIndex));
        }

        public static TokenLocation ToLocation(this IToken self)
        {
            return new TokenLocation(self.StartIndex, self.StopIndex, self.Line, self.Column);
        }


        public static void AddError(this Diagnostics self, string sourceCode, TokenLocation start, string context, string message)
        {
            self.AddError(new DiagnosticLocation(sourceCode, (CodeLocation)start.Start.Clone(), (CodeLocation)start.End.Clone()), context, message);
        }

        public static void AddWarning(this Diagnostics self, string sourceCode, TokenLocation start, string context, string message)
        {
            self.AddWarning(new DiagnosticLocation(sourceCode, (CodeLocation)start.Start.Clone(), (CodeLocation)start.End.Clone()), context, message);
        }

        public static void AddInformation(this Diagnostics self, string sourceCode, TokenLocation start, string context, string message)
        {
            self.AddInformation(new DiagnosticLocation(sourceCode, (CodeLocation)start.Start.Clone(), (CodeLocation)start.End.Clone()), context, message);
        }

    }

    [DebuggerDisplay("{StartIndex}, {StopIndex} : ({Line},{Column})")]
    public class TokenLocation : DiagnosticLocation
    {

        public static TokenLocation Empty => new TokenLocation(DiagnosticLocation.Empty);

        public string Function { get; set; }

        public TokenLocation(CodeLocation start, CodeLocation @end) : base(string.Empty, start, end)
        {

        }


        public TokenLocation(int start, int end, int line, int column) : base(string.Empty, new CodeLocation(line, column, start), new CodeLocation(-1, -1, end))
        {
            
        }

        public TokenLocation(DiagnosticLocation location) : base(location)
        {

        }

        public TokenLocation Clone()
        {
            return new TokenLocation(Start.Index, End.Index, Start.Line, Start.Column)
            {
                Function = Function
            };
        }
    }


}
