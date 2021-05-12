using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Compilers.Exceptions
{


    [Serializable]
    public class CompilerException : Exception
    {

        public CompilerException(Microsoft.CodeAnalysis.Diagnostic[] diagnostics) : this(
               GetMessage(diagnostics, DiagnosticSeverity.Error) 
            ?? GetMessage(diagnostics, DiagnosticSeverity.Warning) 
            ?? GetMessage(diagnostics, DiagnosticSeverity.Info))
        {

            this.Diagnostics = diagnostics;

            this.Infos = diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Info).ToArray();
            this.Warnings = diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Warning).ToArray();
            this.Errors = diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Error).ToArray();

            this.HaveInfo = Infos.Any();
            this.HaveWarning = Warnings.Any();
            this.HaveError = Errors.Any();

        }

        private static string GetMessage(Microsoft.CodeAnalysis.Diagnostic[] diagnostics, DiagnosticSeverity severity)
        {
            var diagnostic = diagnostics.FirstOrDefault(diag => diag.Severity == severity);
            return diagnostic?.GetMessage() ?? null;
        }

        public CompilerException(string message) : base(message) { }

        public Diagnostic[] Diagnostics { get; }
        public Diagnostic[] Infos { get; }
        public Diagnostic[] Warnings { get; }
        public Diagnostic[] Errors { get; }
        public bool HaveInfo { get; }
        public bool HaveWarning { get; }
        public bool HaveError { get; }

        protected CompilerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }

}
