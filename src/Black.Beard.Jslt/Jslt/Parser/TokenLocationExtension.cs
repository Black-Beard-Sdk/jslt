using Antlr4.Runtime;
using Bb.Analysis.DiagTraces;

namespace Bb.Jslt.Parser
{

    public static class TextLocationExtension
    {

         /// <summary>
         /// return the location of the parserRuleContext
         /// </summary>
         /// <param name="self"></param>
         /// <returns></returns>
        public static TextLocation ToLocation(this ParserRuleContext self)
        {
            var start = self.Start;
            var stop = self.Stop;
            return new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>((start.Line, start.Column, start.StartIndex), (stop.Line, stop.Column, stop.StopIndex));
        }

        /// <summary>
        /// Return the location of the token
        /// </summary>
        /// <param name="self"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public static TextLocation ToLocation(this IToken self, IToken stop)
        {
            return new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>((self.Line, self.Column, self.StartIndex), (self.Line, self.Column, self.StopIndex));
        }

        /// <summary>
        /// Return the location of the token
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, LocationIndex> ToLocation(this IToken self)
        {
            return new SpanLocation<LocationLineAndIndex, LocationIndex>((self.Line, self.Column, self.StartIndex), self.StopIndex);
        }

        /// <summary>
        /// Return the location of the token
        /// </summary>
        /// <param name="self"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, LocationIndex> ToLocation(this IToken self, string documentName)
        {
            return new SpanLocation<LocationLineAndIndex, LocationIndex>((self.Line, self.Column, self.StartIndex), self.StopIndex) { Filename = documentName };
        }

        /// <summary>
        /// Return the location of the token
        /// </summary>
        /// <param name="self"></param>
        /// <param name="endPosition"></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, LocationIndex> ToLocation(this IToken self, int endPosition)
        {
            return new SpanLocation<LocationLineAndIndex, LocationIndex>((self.Line, self.Column, self.StartIndex), endPosition);
        }

        /// <summary>
        /// Add an error to the diagnostics
        /// </summary>
        /// <param name="self"></param>
        /// <param name="sourceCode"></param>
        /// <param name="start"></param>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public static void AddError(this ScriptDiagnostics self, string? sourceCode, TextLocation start, string context, string message)
        {
            self.AddError(start, context, message);
        }

        public static void AddWarning(this ScriptDiagnostics self, string? sourceCode, TextLocation start, string context, string message)
        {
            self.AddWarning(start, context, message);
        }

        public static void AddInformation(this ScriptDiagnostics self, string? sourceCode, TextLocation start, string context, string message)
        {
            self.AddInformation(start, context, message);
        }

    }

}
