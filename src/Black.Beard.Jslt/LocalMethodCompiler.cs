using Bb.Expressions.CsharpGenerators;
using Bb.Json.Jslt.Builds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expressions
{
    public class LocalMethodCompiler : MethodCompiler
    {

        public override TDelegate Compile<TDelegate>(string filepathCode)
        {

            var lbd = GenerateLambda<TDelegate>(filepathCode);

            if (System.Diagnostics.Debugger.IsAttached)
            {

                var visitor = new ConstantCollector();
                visitor.Visit(lbd);
                var constants = visitor._list;

                // generate csharp code
                var _u = new string[] { "Newtonsoft.Json.Linq", "Bb.ComponentModel.Factories", "Bb.Json.Jslt.Services" };
                string name = Path.GetFileNameWithoutExtension(filepathCode);
                string path = Path.Combine(this.OutputPath, "_temps");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string file = Path.Combine(path, filepathCode);
                var code = SourceCodeDomGenerator.GetCode(lbd, $"N_{name}", "Myclass", "MyMethod", _u);
                System.CodeDom.CodeCompileUnit compileUnit = new System.CodeDom.CodeCompileUnit();
                compileUnit.Namespaces.Add(code);
                LocalCodeGenerator.GenerateCsharpCode(compileUnit, file);

                // Build assembly
                BuildCSharp build = new BuildCSharp()
                {
                    OutputPath = path
                };
                build.Sources.Add(file);
                var assembly = build.Build(name);


                if (!assembly.Success && System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

                var ass = assembly.LoadAssembly();

                var type = ass.GetType($"N_{name}." + "Myclass");
                var method = type.GetMethod("MyMethod");

                // var a = constants.Select(c => Expression.Convert(Expression.Constant(c), typeof(object))).ToArray();

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

    }

}
