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
            return new TokenLocation(new CodePositionLocation(self.Line, self.Column, self.StartIndex), new CodePositionLocation(stop.Line, stop.Column, stop.StopIndex));
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

    [DebuggerDisplay("{Start.Index}, {Stop.Index} : ({Line},{Column})")]
    public class TokenLocation : DiagnosticLocation
    {

        public static TokenLocation Empty => new TokenLocation(DiagnosticLocation.Empty);

        public string Function { get; set; }

        public TokenLocation(CodePositionLocation start, CodePositionLocation @end) : base(string.Empty, start, end)
        {

        }


        public TokenLocation(int start, int end, int line, int column) : base(string.Empty, new CodePositionLocation(line, column, start), new CodePositionLocation(-1, -1, end))
        {
            
        }

        public TokenLocation(DiagnosticLocation location) : base(location)
        {

        }

        public TokenLocation Clone()
        {
            var s = (Start as CodePositionLocation);
            var e = (End as CodePositionLocation);
            return new TokenLocation(s.Index, e?.Index ?? 0, s.Line, s.Column)
            {
                Function = Function
            };
        }
    
    }


}
