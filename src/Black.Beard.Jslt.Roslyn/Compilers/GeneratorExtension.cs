using Bb.Compilers.Exceptions;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bb.Compilers
{

    public static class GeneratorExtension
    {


        public static DiagnosticResult Map(this Diagnostic self)
        {

            return new DiagnosticResult()
            {
                Locations = GetLocations(self),
                Id = self.Id,
                Message = self.GetMessage(),
                IsWarningAsError = self.IsWarningAsError,
                Severity = self.Severity.ToString(),
                WarningLevel = self.WarningLevel,
            };
            
        }

        private static List<LocationResult> GetLocations(Diagnostic self)
        {

            List<LocationResult> result = new List<LocationResult>(self.AdditionalLocations.Count + 1)
            {
                Map(self.Location)
            };

            foreach (var item in self.AdditionalLocations)
                result.Add(Map(item));

            return result;

        }

        private static LocationResult Map(Location location)
        {

            var lineSpan = location.GetLineSpan();
            return new LocationResult()
            {
                FilePath = location?.SourceTree?.FilePath ?? string.Empty,

                StartCharacter = location?.SourceSpan.Start ?? 0,
                StartLine = lineSpan.StartLinePosition.Line + 1,
                StartColumn = lineSpan.StartLinePosition.Character,

                EndCharacter = location?.SourceSpan.End ?? 0,
                EndLine = lineSpan.EndLinePosition.Line + 1,
                EndColumn = lineSpan.EndLinePosition.Character,

            };

        }


        /// <summary>
        /// emit the compilation result into a byte array 
        /// </summary>
        /// <param name="compilation"></param>
        /// <returns></returns>
        /// <exception cref="CompilerException">throw an exception with corresponding message if there are errors</exception>
        public static byte[] EmitToArray(this Compilation compilation, DiagnosticSeverity severity, out CompilerException exception)
        {

            using (var stream = new MemoryStream())
            {
                // emit result into a stream
                var emitResult = compilation.Emit(stream);

                if (emitResult.Diagnostics.Any())
                {

                    exception = new CompilerException(emitResult.Diagnostics.ToArray());
                    System.Diagnostics.Trace.WriteLine(exception, System.Diagnostics.TraceLevel.Warning.ToString());

                    switch (severity)
                    {

                        case DiagnosticSeverity.Info:
                            if (exception.HaveInfo)
                                throw exception;
                            break;

                        case DiagnosticSeverity.Warning:
                            if (exception.HaveWarning)
                                throw exception;
                            break;

                        case DiagnosticSeverity.Error:
                            if (exception.HaveError)
                                throw exception;
                            break;

                        case DiagnosticSeverity.Hidden:
                        default:
                            break;

                    }
                }
                else
                    exception = null;

                // get the byte array from a stream
                return stream.ToArray();

            }
        }


    }

}
