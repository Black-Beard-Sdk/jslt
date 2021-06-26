using Bb.ComponentModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bb.Compilers
{

    public class RoslynCompiler
    {


        public RoslynCompiler(HashSet<Assembly> assemblies)
        {

            assemblies.Add(typeof(System.Object).Assembly);
            assemblies.Add(typeof(System.ComponentModel.DescriptionAttribute).Assembly);

            var ass = new string[] { "netstandard", "mscorlib", "System.Runtime" };

            foreach (var item in ass)
            {
                var a = item.ResolveAssemblyByName();
                if (a != null)
                    assemblies.Add(a);
            }

            _defaultReferences = new List<MetadataReference>();
            foreach (Assembly assembly in assemblies)
                AddReference(assembly);

        }

        #region Methods

        public RoslynCompiler AddCodeSource(string source, string path = null)
        {
            this._sources.Add(new FileCode() { Content = source, Filepath = path ?? string.Empty });
            this._hash ^= Crc32.Calculate(source);
            return this;
        }

        public RoslynCompiler AddReference(string location)
        {
            PortableExecutableReference newReference = AssemblyMetadata.CreateFromFile(location).GetReference();
            if (_assemblies.Add(newReference.FilePath))
                _defaultReferences.Add(newReference);
            return this;
        }

        public RoslynCompiler AddReference(Type type)
        {
            if (!string.IsNullOrEmpty(type.Namespace))
                _namespaces.Add(type.Namespace);
            AddReference(type.Assembly);
            return this;
        }

        public RoslynCompiler AddReference(Assembly assembly)
        {
            var newReference = AssemblyMetadata.CreateFromFile(assembly.Location).GetReference();
            if (_assemblies.Add(assembly.Location))
                _defaultReferences.Add(newReference);
            return this;
        }

        public RoslynCompiler SetOutput(string outputPah)
        {
            this._outputPah = outputPah;
            return this;
        }

        public AssemblyResult Generate()
        {

            var date = DateTime.Now;
            this._assemblyName = $"assembly_{this._hash}_{date.Year}{date.Month}{date.Day}_{date.Hour}{date.Minute}{date.Second}";

            AssemblyResult result = GetAssemblyResult();

            ResetFilesIfExists(result);

            var parsedSyntaxTree = Parse(result);
            CSharpVisitor visitor = new CSharpVisitor();
            foreach (var item in parsedSyntaxTree)
                visitor.Visit(item.GetRoot());
            var usings = visitor.GetUsings();

            var _references = ResolveAsemblies(usings);

            CSharpCompilationOptions DefaultCompilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true)

                    .WithOptimizationLevel(System.Diagnostics.Debugger.IsAttached
                        ? Microsoft.CodeAnalysis.OptimizationLevel.Debug
                        : Microsoft.CodeAnalysis.OptimizationLevel.Release)

                    .WithPlatform(Platform.AnyCpu)

                    .WithModuleName($"{_assemblyName}.dll")

                    //.WithUsings(repository.Usings)

                    ;

            var compilation = CSharpCompilation.Create
                (
                    result.AssemblyName,
                     parsedSyntaxTree,
                    _references,
                    DefaultCompilationOptions
                );

            try
            {

                // emit the compilation result to a byte array corresponding to {AssemblyName}.netmodule byte code
                //byte[] compilationAResult = compilation.EmitToArray(DiagnosticSeverity.Error, out CompilerException exception);
                //Assembly newAssembly = Assembly.Load(compilationAResult);

                using (var peStream = File.Create(result.AssemblyFile))
                using (var pdbStream = File.Create(result.AssemblyFilePdb))
                {

                    EmitResult resultEmit = compilation.Emit(peStream, pdbStream);
                    var diags = resultEmit.Diagnostics.ToList().Select(c => c.ToString()).ToArray();
                    
                    Trace.WriteLine(
                        new
                        {
                            Message = $"Compilation of {result.AssemblyName} return : " + (resultEmit.Success ? " Success!!" : " Failed"),
                            Diagnostics = string.Join(", ", diags),
                        });

                    // Map diagnostic for not reference roslyn outsite this assembly
                    foreach (Diagnostic diagnostic in resultEmit.Diagnostics)
                        result.Disgnostics.Add(diagnostic.Map());

                    result.Success = resultEmit.Success;

                }

            }
            catch (Exception ex)
            {

                result.Exception = ex;

                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

                Trace.WriteLine(new { Message = $"Compilation of {result.AssemblyName} return : ", Exception = ex });

            }

            return result;

        }

        private List<MetadataReference> ResolveAsemblies(HashSet<string> usings)
        {

            var references = _defaultReferences.ToList();
            IEnumerable<Assembly> ass = TypeDiscovery.Instance.GetAssemblies(usings);

            HashSet<string> _distinct = new HashSet<string>();
            foreach (var assembly in ass)
            {

                if (!_assemblies.Contains(assembly.Location) & _distinct.Add(assembly.Location))
                {
                    var newReference = AssemblyMetadata.CreateFromFile(assembly.Location).GetReference();
                    references.Add(newReference);
                }
            }

            return references;

        }

        #endregion Methods



        private AssemblyResult GetAssemblyResult()
        {

            if (!Directory.Exists(_outputPah))
                Directory.CreateDirectory(_outputPah);

            return new AssemblyResult()
            {
                AssemblyName = _assemblyName,
                AssemblyFile = Path.Combine(_outputPah, $"{_assemblyName}.dll"),
                AssemblyFilePdb = Path.Combine(_outputPah, $"{_assemblyName}.pdb"),
            };

        }

        private static void ResetFilesIfExists(AssemblyResult result)
        {

            //if (File.Exists(result.CodeFile))
            //    File.Delete(result.CodeFile);

            if (File.Exists(result.AssemblyFile))
                File.Delete(result.AssemblyFile);

            if (File.Exists(result.AssemblyFilePdb))
                File.Delete(result.AssemblyFilePdb);
        }

        private Microsoft.CodeAnalysis.SyntaxTree[] Parse(AssemblyResult result)
        {

            List<Microsoft.CodeAnalysis.SyntaxTree> _sources = new List<SyntaxTree>();
            foreach (var item in this._sources)
            {

                result.Documents.Add(item.Filepath);

                CSharpParseOptions options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp6);
                var stringText = Microsoft.CodeAnalysis.Text.SourceText.From(item.Content, Encoding.UTF8);
                var tree = SyntaxFactory.ParseSyntaxTree(stringText, options, item.Filepath);
                _sources.Add(tree);
            }

            return _sources.ToArray();

        }


        // private static readonly string runtimePath = Path.Combine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(), "{0}.dll");
        private readonly List<MetadataReference> _defaultReferences;
        private HashSet<string> _namespaces = new HashSet<string>();
        private HashSet<string> _assemblies = new HashSet<string>();
        private List<FileCode> _sources = new List<FileCode>();

        private string _assemblyName;
        private string _outputPah;
        private uint _hash;
    }


}
