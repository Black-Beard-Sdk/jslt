using Antlr4.Runtime;
using Bb.Analysis;
using Bb.Analysis.Traces;
using Bb.Compilers;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Bb.Json.Jslt.Parser
{

    public static class TextLocationExtension
    {

         
        public static TextLocation ToLocation(this ParserRuleContext self)
        {
            var start = self.Start;
            var stop = self.Stop;
            return new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>((start.Line, start.Column, start.StartIndex), (stop.Line, stop.Column, stop.StopIndex));
        }

        public static TextLocation ToLocation(this IToken self, IToken stop)
        {
            return new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>((self.Line, self.Column, self.StartIndex), (self.Line, self.Column, self.StopIndex));
        }

        public static SpanLocation<LocationLineAndIndex, LocationIndex> ToLocation(this IToken self)
        {
            return new SpanLocation<LocationLineAndIndex, LocationIndex>((self.Line, self.Column, self.StartIndex), self.StopIndex);
        }

        public static SpanLocation<LocationLineAndIndex, LocationIndex> ToLocation(this IToken self, string documentName)
        {
            return new SpanLocation<LocationLineAndIndex, LocationIndex>((self.Line, self.Column, self.StartIndex), self.StopIndex) { Filename = documentName };
        }

        public static SpanLocation<LocationLineAndIndex, LocationIndex> ToLocation(this IToken self, int endPosition)
        {
            return new SpanLocation<LocationLineAndIndex, LocationIndex>((self.Line, self.Column, self.StartIndex), endPosition);
        }


        public static void AddError(this ScriptDiagnostics self, string sourceCode, TextLocation start, string context, string message)
        {
            self.AddError(start, context, message);
        }

        public static void AddWarning(this ScriptDiagnostics self, string sourceCode, TextLocation start, string context, string message)
        {
            self.AddWarning(start, context, message);
        }

        public static void AddInformation(this ScriptDiagnostics self, string sourceCode, TextLocation start, string context, string message)
        {
            self.AddInformation(start, context, message);
        }

    }

}
