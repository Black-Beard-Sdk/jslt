using Bb.Expressions.CsharpGenerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expressions
{

    public class MethodCompiler : SourceCode
    {

        public MethodCompiler()
        {
            
        }

        public string OutputPath { get; set; }


        #region parameters

        public ParameterExpression AddParameter(Type type, string name = null)
        {

            if (string.IsNullOrEmpty(name))
                name = this._parameters.GetNewName(type);

            var vari = this._parameters.GetByName(name);
            if (vari != null)
                throw new Exceptions.DuplicatedArgumentNameException($"parameter {name} already exists");

            else
            {

                var instance = Expression.Parameter(type, name);

                var variable = new Variable() { Name = instance.Name, Instance = instance };
                this._parameters.Add(variable);
                this.LastParameter = instance;

                return instance;

            }

        }

        public ParameterExpression GetParameter(string name)
        {
            var variable = _parameters.GetByName(name);
            return variable?.Instance;
        }

        public IEnumerable<ParameterExpression> Parameters { get => this._parameters.Items.Select(c => c.Instance); }
        public ParameterExpression LastParameter { get; private set; }

        #endregion parameters


        public override ParameterExpression GetVar(string name)
        {

            var variable = base.GetVar(name);

            if (variable == null)
                variable = this.GetParameter(name);

            return variable;

        }


        #region Compiler

        public virtual TDelegate Compile<TDelegate>(string filepathCode)
        {

            var lbd = GenerateLambda<TDelegate>(filepathCode);

            if (System.Diagnostics.Debugger.IsAttached)
            {

                var _u = new string[] { "Newtonsoft.Json.Linq", "Bb.ComponentModel.Factories", "Bb.Jslt.Services" };
                //var sb = SourceGenerator.GetCode(result, _u);
                //System.Diagnostics.Debug.WriteLine(sb.ToString());

                var code = SourceCodeDomGenerator.GetCode(lbd, "n_" + Path.GetFileNameWithoutExtension(filepathCode), "Myclass", "MyMethod", false, _u);
                System.CodeDom.CodeCompileUnit compileUnit = new System.CodeDom.CodeCompileUnit()
                {

                };

                string path = Path.Combine(this.OutputPath, "_temps");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string file = Path.Combine(path, filepathCode);
                compileUnit.Namespaces.Add(code);
                LocalCodeGenerator.GenerateCsharpCode(compileUnit, file);

            }

            return lbd.Compile();

        }

        public LambdaExpression GenerateLambda(Type delegateType)
        {

            var parameters = this._parameters.Items.Select(c => c.Instance).ToArray();
            HashSet<string> variableParent = new HashSet<string>(parameters.Select(c => c.Name));

            var expression = this.GetExpression(variableParent);

            if (expression.CanReduce)
                expression = expression.Reduce();

            var result = Expression.Lambda(delegateType, expression, parameters.ToArray());

            return result;

        }

        public Expression<TDelegate> GenerateLambda<TDelegate>(string filepathCode)
        {

            var parameters = this._parameters.Items.Select(c => c.Instance).ToArray();
            HashSet<string> variableParent = new HashSet<string>(parameters.Select(c => c.Name));

            var expression = this.GetExpression(variableParent);

            if (expression.CanReduce)
                expression = expression.Reduce();

            var result = Expression.Lambda<TDelegate>(expression, parameters.ToArray());

            return result;

        }

        #endregion compiler

        private Variables _parameters = new Variables();

    }

}
