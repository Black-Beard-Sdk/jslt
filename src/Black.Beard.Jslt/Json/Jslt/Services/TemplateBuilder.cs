using Bb.Expresssions;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{


    public class TemplateBuilder : IJsltJsonVisitor
    {

        public TemplateBuilder()
        {

            this._ctorJProperty = typeof(JProperty).GetConstructor(new Type[] { typeof(string), typeof(object) });
            this._ctorJValue = typeof(JValue).GetConstructor(new Type[] { typeof(object) });
            this._ctorJObject = typeof(JObject).GetConstructor(new Type[] { });
            //this._AddJObject = typeof(JObject).GetMethod("Add", new Type[] { typeof(object) });
            this._ctorJArray = typeof(JArray).GetConstructor(new Type[] { typeof(object[]) });
            this._AddJArray = typeof(JArray).GetMethod("Add", new Type[] { typeof(object) });
            this._propJArray_Item = typeof(JArray).GetProperty("Item", new Type[] { typeof(Int32) });

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



        public object VisitArray(JsltArray node)
        {

            using (CurrentContext ctx = NewContext())
            {

                var src = ctx.Current.Source;

                var targetArray = src.AddVar(typeof(JArray), null, typeof(JArray).CreateObject());
                ctx.Current.RootTarget = targetArray;

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
                        b = (Expression)node.Item.Accept(this);
                        _if2.Then.Add(targetArray.Call(this._AddJArray, b));
                    }
                    else
                    {
                        b = (Expression)node.Item.Accept(this);
                        _if.Body.Add(targetArray.Call(this._AddJArray, b));
                    }


                    // Case when else
                    if (node.Where != null)
                    {

                        ctx.Current.Source = i.Else;
                        ctx.Current.RootSource = resultToken;

                        b = (Expression)node.Item.Accept(this);
                        i.Else.Add(targetArray.Call(this._AddJArray, b));

                    }
                    else
                    {

                        ctx.Current.Source = i.Else;
                        ctx.Current.RootSource = resultToken;

                        b = (Expression)node.Item.Accept(this);
                        i.Else.Add(targetArray.Call(this._AddJArray, b));

                    }



                }

                return targetArray;

            }


        }

        internal Func<RuntimeContext, JToken, JToken> Compile(JsltJson tree)
        {
            Expression e;

            e = tree.Accept(this) as Expression;
            source.Add(e);

            var result = source.Compile<Func<RuntimeContext, JToken, JToken>>();

            return result;

        }

        public object VisitConstant(JsltConstant node)
        {
            switch (node.Kind)
            {

                case JsltKind.TimeSpan:
                case JsltKind.Object:
                case JsltKind.Guid:
                case JsltKind.Date:
                case JsltKind.Bytes:
                case JsltKind.Uri:
                case JsltKind.String:
                    return Expression.New(_ctorJValue, Expression.Constant(node.Value));

                case JsltKind.Null:
                    return Expression.Constant(null);

                case JsltKind.Boolean:
                case JsltKind.Float:
                case JsltKind.Type:
                case JsltKind.Integer:
                    return Expression.Constant(node.Value);

                case JsltKind.Property:
                case JsltKind.Array:
                case JsltKind.Path:
                case JsltKind.PathParent:
                case JsltKind.PathKey:
                case JsltKind.PathCoalesce:
                case JsltKind.Jpath:
                case JsltKind.PathIndice:
                case JsltKind.Function:
                default:
                    break;
            }

            throw new NotImplementedException();

        }

        public object VisitObject(JsltObject node)
        {


            using (CurrentContext ctx = this.NewContext())
            {

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

                return v1;

            }

        }

        public object VisitProperty(JsltProperty node)
        {
            var name = Expression.Constant(node.Name);
            var getValue = (Expression)node.Value.Accept(this);
            return this._ctorJProperty.CreateObject(name, getValue);
        }

        public object VisitType(JsltFunction node)
        {

            using (CurrentContext ctx = NewContext())
            {

                Expression expressionCreatetService = Expression.Call(Expression.Constant(node.ServiceProvider), TransformJsonServiceProvider.Method, PrivatedIndex.GetNewIndex().AsConstant());

                foreach (var property in node.Properties)
                {
                    var value = (Expression)property.Value.Accept(this);
                    expressionCreatetService = Expression.Call(null, RuntimeContext._mapPropertyService.Method, ctx.Current.Context, expressionCreatetService, Expression.Constant(property.Name), value);
                }

                var result = Expression.Call(RuntimeContext._getContentFromService.Method, ctx.Current.Context, ctx.Current.RootSource, expressionCreatetService);

                return result;

            }

        }

        public object VisitMapProperty(JsltMapProperty node)
        {

            var ctx = BuildCtx;

            var value = (Expression)node.Value.Accept(this);

            Expression.Call(ctx.Context, null, Expression.Constant(node.Name), value);

            return null;

        }

        public object VisitJPath(JsltPath node)
        {

            using (CurrentContext ctx = NewContext())
            {


                if (node.Type == "jpath")
                    ctx.Current.RootSource = Expression.Call(RuntimeContext._getContentByJPath.Method, ctx.Current.Context, ctx.Current.RootSource, Expression.Constant(node.Value));

                else
                {

                }

                if (node.Child != null)
                    ctx.Current.RootSource = (Expression)node.Child.Accept(this);

                return ctx.Current.RootSource;

            }

        }

        public TranformJsonAstConfiguration Configuration { get; set; }

        //public ParameterExpression Argument { get; }
        //public ParameterExpression Context { get; }


        private ConstructorInfo _ctorJArray;
        private readonly MethodInfo _AddJArray;
        private readonly PropertyInfo _propJArray_Item;
        private readonly MethodCompiler source;
        private readonly ConstructorInfo _ctorJProperty;
        private readonly ConstructorInfo _ctorJValue;
        private readonly ConstructorInfo _ctorJObject;
        //private readonly MethodInfo _AddJObject;


        private BuildContext BuildCtx
        {
            get => _stack.Peek();
        }
        public Dictionary<string, JfunctionDefinition> EmbbededFunction { get; internal set; }

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
        }

    }

}
