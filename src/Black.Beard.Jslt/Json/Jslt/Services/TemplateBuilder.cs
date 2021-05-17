using Bb.Expresssions;
using Bb.Expresssions.Statements;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{


    internal class TemplateBuilder : IJsltJsonVisitor
    {

        public TemplateBuilder()
        {

            this._ctorJProperty = typeof(JProperty).GetConstructor(new Type[] { typeof(string), typeof(object) });
            this._ctorJObject = typeof(JObject).GetConstructor(new Type[] { });
            //this._AddJObject = typeof(JObject).GetMethod("Add", new Type[] { typeof(object) });
            this._ctorJArray = typeof(JArray).GetConstructor(new Type[] { typeof(object[]) });
            this._AddJArray = typeof(JArray).GetMethod("Add", new Type[] { typeof(object) });
            this._propJArray_Item = typeof(JArray).GetProperty("Item", new Type[] { typeof(Int32) });

            this._ctorJValueObject = typeof(JValue).GetConstructor(new Type[] { typeof(object) });
            this._ctorJValueLong = typeof(JValue).GetConstructor(new Type[] { typeof(long) });
            this._ctorJValueDateTime = typeof(JValue).GetConstructor(new Type[] { typeof(DateTimeOffset) });
            this._ctorJValueDouble = typeof(JValue).GetConstructor(new Type[] { typeof(double) });
            this._ctorJValueBool = typeof(JValue).GetConstructor(new Type[] { typeof(bool) });
            this._ctorJValueGuid = typeof(JValue).GetConstructor(new Type[] { typeof(Guid) });
            this._ctorJValueUri = typeof(JValue).GetConstructor(new Type[] { typeof(Uri) });
            this._ctorJValueTimeSpan = typeof(JValue).GetConstructor(new Type[] { typeof(TimeSpan) });
            this._jValueGetNull = typeof(JValue).GetMethod("CreateNull");

            this.source = new MethodCompiler();

            var Context = this.source.AddParameter(typeof(RuntimeContext), "argContext");
            var Argument = this.source.AddParameter(typeof(JToken), "argToken");

            _stack.Push(new BuildContext()
            {
                Argument = Argument,
                Context = Context,
                RootSource = Argument,
                RootTarget = null,
                Source = this.source

            }); ;

        }


        public object VisitArray(JsltArray node1)
        {

            using (CurrentContext ctx = NewContext())
            {

                var src = ctx.Current.Source;

                var targetArray = src.AddVar(typeof(JArray), null, typeof(JArray).CreateObject());
                ctx.Current.RootTarget = targetArray;

                foreach (var node in node1.Items)
                {

                    if (node.Source != null)
                    {

                        var resultToken = src.AddVar((typeof(JToken)), null, (Expression)node.Source.Accept(this));

                        // Case when result is array
                        var i = src.If(resultToken.TypeIs(typeof(JArray)));
                        var listArray = i.Then.AddVar(typeof(JArray), null, resultToken.ConvertIfDifferent(typeof(JArray)));

                        var _if = i.Then.For(Expression.Constant(0), listArray.Property("Count"));
                        _if.Where = Expression.LessThan(_if.Index, listArray.Property("Count"));
                        ctx.Current.Source = _if.Body;

                        var itemList = _if.Body.AddVar((typeof(JToken)), null, Expression.Property(listArray, _propJArray_Item, _if.Index));
                        ctx.Current.RootSource = itemList;

                        Expression b;

                        // add in array
                        if (node.Where != null)
                        {

                            var whereToken = _if.Body.AddVar((typeof(bool)), null, RuntimeContext._convertToBool.Call((Expression)node.Where.Accept(this)));

                            var _if2 = _if.Body.If(whereToken.IsTrue());

                            ctx.Current.Source = _if2.Then;
                            b = (Expression)node.Accept(this);
                            _if2.Then.Add(targetArray.Call(this._AddJArray, b));
                        }
                        else
                        {
                            b = (Expression)node.Accept(this);
                            _if.Body.Add(targetArray.Call(this._AddJArray, b));
                        }

                        //// Case when else
                        //if (node.Where != null)
                        //{

                        //    ctx.Current.Source = i.Else;
                        //    ctx.Current.RootSource = resultToken;

                        //    b = (Expression)node.Accept(this);
                        //    i.Else.Add(targetArray.Call(this._AddJArray, b));

                        //}

                    }
                    else
                    {
                        if (node.Where != null)
                        {
                            var whereToken = src.AddVar((typeof(bool)), null, RuntimeContext._convertToBool.Call((Expression)node.Where.Accept(this)));
                            var _if = src.If(whereToken.IsTrue());
                            ctx.Current.Source = _if.Then;
                            var b = (Expression)node.Accept(this);
                            _if.Then.Add(targetArray.Call(this._AddJArray, b));
                        }
                        else
                        {
                            var b = (Expression)node.Accept(this);
                            src.Add(targetArray.Call(this._AddJArray, b));
                        }

                    }

                }

                return targetArray;

            }


        }

        internal Func<RuntimeContext, JToken, JToken> GenerateLambda(JsltBase tree)
        {
            Expression e;

            e = tree.Accept(this) as Expression;
            source.Add(e);

            var result = source.Compile<Func<RuntimeContext, JToken, JToken>>();

            return result;

        }

        public object VisitConstant(JsltConstant node)
        {
            return Expression.Constant(node.Value);
        }

        public object VisitObject(JsltObject node)
        {

            using (CurrentContext ctx = this.NewContext())
            {

                var srcRoot = ctx.Current.Source;

                foreach (var item in node.Variables)
                {
                    item.ToDesctruct = false;
                    var i = (Expression)item.Accept(this);
                    srcRoot.Add(i);
                }

                var v1 = ctx.Current.Source.AddVar(typeof(JObject), null, _ctorJObject.CreateObject());
                ctx.Current.RootTarget = v1;

                if (node.Source != null)
                {

                    var src = ctx.Current.Source;

                    var resultToken = src.AddVar((typeof(JToken)), null, (Expression)node.Source.Accept(this));
                    ctx.Current.RootSource = resultToken;

                    foreach (var item in node.Properties)
                    {
                        var prop = (Expression)item.Accept(this);
                        ctx.Current.Source.Add(RuntimeContext._addProperty.Call(v1, prop));
                    }

                }
                else
                {

                    foreach (var item in node.Properties)
                    {
                        var prop = (Expression)item.Accept(this);
                        ctx.Current.Source.Add(RuntimeContext._addProperty.Call(v1, prop));
                    }

                }

                foreach (var item in node.Variables)
                {
                    item.ToDesctruct = true;
                    var i = (Expression)item.Accept(this);
                    srcRoot.Add(i);
                }

                return v1;

            }

        }

        public object VisitProperty(JsltProperty node)
        {

            var name = Expression.Constant(node.Name);
            var getValue = (Expression)node.Value.Accept(this);

            if (!typeof(JToken).IsAssignableFrom(getValue.Type))
                getValue = getValue.ConvertIfDifferent(typeof(JToken));

            return this._ctorJProperty.CreateObject(name, getValue);

        }

        public object VisitJVariable(JsltVariable node)
        {

            using (CurrentContext ctx = NewContext())
            {
                var name = Expression.Constant(node.Name);

                if (node.ToDesctruct)
                    return RuntimeContext._DelVariable.Call(ctx.Current.Context, name);

                else
                {
                    var getValue = (Expression)node.Value.Accept(this);
                    return RuntimeContext._setVariable.Call(ctx.Current.Context, name, getValue);
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
                        Expression.Constant(node.VariableNames.ToArray())
                    );

                    ctx.Current.RootSource = RuntimeContext._getContentByJPath.Method.Call
                    (
                        ctx.Current.Context, 
                        ctx.Current.RootSource, 
                        txt
                    );

                }
                else
                {
                    ctx.Current.RootSource = RuntimeContext._translateVariable.Method.Call
                    (
                        ctx.Current.Context, 
                        Expression.Constant(node.Value.Value), 
                        Expression.Constant(node.VariableNames.ToArray())
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
                    args.Add(ctx.Current.Context);

                foreach (var property in node.Arguments)
                {

                    Type targetType = node.ParameterTypes[args.Count];
                    var argSourceValue = ((Expression)property.Value.Accept(this))
                        .ConvertIfDifferent(targetType);

                    args.Add(argSourceValue);

                }
                var arguments = typeof(object).NewArray(args.ToArray());
                Expression result = Expression.Constant(node.ServiceProvider).Call(node.ServiceProvider.Method, arguments);

                if (node.ServiceProvider.IsCtor)
                    result = Expression.Call(RuntimeContext._getContentFromService.Method, ctx.Current.Context, ctx.Current.RootSource, result);

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

                var left = (Expression)node.Left.Accept(this);
                var right = (Expression)node.Right.Accept(this);

                var result = RuntimeContext._evaluateBinaryOperator.Method.Call(ctx.Current.Context, left, Expression.Constant(node.Operator), right);

                return result;
            }
        }

        public object VisitArgument(JsltArgument node)
        {
            var ctx = BuildCtx;
            var value = (Expression)node.Value.Accept(this);
            return Expression.Call(ctx.Context, null, Expression.Constant(node.Name), value);
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

                ctx.Current.RootSource = Expression.Call(RuntimeContext._getContentByJPath.Method, ctx.Current.Context, ctx.Current.RootSource, Expression.Constant(node.Value));
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
                var resultVar = nextBlock.AddVar(typeof(object), null, Expression.Constant(null));
                var left = ((Expression)node.Expression.Accept(this))
                    .ConvertIfDifferent(typeof(JToken));

                foreach (var _case in node.Cases)
                {

                    var right = ((Expression)_case.RightExpression.Accept(this))
                        .ConvertIfDifferent(typeof(JToken));

                    var evaluation = Expression.Call(RuntimeContext._evaluateBinaryOperator.Method, ctx.Current.Context, left, Expression.Constant(OperationEnum.Equal), right);

                    condition = nextBlock.If(Expression.MakeBinary(ExpressionType.Equal, evaluation.ConvertIfDifferent(typeof(JValue)).Property("Value").ConvertIfDifferent(typeof(bool)), Expression.Constant(true)));
                    ctx.Current.Source = condition.Then;
                    condition.Then.Assign(resultVar, (Expression)_case.Accept(this));
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

            public ParameterExpression Argument;

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

        private ConstructorInfo _ctorJArray;
        private readonly MethodInfo _AddJArray;
        private readonly MethodInfo _jValueGetNull;
        private readonly PropertyInfo _propJArray_Item;
        private readonly MethodCompiler source;
        private readonly ConstructorInfo _ctorJProperty;

        private readonly ConstructorInfo _ctorJValueObject;
        private readonly ConstructorInfo _ctorJValueLong;
        private readonly ConstructorInfo _ctorJObject;
        private readonly ConstructorInfo _ctorJValueDouble;
        private readonly ConstructorInfo _ctorJValueBool;
        private readonly ConstructorInfo _ctorJValueUri;
        private readonly ConstructorInfo _ctorJValueGuid;
        private readonly ConstructorInfo _ctorJValueTimeSpan;
        private readonly ConstructorInfo _ctorJValueDateTime;



    }

}
