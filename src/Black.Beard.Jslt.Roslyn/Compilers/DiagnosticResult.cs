using System.Collections.Generic;

namespace Bb.Compilers
{

    [System.Diagnostics.DebuggerDisplay("[{Severity}] {Message}")]
    public class DiagnosticResult
    {
        public List<LocationResult> Locations { get; internal set; }
        public string Message { get; internal set; }
        public int WarningLevel { get; internal set; }
        public string Severity { get; internal set; }
        public bool IsWarningAsError { get; internal set; }
        public string Id { get; internal set; }
    }


}
