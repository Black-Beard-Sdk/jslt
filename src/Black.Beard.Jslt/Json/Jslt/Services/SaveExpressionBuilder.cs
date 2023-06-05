using Bb.Expressions;
using Bb.Expressions.Statements;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Bb.Json.Jslt.Services
{


    internal class SaveExpressionBuilder : IJsltJsonVisitor
    {


        static SaveExpressionBuilder()
        {

            ConverterHelper.ResolveConverter(typeof(InternalConverters), (m) => true);

            _ctorJProperty = typeof(JProperty).GetConstructor(new Type[] { typeof(string), typeof(object) });
            _ctorJObject = typeof(JObject).GetConstructor(new Type[] { });
            //this._AddJObject = typeof(JObject).GetMethod("Add", new Type[] { typeof(object) });
            _ctorJArray = typeof(JArray).GetConstructor(new Type[] { typeof(object[]) });
            _AddJArray = typeof(JArray).GetMethod("Add", new Type[] { typeof(object) });
            _propJArray_Item = typeof(JArray).GetProperty("Item", new Type[] { typeof(Int32) });

            _ctorJValueObject = typeof(JValue).GetConstructor(new Type[] { typeof(object) });
            _ctorJValueLong = typeof(JValue).GetConstructor(new Type[] { typeof(long) });
            _ctorJValueDateTime = typeof(JValue).GetConstructor(new Type[] { typeof(DateTimeOffset) });
            _ctorJValueDouble = typeof(JValue).GetConstructor(new Type[] { typeof(double) });
            _ctorJValueBool = typeof(JValue).GetConstructor(new Type[] { typeof(bool) });
            _ctorJValueGuid = typeof(JValue).GetConstructor(new Type[] { typeof(Guid) });
            _ctorJValueUri = typeof(JValue).GetConstructor(new Type[] { typeof(Uri) });
            _ctorJValueTimeSpan = typeof(JValue).GetConstructor(new Type[] { typeof(TimeSpan) });
            _jValueGetNull = typeof(JValue).GetMethod("CreateNull");
        }


        public SaveExpressionBuilder(Diagnostics diagnostics, MethodCompiler compiler)
        {

            PrivatedIndex.Reset();
            _resultReset = new List<MethodCallExpression>();
            this._diagnostics = diagnostics;
            this._indexMethod = 0;

            this._compiler = compiler;

            var Context = this._compiler.AddParameter(typeof(RuntimeContext), "argContext");

            _stack.Push(new BuildContext()
            {
                Context = Context,
                RootTarget = null,
                Source = this._compiler
            });

        }

        internal Func<RuntimeContext, object> GenerateLambdaWriter(JsltBase tree, string filepathCode)
        {

            // Start parsing
            Expression e = tree.Accept(this) as Expression;

            foreach (var item in _resultReset)
                _compiler.Add(item);

            _compiler.Add(e);

            var result = _compiler.Compile<Func<RuntimeContext, object>>(filepathCode);
            return result;

        }


        public object VisitArray(JsltArray node1)
        {

            using (CurrentContext ctx = NewContext())
            {

                var src = ctx.Current.Source;

                var targetArray = src.AddVar(typeof(JArray), src.GetUniqueVariableName("resultArray"), typeof(JArray).CreateObject());
                ctx.Current.RootTarget = targetArray;

                foreach (var node in node1.Items)
                {


                    if (node.Source != null)
                    {


                        var resultToken = src.AddVar((typeof(JToken)), src.GetUniqueVariableName("source"), (Expression)node.Source.Accept(this));
                        node.Source = null;

                        // Case when result is array
                        var i = src.If(resultToken.TypeIs(typeof(JArray)));
                        var listArray = i.Then.AddVar(typeof(JArray), null, resultToken.ConvertIfDifferent(typeof(JArray)));

                        var _for = i.Then.For(Expression.Constant(0), listArray.Property("Count"));
                        _for.Condition = Expression.AndAlso(_for.Condition, ctx.Current.Context.Property("MustoBreak").IsFalse());

                        //_for.Condition = Expression.LessThan(_for.Index, listArray.Property("Count"));
                        ctx.Current.Source = _for.Body;

                        var itemList = _for.Body.AddVar((typeof(JToken)), src.GetUniqueVariableName("currentArrayItem"), Expression.Property(listArray, _propJArray_Item, _for.Index));
                        ctx.Current.RootSource = itemList;

                        Expression b;

                        // add in array
                        if (node.Where != null)
                        {

                            var whereToken = _for.Body.AddVar((typeof(bool)), null, RuntimeContext._convertToBool.Call((Expression)node.Where.Accept(this)));

                            var _if2 = _for.Body.If(whereToken.IsTrue());

                            ctx.Current.Source = _if2.Then;
                            b = (Expression)node.Accept(this);
                            _if2.Then.Add(targetArray.Call(_AddJArray, b));
                        }
                        else
                        {
                            b = (Expression)node.Accept(this);
                            _for.Body.Add(targetArray.Call(_AddJArray, b));
                        }

                    }
                    else
                    {
                        if (node.Where != null)
                        {
                            var whereToken = src.AddVar((typeof(bool)), null, RuntimeContext._convertToBool.Call((Expression)node.Where.Accept(this)));
                            var _if = src.If(whereToken.IsTrue());
                            ctx.Current.Source = _if.Then;
                            var b = (Expression)node.Accept(this);
                            _if.Then.Add(targetArray.Call(_AddJArray, b));
                        }
                        else
                        {
                            var b = (Expression)node.Accept(this);
                            src.Add(targetArray.Call(_AddJArray, b));
                        }

                    }

                }

                return targetArray;

            }

        }

        public object VisitConstant(JsltConstant node)
        {
            return Expression.Constant(node.Value);
        }

        public object VisitMetadata(JsltMetadata node)
        {
            return Expression.Constant(node.Value);
        }

        public object VisitObject(JsltObject node)
        {

            using (CurrentContext ctx = this.NewContext())
            {

                var srcRoot = ctx.Current.Source;

                var v1 = ctx.Current.Source.AddVar(typeof(JObject), null, _ctorJObject.CreateObject());
                ctx.Current.RootTarget = v1;

                if (node.Source != null)
                {

                    var src = ctx.Current.Source;

                    var resultToken = src.AddVar((typeof(JToken)), null, (Expression)node.Source.Accept(this));
                    ctx.Current.RootSource = resultToken;

                    //foreach (var item in node.Properties)
                    //{
                    //    var prop = (Expression)item.Accept(this);
                    //    if (prop != null)
                    //    {
                    //        var call = RuntimeContext._addProperty.Call(v1, prop);
                    //        if (call != null)
                    //            ctx.Current.Source.Add(call);
                    //        else
                    //        {
                    //            _diagnostics.AddError("template builder", item.Start, string.Empty, $"value missing on property {item.Name}");
                    //        }
                    //    }
                    //}

                }

                BuildVariables(node, srcRoot);

                foreach (var item in node.Properties)
                {
                    var prop = (Expression)item.Accept(this);
                    if (prop != null)
                    {
                        var call = RuntimeContext._addProperty.Call(v1, prop);
                        if (call != null)
                            ctx.Current.Source.Add(call);
                        else
                        {
                            _diagnostics.AddError("template builder", item.Start, string.Empty, $"value missing on property {item.Name}");
                        }

                    }
                }


                RemoveVariables(node, srcRoot);

                return v1;

            }

        }

        private void RemoveVariables(JsltObject node, SourceCode src)
        {
            foreach (var item in node.Variables)
            {
                item.ToDestruct = true;
                var i = (Expression)item.Accept(this);
                if (i != null)
                    src.Add(i);
            }
        }

        private void BuildVariables(JsltObject node, SourceCode src)
        {
            foreach (var item in node.Variables)
            {
                item.ToDestruct = false;
                var i = (Expression)item.Accept(this);
                if (i != null)
                    src.Add(i);
            }
        }

        public object VisitDirective(JsltDirective node)
        {


            return null;

        }

        public object VisitProperty(JsltProperty node)
        {
            Expression getValue = null;
            var name = Expression.Constant(node.Name);
            var _value = node.Value;

            if (_value != null)
            {

                getValue = (Expression)_value.Accept(this);

                if (!typeof(JToken).IsAssignableFrom(getValue.Type))
                    getValue = getValue.ConvertIfDifferent(typeof(JToken));

                return _ctorJProperty.CreateObject(name, getValue);

            }

            this._diagnostics.AddError("template building", node.Start, string.Empty, $"missing value on property {name}");

            return null;

        }

        public object VisitJVariable(JsltVariable node)
        {

            using (CurrentContext ctx = NewContext())
            {
                var name = Expression.Constant(node.Name);

                if (node.ToDestruct)
                    return RuntimeContext._DelVariable.Call(ctx.Current.Context, name);

                else
                {
                    var getValue = (Expression)node.Value.Accept(this);
                    return RuntimeContext._setVariable.Call(ctx.Current.Context, name, getValue, node.GetLocation().AsConstant());
                }

            }

        }

        public object VisitTranslateVariable(JsltTranslateVariable node)
        {

            using (CurrentContext ctx = NewContext())
            {

                if (node.Value is JsltPath p)
                {

                    var txt = RuntimeContext._translateVariable.Method.Call
                    (
                        ctx.Current.Context,
                        Expression.Constant(p.Value),
                        Expression.Constant(node.VariableNames.ToArray()),
                        node.GetLocation().AsConstant()
                    );

                    ctx.Current.RootSource = RuntimeContext._getContentByJPath.Method.Call
                    (
                        ctx.Current.Context,
                        ctx.Current.RootSource,
                        txt,
                        node.GetLocation().AsConstant()
                    );

                }
                else
                {

                    object value = null;

                    if (node.Value is JsltConstant c)
                        value = c.Value;

                    else
                    {

                    }

                    ctx.Current.RootSource = RuntimeContext._translateVariable.Method.Call
                    (
                        ctx.Current.Context,
                        Expression.Constant(value),
                        Expression.Constant(node.VariableNames.ToArray()),
                        node.GetLocation().AsConstant()
                    );
                }

                return ctx.Current.RootSource;

            }

        }

        public object VisitFunction(JsltFunctionCall node)
        {

            using (CurrentContext ctx = NewContext())
            {

                List<Expression> args = new List<Expression>();


                // Le premier parametre des methodes est toujours le context.
                if (!node.ServiceProvider.IsCtor)
                    args.Add(ctx.Current.Context);

                // Les arguments sont ceux passé dans le script.
                foreach (var property in node.Arguments)
                {
                    Type targetType = node.ParameterTypes[args.Count]; // Get expected target type
                    var argSourceValue = ((Expression)property.Value.Accept(this))
                        .ConvertIfDifferent(targetType); // Make conversion

                    args.Add(argSourceValue);

                }
                var arguments = typeof(object).NewArray(args.ToArray());
                var keyMethod = Expression.Constant($"service_{this._indexMethod++}");

                Expression result = Expression.Constant(node.ServiceProvider).Call(node.ServiceProvider.MethodCall, keyMethod, arguments);

                //_resultReset.Add(Expression.Constant(node.ServiceProvider).Call(node.ServiceProvider.MethodReset));


                if (node.ServiceProvider.IsCtor)
                {

                    Expression src = ctx.Current.RootSource;
                    if (node.ArgumentsBis.Count > 0)
                        src = (Expression)node.ArgumentsBis[0].Accept(this);

                    result = Expression.Call(RuntimeContext._getContentFromService.Method, ctx.Current.Context, src, result, node.GetLocation().AsConstant(), node.Name.AsConstant());

                }

                return result;

            }

        }

        public Expression ConvertInJValue(JsltKind kind, Expression e)
        {

            switch (kind)
            {

                case JsltKind.Null:
                    return Expression.Call(null, _jValueGetNull);

                case JsltKind.Integer:
                    return Expression.New(_ctorJValueLong, e);

                case JsltKind.TimeSpan:
                    return Expression.New(_ctorJValueTimeSpan, e);

                case JsltKind.Uri:
                    return Expression.New(_ctorJValueUri, e);

                case JsltKind.Guid:
                    return Expression.New(_ctorJValueGuid, e);

                case JsltKind.Date:
                    return Expression.New(_ctorJValueDateTime, e);

                case JsltKind.Float:
                    return Expression.New(_ctorJValueDouble, e);

                case JsltKind.Boolean:
                    return Expression.New(_ctorJValueBool, e);

                case JsltKind.String:
                    return Expression.New(_ctorJValueObject, e);

                case JsltKind.Bytes:
                case JsltKind.Object:
                    return Expression.New(_ctorJValueObject, e);

                default:
                    break;

            }

            throw new NotImplementedException(kind.ToString());

        }

        public object VisitUnaryOperator(JsltOperator node)
        {
            using (CurrentContext ctx = NewContext())
            {
                var left = (Expression)node.Left.Accept(this);

                var result = RuntimeContext._evaluateUnaryOperator.Method.Call(ctx.Current.Context, left, Expression.Constant(node.Operator));
                return result;
            }
        }

        public object VisitBinaryOperator(JsltBinaryOperator node)
        {
            using (CurrentContext ctx = NewContext())
            {

                var nextBlock = ctx.Current.Source;

                var l = node.Left;
                var r = node.Right;

                if (l != null && r != null)
                {

                    var left = (Expression)l.Accept(this);
                    ParameterExpression resultVar = nextBlock.AddVar(left.Type, null, left);

                    if (node.Operator == OperationEnum.Coalesce)
                    {

                        var _if = nextBlock.If(resultVar.Equal(Expression.Constant(null)));

                        ctx.Current.Source = _if.Then;

                        var right = (Expression)r.Accept(this);
                        _if.Then.Add(resultVar.AssignFrom(right));
                        return resultVar;
                    }
                    //if (node.Operator == OperationEnum.Chain)
                    //{


                    //}
                    else
                    {
                        var right = (Expression)r.Accept(this);
                        var result = RuntimeContext._evaluateBinaryOperator.Method.Call(ctx.Current.Context, resultVar, Expression.Constant(node.Operator), right);
                        return result;

                    }

                }

                return null;

            }
        }

        public object VisitArgument(JsltArgument node)
        {
            var ctx = BuildCtx;
            var value = (Expression)node.Value.Accept(this);
            return value;
            // return Expression.Call(ctx.Context, null, Expression.Constant(node.Name), value);
        }

        public object VisitLinkedCode(JsltLinkedCode node)
        {

            object result = null;

            foreach (var item in node.Items)
            {

                var o = item.Accept(this);
                if (result == null)
                    result = o;

            }



            return result;

        }

        public object VisitJPath(JsltPath node)
        {

            using (CurrentContext ctx = NewContext())
            {

                ctx.Current.RootSource = Expression.Call
                (
                    RuntimeContext._getContentByJPath.Method,
                    ctx.Current.Context,
                    ctx.Current.RootSource,
                    Expression.Constant(node.Value),
                    node.GetLocation().AsConstant()
                );
                return ctx.Current.RootSource;

            }

        }

        public object VisitSwitch(JsltSwitch node)
        {

            SourceCode nextBlock;

            using (CurrentContext ctx = NewContext())
            {

                nextBlock = ctx.Current.Source;
                ConditionalStatement condition = null;
                var left = ((Expression)node.Expression.Accept(this))
                    .ConvertIfDifferent(typeof(JToken));

                ParameterExpression resultVar = nextBlock.AddVar(left.Type, null, Expression.Constant(null));

                foreach (var _case in node.Cases)
                {

                    var right = ((Expression)_case.RightExpression.Accept(this))
                        .ConvertIfDifferent(typeof(JToken));

                    var evaluation = Expression.Call(RuntimeContext._evaluateBinaryOperator.Method, ctx.Current.Context, left, Expression.Constant(OperationEnum.Equal), right);

                    condition = nextBlock.If(Expression.MakeBinary(ExpressionType.Equal, evaluation.ConvertIfDifferent(typeof(JValue)).Property("Value").ConvertIfDifferent(typeof(bool)), Expression.Constant(true)));
                    ctx.Current.Source = condition.Then;
                    var i = (Expression)_case.Accept(this);
                    condition.Then.Assign(resultVar, i.ConvertIfDifferent(resultVar.Type));
                    nextBlock = condition.Else;
                }

                if (node.Default != null)
                {
                    ctx.Current.Source = nextBlock;
                    var o = (Expression)node.Default.Accept(this);
                }

                return resultVar;

            }

        }

        public object VisitCase(JsltCase node)
        {

            using (CurrentContext ctx = NewContext())
            {

                return node.Block.Accept(this);

            }

        }




        public TranformJsonAstConfiguration Configuration { get; set; }

        #region Context

        private BuildContext BuildCtx
        {
            get => _stack.Peek();
        }

        public FunctionFoundry EmbbededFunctions { get; internal set; }

        private CurrentContext NewContext()
        {

            var ctx = _stack.Peek();

            var cts = new BuildContext()
            {
                Context = ctx.Context,
                RootSource = ctx.RootSource,
                RootTarget = ctx.RootTarget,
                Source = ctx.Source,
            };

            _stack.Push(cts);

            Action act = () =>
            {
                _stack.Pop();
            };

            return new CurrentContext(act, cts);

        }

        private BuildContext CurrentCtx()
        {
            var ctx = _stack.Peek();
            return ctx;
        }

        public object VisitComment(JsltComment comment)
        {
            return null;
        }

        private class CurrentContext : IDisposable
        {

            public CurrentContext(Action act, BuildContext current)
            {
                this.action = act;
                this.Current = current;
            }

            public void Dispose()
            {
                action();
            }

            private Action action;

            public BuildContext Current { get; }

        }

        private Stack<BuildContext> _stack = new Stack<BuildContext>();

        private class BuildContext
        {

            public ParameterExpression Context;

            public Expression RootSource;

            public Expression RootTarget;

            public SourceCode Source;

            public KindGenerating IsKindGenerating { get; internal set; }
        }

        private enum KindGenerating
        {
            Undefined,
            Constructor,
            Method,
        }

        #endregion Context

        private readonly MethodCompiler _compiler;
        private readonly Diagnostics _diagnostics;
        private int _indexMethod;
        private List<MethodCallExpression> _resultReset;
        private static readonly ConstructorInfo _ctorJArray;
        private static readonly MethodInfo _AddJArray;
        private static readonly MethodInfo _jValueGetNull;
        private static readonly PropertyInfo _propJArray_Item;
        private static readonly ConstructorInfo _ctorJProperty;
        private static readonly ConstructorInfo _ctorJValueObject;
        private static readonly ConstructorInfo _ctorJValueLong;
        private static readonly ConstructorInfo _ctorJObject;
        private static readonly ConstructorInfo _ctorJValueDouble;
        private static readonly ConstructorInfo _ctorJValueBool;
        private static readonly ConstructorInfo _ctorJValueUri;
        private static readonly ConstructorInfo _ctorJValueGuid;
        private static readonly ConstructorInfo _ctorJValueTimeSpan;
        private static readonly ConstructorInfo _ctorJValueDateTime;



    }

}
