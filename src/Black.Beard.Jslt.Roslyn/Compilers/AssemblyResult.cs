using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Bb.Compilers
{

    [System.Diagnostics.DebuggerDisplay("{AssemblyName}")]
    public class AssemblyResult
    {

        public AssemblyResult()
        {
            Disgnostics = new List<DiagnosticResult>();
            this.Documents = new List<string>();
        }

        public string AssemblyName { get; internal set; }

        public string AssemblyFile { get; internal set; }

        public string AssemblyFilePdb { get; internal set; }

        public List<DiagnosticResult> Disgnostics { get; internal set; }
        public List<string> Documents { get; }

        public bool Success { get; internal set; }

        public Exception Exception { get; internal set; }

        public Assembly LoadAssembly()
        {

            Trace.WriteLine($"Loading assembly {AssemblyFile}");
            var data = File.ReadAllBytes(AssemblyFile);
            var pdbData = File.ReadAllBytes(AssemblyFilePdb);
            var assembly = Assembly.Load(data, pdbData);
            // return Assembly.LoadFile(AssemblyFile);

            return assembly;

        }
    }


}
