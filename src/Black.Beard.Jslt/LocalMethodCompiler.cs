using Bb.Analysis.DiagTraces;
using Bb.Builds;
using Bb.Expressions.CsharpGenerators;
using Bb.Nugets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expressions
{




    public class LocalMethodCompiler : MethodCompiler
    {

        public LocalMethodCompiler(bool withDebug)
        {
            this._withDebug = withDebug;
        }


        public override TDelegate Compile<TDelegate>(string filepathCode)
        {

            var lbd = GenerateLambda<TDelegate>(filepathCode);

            if (this._withDebug)
            {

                var visitor = new ConstantCollector();
                visitor.Visit(lbd);
                var constants = visitor._list;

                // generate csharp code
                var _u = new string[] { "Oldtonsoft.Json.Linq", "Bb.ComponentModel.Factories", "Bb.Jslt.Services" };
                string name = Path.GetFileNameWithoutExtension(filepathCode);
                string path = Path.Combine(this.OutputPath, "_temps");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string file = Path.Combine(path, filepathCode);
                var code = SourceCodeDomGenerator.GetCode(lbd, $"N_{name}", "Myclass", "MyMethod", _withDebug, _u);
                System.CodeDom.CodeCompileUnit compileUnit = new System.CodeDom.CodeCompileUnit();
                compileUnit.Namespaces.Add(code);
                LocalCodeGenerator.GenerateCsharpCode(compileUnit, file);


                var dir = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
                var controller = new NugetController()
                    .AddFolder(dir, NugetController.HostNugetOrg);

                // Build assembly
                BuildCSharp build = new BuildCSharp()
                {
                    OutputPath = path,
                }
                .SetNugetController(controller)
                .AddSource(file)
                .AddReferences(
                      typeof(LocationDefault)
                    , typeof(LocalMethodCompiler)
                    )
                .AddPackage("Microsoft.CodeAnalysis.CSharp.Workspaces")
                ;

                var assembly = build.Build(name);

                if (assembly == null)
                    return default;

                if (!assembly.Success && System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                    throw new CompilationException(assembly);
                }
                else
                {

                    var ass = assembly.LoadAssembly();

                    var typename = $"N_{name}." + "Myclass";
                    var type = ass.GetType(typename);

                    if (type == null)
                        throw new TypeLoadException($"type {typename} not found.");

                    var method = type.GetMethod("MyMethod");

                    var ctor = type.GetConstructor(new Type[] { typeof(object[]) });

                    var a = constants.Select(c => (object)c).ToArray();
                    var instance = ctor.Invoke(new object[] { a });

                    var args = Parameters.ToArray();
                    var l = Expression.Lambda
                    (
                        Expression.Call(Expression.Constant(instance), method, args),
                        args
                    );

                    return (TDelegate)(object)l.Compile();

                }

            }

            return lbd.Compile();


        }

        private class ConstantCollector : System.Linq.Expressions.ExpressionVisitor
        {

            public ConstantCollector()
            {
                _list = new HashSet<object>();

            }




            protected override System.Linq.Expressions.Expression VisitConstant(System.Linq.Expressions.ConstantExpression node)
            {

                if (node.Value != null && !(node.Value is string) && !node.Value.GetType().IsValueType)
                    _list.Add(node.Value);

                return base.VisitConstant(node);

            }

            public readonly HashSet<object> _list;

        }

        private readonly bool _withDebug;

    }


    [Serializable]
    public class CompilationException : Exception
    {

        public CompilationException(Compilers.AssemblyResult assemblyResult)
            : base(assemblyResult.Diagnostics.First(c => c.Severity == "Error").Message)
        {
            this.AssemblyResult = assemblyResult;
        }

        public CompilationException(string message) : base(message) { }

        public CompilationException(string message, Exception inner) : base(message, inner) { }

        protected CompilationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public Compilers.AssemblyResult AssemblyResult { get; }

    }

}
