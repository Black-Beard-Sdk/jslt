using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Bb.Expresssions
{

    public class MethodCompiler : SourceCode
    {

        public MethodCompiler()
        {

        }


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

        public TDelegate Compile<TDelegate>()
        {

            var lbd = GenerateLambda<TDelegate>()
                .Compile();
            ;

            return lbd;

        }

        //public TDelegate CompileWithDebug<TDelegate>()
        //{

        //    // Ca ne fonctionne plus en DOT NET CORE (plus de methode CompileToMethod(MethodBuilder, ))
        //    var assemblyName = "dynamic_" + DateTime.UtcNow.Ticks.GetHashCode();

        //    var _asm = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.RunAndCollect);
        //    var _mod = _asm.DefineDynamicModule("mymod");
        //    var _type = _mod.DefineType("baz", TypeAttributes.Public);
        //    MethodBuilder _meth = _type.DefineMethod("go", MethodAttributes.Public | MethodAttributes.Static);

        //    var d1 = new SymbolDocumentGenerator();

        //    var lbd = GenerateLambda<TDelegate>()
        //        .CompileToMethod(_meth, d1);

        //    _asm.Save("tmp.dll");

        //    var lbd = GenerateLambda<TDelegate>()
        //        .Compile(d1);
        //    ;

        //    return lbd;

        //}


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

        public Expression<TDelegate> GenerateLambda<TDelegate>()
        {

            var parameters = this._parameters.Items.Select(c => c.Instance).ToArray();
            HashSet<string> variableParent = new HashSet<string>(parameters.Select(c => c.Name));

            var expression = this.GetExpression(variableParent);

            if (expression.CanReduce)
                expression = expression.Reduce();

            var result = Expression.Lambda<TDelegate>(expression, parameters.ToArray());

            //var o = new System.Linq.Expressions.Expression.LambdaExpressionProxy(result).DebugView;
            //if (System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debug.WriteLine(result.ToString());

            if (System.Diagnostics.Debugger.IsAttached)
            {
                var sb = SourceGenerator.GetCode(result, "Newtonsoft.Json.Linq", "Bb.TransformJson");
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            }

            return result;

        }

        #endregion compiler



        private Variables _parameters = new Variables();

    }


    //internal sealed class SymbolDocumentGenerator : DebugInfoGenerator
    //{


    //    public SymbolDocumentGenerator()
    //    {

           
    //    }

    //    private ISymbolDocumentWriter GetSymbolWriter(MethodBuilder method, SymbolDocumentInfo document)
    //    {

    //        ISymbolDocumentWriter result = null;
    //        if (_symbolWriters == null)
    //            _symbolWriters = new Dictionary<SymbolDocumentInfo, ISymbolDocumentWriter>();

    //        if (!_symbolWriters.TryGetValue(document, out result))
    //        {
    //            //var m = method.Module as ModuleBuilder;
    //            //result = m.DefineDocument(document.FileName, document.Language, document.LanguageVendor, DocumentType_Text);
    //            //_symbolWriters.Add(document, result);
    //        }

    //        return result;
    //    }

    //    public override void MarkSequencePoint(LambdaExpression method, int ilOffset, DebugInfoExpression sequencePoint)
    //    {

    //        //MethodBuilder builder = methodBase as MethodBuilder;
    //        //if (builder != null)
    //        //{
    //        //    ilg.MarkSequencePoint(GetSymbolWriter(builder, sequencePoint.Document), sequencePoint.StartLine, sequencePoint.StartColumn, sequencePoint.EndLine, sequencePoint.EndColumn);
    //        //}


    //    }

    //    private Dictionary<SymbolDocumentInfo, ISymbolDocumentWriter> _symbolWriters;


    //    //public override void MarkSequencePoint(LambdaExpression method, int ilOffset, DebugInfoExpression sequencePoint)
    //    //{
    //    //    throw Error.PdbGeneratorNeedsExpressionCompiler();
    //    //}

    //    //internal override void SetLocalName(LocalBuilder localBuilder, string name)
    //    //{
    //    //    localBuilder.SetLocalSymInfo(name);
    //    //}

    //    internal static readonly Guid DocumentType_Text = new Guid(0x5a869d0b, 0x6611, 0x11d3, 0xbd, 0x2a, 0, 0, 0xf8, 8, 0x49, 0xbd);

    //}

}
