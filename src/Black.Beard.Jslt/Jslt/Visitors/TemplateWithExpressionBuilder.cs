using Bb.Analysis.DiagTraces;
using Bb.Analysis.Tools;
using Bb.Codings;
using Bb.Contracts;
using Bb.Expressions;
using Bb.Expressions.Statements;
using Bb.JPaths;
using Bb.Jslt.Asts;
using Bb.Jslt.Parser;
using Bb.Metrology;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace Bb.Jslt.Visitors
{


    internal class TemplateWithExpressionBuilder : IJsltJsonVisitor, IStoreSource
    {

        static TemplateWithExpressionBuilder()
        {

            _ctorJProperty = typeof(JProperty).GetConstructor(new Type[] { typeof(string), typeof(object) });
            _ctorJObject = typeof(JObject).GetConstructor(new Type[] { });
            //this._AddJObject = typeof(JObject).GetMethod("Add", new Type[] { typeof(object) });
            _ctorJArray = typeof(JArray).GetConstructor(new Type[] { typeof(object[]) });
            _AddJArray = typeof(JArray).GetMethod("Add", new Type[] { typeof(object) });
            _propJArray_Item = typeof(JArray).GetProperty("Item", new Type[] { typeof(int) });

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


        public TemplateWithExpressionBuilder(ScriptDiagnostics diagnostics, MethodCompiler compiler, bool debug)
        {
            _pathStorages = new Stack<DisposingStorage>();
            PrivatedIndex.Reset();
            _resultReset = new List<MethodCallExpression>();
            _diagnostics = diagnostics;
            _indexMethod = 0;
            _debug = debug;
            _compiler = compiler;

            var Context = _compiler.AddParameter(typeof(RuntimeContext), "argContext");
            var Argument = _compiler.AddParameter(typeof(JToken), "argToken");

            _stack.Push(new BuildContext()
            {
                Argument = Argument,
                Context = Context,
                RootSource = Argument,
                RootTarget = null,
                Source = _compiler

            });

        }

        internal Func<RuntimeContext, JToken, JToken> GenerateLambda(JsltBase tree, string filepathCode)
        {

            using (var activity = JsltActivityProvider.StartActivity("generate lambda jslt", System.Diagnostics.ActivityKind.Internal))
            {


                var s = _stack.Peek();
                var s1 = Expression.Assign(Expression.Property(s.Context, RuntimeContext._ScriptProperty), Expression.Constant(ScriptPath ?? string.Empty));

                _compiler.Add(s1);

                // Start parsing
                Expression e = tree.Accept(this) as Expression;

                foreach (var item in _resultReset)
                    _compiler.Add(item);

                _compiler.Add(e);

                var result = _compiler.Compile<Func<RuntimeContext, JToken, JToken>>(filepathCode);

                return result;

            }

        }

        public object VisitArray(JsltArray node1)
        {


            var m2 = typeof(IEnumerable).GetMethod("GetEnumerator");
            var m3 = typeof(IEnumerator).GetMethod("MoveNext");

            var m4 = typeof(Type).GetMethod("IsAssignableFrom");



            using (var store = NewStore())
            using (CurrentContext ctx = NewContext())
            {

                Store("type", typeof(JArray)); // store the type for VisitVariable

                var src = ctx.Current.Source;

                var targetArray = src.AddVar(typeof(JArray), src.GetUniqueVariableName("resultArray"), typeof(JArray).CreateObject());
                ctx.Current.RootTarget = targetArray;


                foreach (var node in node1.Items)
                {

                    if (node.Source != null)
                    {

                        var mem = node.Source;
                        var resultToken = src.AddVar(typeof(JToken), src.GetUniqueVariableName("source"), (Expression)node.Source.Accept(this));
                        node.Source = null;

                        // if ((source3.GetType() == typeof(IEnumerable<JToken>)))
                        var type = resultToken.GetTypeExpression();
                        var i = src.If(typeof(JArray).AsConstant().CallIsAssignableFrom(type));
                        // var i = ((IEnumerable)source3).GetEnumerator();
                        var enumerator = i.Then.AddVar(typeof(IEnumerator<JToken>), null, resultToken.ConvertIfDifferent(typeof(IEnumerable)).Call(m2));

                        // while ((var_IEnumerator`14.MoveNext() && (argContext.MusToBreak == false)))
                        var _for = i.Then.While(Expression.AndAlso(enumerator.Call(m3), ctx.Current.Context.Property(nameof(RuntimeContext.MusToBreak)).IsFalse()));
                        ctx.Current.Source = _for.Body;
                        // currentArrayItem7 = var_IEnumerator`14.Current;
                        var itemList = _for.Body.AddVar(typeof(JToken), src.GetUniqueVariableName("currentArrayItem"), Expression.Property(enumerator, "Current").ConvertIfDifferent(typeof(JToken)));
                        ctx.Current.RootSource = itemList;

                        Expression b;

                        // add in array
                        if (node.Where != null)
                        {

                            var whereToken = _for.Body.AddVar(typeof(bool), null, RuntimeContext._convertToBool.Call((Expression)node.Where.Accept(this)));

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

                        node.Source = mem;

                    }
                    else
                    {
                        if (node.Where != null)
                        {
                            var whereToken = src.AddVar(typeof(bool), null, RuntimeContext._convertToBool.Call((Expression)node.Where.Accept(this)));
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

            using (var store = NewStore())
            using (CurrentContext ctx = NewContext())
            {
                var srcRoot = ctx.Current.Source;

                var v1 = ctx.Current.Source.AddVar(typeof(JObject), null, _ctorJObject.CreateObject());
                ctx.Current.RootTarget = v1;

                if (node.Source != null)
                {

                    var src = ctx.Current.Source;
                    var resultToken = src.AddVar(typeof(JToken), null, (Expression)node.Source.Accept(this));
                    ctx.Current.RootSource = resultToken;
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
                            _diagnostics.AddError("template builder", item.Location, string.Empty, $"value missing on property {item.Name}");
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

        public object VisitDirective(JsltDirectives node)
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

            _diagnostics.AddError("template building", node.Location, string.Empty, $"missing value on property {name}");

            return null;

        }

        public object VisitJVariable(JsltVariable node)
        {

            Type type = typeof(JToken);

            type = node.TargetType ?? typeof(JToken);

            //if (TryGetInStorage<Type>("type", out var typeConversion))
            //{
            //    type = typeConversion;
            //}

            using (CurrentContext ctx = NewContext())
            {
                var name = Expression.Constant(node.Name);

                if (node.ToDestruct)
                    return RuntimeContext._DelVariable.Call(ctx.Current.Context, name);

                else
                {
                    if (node.Value != null)
                    {
                        var getValue = (Expression)node.Value.Accept(this);
                        return RuntimeContext._setVariable.Call(ctx.Current.Context, name, getValue, node.GetLocation().AsConstant());
                    }
                    else
                    {
                        var t = type.AsConstant();
                        var location = node.GetLocation().AsConstant();
                        return RuntimeContext._getVariable.Call(ctx.Current.Context, name, t, location);
                    }
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

                if (!node.ServiceProvider.IsCtor)
                {

                    int line = 0;
                    int col = 0;
                    int index = 0;
                    int index2 = 0;

                    var s = node.Location;
                    if (s == null)
                        s = TextLocation.Empty;

                    var s2 = s.Start as LocationLineAndIndex;
                    if (s2 == null)
                        s2 = new LocationLineAndIndex((0, 0), -1);


                    var e = s.Stop as LocationLineAndIndex;
                    if (e == null)
                        e = new LocationLineAndIndex((s2.Line, s2.Column), s2.Index + node.Name.Length);

                    var c = Expression
                        .Call(null, RuntimeContext._TraceLocation
                        , ctx.Current.Context
                        , Expression.Constant(node.Name)
                        , Expression.Constant(s2.Line)
                        , Expression.Constant(s2.Column)
                        , Expression.Constant(s2.Index)
                        , Expression.Constant(e.Index)
                        );
                    args.Add(c);
                }

                foreach (var property in node.Arguments)
                    using (CurrentContext ctx2 = NewContext())
                    {
                        Type targetType = node.ParameterTypes[args.Count];
                        var argSourceValue = (Expression)property.Value.Accept(this);
                        argSourceValue = argSourceValue.ConvertIfDifferent(targetType);
                        args.Add(argSourceValue);
                    }


                var arguments = typeof(object).NewArray(args.ToArray());
                var keyMethod = Expression.Constant($"service_{_indexMethod++}");


                Expression result = Expression.Constant(node.ServiceProvider).Call(node.ServiceProvider.MethodCall, keyMethod, arguments);
                if (!node.ServiceProvider.IsCtor)
                    result = Expression.Call(null, RuntimeContext._ExitLocation, ctx.Current.Context, result);

                _resultReset.Add(Expression.Constant(node.ServiceProvider).Call(node.ServiceProvider.MethodReset));


                if (node.ServiceProvider.IsCtor)
                {

                    Expression src = ctx.Current.RootSource;
                    if (node.ArgumentsBis.Count > 0)
                        src = (Expression)node.ArgumentsBis[0].Accept(this);

                    result = Expression.Call(RuntimeContext._getContentFromService.Method, ctx.Current.Context, src, result, node.GetLocation().AsConstant(), node.Name.AsConstant());

                }

                //result = TracePosition(node, result);

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


                var path = JsonPath.Parse(node.Value);
                var value = Expression.Constant(JsonPath.Parse(node.Value));

                var source = ctx.Current.RootSource;

                if (node.Source != null)
                {
                    source = (Expression)node.Source.Accept(this);
                }

                if (node.HasTag(TagEnum.ToExecute))
                {
                    ctx.Current.RootSource = Expression.Call
                    (
                        RuntimeContext._getContentByJPath.Method,
                        ctx.Current.Context,
                        source,
                        value,
                        node.GetLocation().AsConstant()
                    );
                }
                else
                {
                    ctx.Current.RootSource = value;
                }

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

        public object VisitCase(JsltSwitchCase node)
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

        public string ScriptPath { get; internal set; }

        private CurrentContext NewContext()
        {

            var ctx = _stack.Peek();

            var cts = new BuildContext()
            {
                Argument = ctx.Argument,
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
                action = act;
                Current = current;
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

            public BuildContext()
            {
                _dic = new Dictionary<string, object>();
            }

            public ParameterExpression Argument;

            public ParameterExpression Context;

            public Expression RootSource;

            public Expression RootTarget;

            public SourceCode Source;

            public KindGenerating IsKindGenerating { get; internal set; }

            public void AddInStorage(string key, object value)
            {
                _dic[key] = value;
            }

            public bool TryGetInStorage(string key, out object value)
            {
                return _dic.TryGetValue(key, out value);
            }

            private Dictionary<string, object> _dic;

        }

        private enum KindGenerating
        {
            Undefined,
            Constructor,
            Method,
        }

        #endregion Context


        #region Stores

        /// <summary>
        /// Get the value from the store
        /// </summary>
        /// <param name="key">key for resolve the value</param>
        /// <param name="value">value stored</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool TryGetInStorage(string key, out object value)
        {
            var s = _pathStorages.Peek();
            if (s == null)
                throw new InvalidOperationException("No storage found");
            return s.TryGetInStorage(key, out value);
        }

        /// <summary>
        /// Get the value from the store
        /// </summary>
        /// <typeparam name="T">type of value to return</typeparam>
        /// <param name="key">key for resolve the value</param>
        /// <param name="value">value stored</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool TryGetInStorage<T>(string key, out T? value)
        {

            var s = _pathStorages.Peek();
            if (s == null)
                throw new InvalidOperationException("No storage found");

            if (s.TryGetInStorage(key, out var v))
            {
                value = (T)v;
                return true;
            }

            value = default;
            return false;

        }

        /// <summary>
        /// return true if a store contains an entry for the specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool ContainsInStorage(string key)
        {
            var s = _pathStorages.Peek();
            if (s == null)
                throw new InvalidOperationException("No storage found");
            return s.ContainsInStorage(key);
        }

        /// <summary>
        /// return true if a store is available
        /// </summary>
        /// <returns></returns>
        protected bool HasCurrentStore()
        {
            return _pathStorages.Count > 0;
        }

        /// <summary>
        /// Get the current store
        /// </summary>
        /// <returns></returns>
        protected IStore CurrentStore()
        {
            return _pathStorages.Peek();
        }

        /// <summary>
        /// Append a new layer for storing data
        /// </summary>
        void IStoreSource.StorePop()
        {
            _pathStorages.Pop();
        }

        /// <summary>
        /// remove the last layer for storing datas
        /// </summary>
        /// <param name="toDispose"></param>
        void IStoreSource.StorePush(object toDispose)
        {
            _pathStorages.Push((DisposingStorage)toDispose);
        }

        protected void Store(string key, object value)
        {
            _pathStorages.Peek().AddInStorage(key, value);
        }

        protected IStore NewStore()
        {
            return new DisposingStorage(this);
        }

        #endregion Stores

        private Stack<DisposingStorage> _pathStorages;
        private readonly MethodCompiler _compiler;
        private readonly ScriptDiagnostics _diagnostics;
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
        private readonly bool _debug;
    }

}
