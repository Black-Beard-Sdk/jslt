using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Bb.Json.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Json.Jslt.Services
{

    public class TranformJsonTemplateReader
    {

        internal TranformJsonTemplateReader(JToken root, TranformJsonAstConfiguration configuration, FunctionFoundry foundry)
        {
            this._root = root;
            this._configuration = configuration;
            this._FunctionFoundry = foundry;
        }

        public JsltJson Tree()
        {
            if (_root != null)
                return Read(_root);
            return null;
        }

        private JsltJson Read(JToken n)
        {

            switch (n.Type)
            {

                case JTokenType.Object:
                    return ReadObject(n as JObject);

                case JTokenType.Array:
                    return ReadArray(n as JArray);

                case JTokenType.Property:
                    if (n is JfunctionDefinition f)
                        return ReadFunction(f);
                    else
                        return ReadProperty(n as JProperty);

                case JTokenType.Integer:
                    return ReadInteger(n as JValue);

                case JTokenType.Float:
                    return ReadFloat(n as JValue);

                case JTokenType.String:
                    return ReadString(n as JValue);

                case JTokenType.Boolean:
                    return ReadBoolean(n as JValue);

                case JTokenType.Null:
                    return ReadNull(n as JValue);

                case JTokenType.Date:
                    return ReadDate(n as JValue);

                case JTokenType.Bytes:
                    return ReadBytes(n as JValue);

                case JTokenType.Guid:
                    return ReadGuid(n as JValue);

                case JTokenType.Uri:
                    return ReadUri(n as JValue);

                case JTokenType.TimeSpan:
                    return ReadTimeSpan(n as JValue);

                case JTokenType.Raw:

                    if (n is JFunctionCall fu)
                        return ReadFunctionCall(fu);

                    else if (n is JPath p)
                        return ReadPath(p);

                    else if (n is JType t)
                        return ReadType(t);

                    else if (n is JBinaryOperation binaryOperation)
                        return ReadBinaryOperation(binaryOperation);

                    else if (n is JUnaryOperation unaryOperation)
                        return ReadUnaryOperation(unaryOperation);

                    else if (n is JSubExpression subOperation)
                        return ReadSubOperation(subOperation);

                    else if (n is JWhenExpression when)
                        return ReadWhenOperation(when);

                    else if (n is JCaseExpression @case)
                        return ReadCaseOperation(@case);

                    else if (n is JDefaultCaseExpression defaultCase)
                        return ReadDefaultCaseOperation(defaultCase);

                    else if (n is JfunctionDefinition fb)
                        return ReadFunction(fb);

                    else
                        Stop();

                    break;

                case JTokenType.Constructor:
                case JTokenType.Comment:
                case JTokenType.None:
                case JTokenType.Undefined:
                default:
                    break;
            }

            throw new System.NotImplementedException();

        }

        #region read values

        private JsltJson ReadTimeSpan(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.TimeSpan };
        }

        private JsltJson ReadUri(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Uri };
        }

        private JsltJson ReadGuid(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Guid };
        }

        private JsltJson ReadBytes(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Bytes };
        }

        private JsltJson ReadDate(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Date };
        }

        private JsltJson ReadNull(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Null };
        }

        private JsltJson ReadBoolean(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Boolean };
        }

        private JsltJson ReadString(JValue n)
        {
            var value = n.Value?.ToString();
            return new JsltConstant() { Value = value, Kind = JsltKind.String };
        }

        private JsltJson ReadType(JType n)
        {
            return new JsltConstant() { Value = n.Type, Kind = JsltKind.Type };
        }

        private JsltJson ReadPath(JPath n)
        {
            var value = n.Value?.ToString();
            return new JsltPath() { Value = value, Kind = JsltKind.Jpath };
        }

        private JsltJson ReadFloat(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Float };
        }

        private JsltJson ReadInteger(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Integer };
        }

        #endregion read values

        private JsltJson ReadArray(JArray n)
        {

            var arr = new JsltArray(n.Count);

            foreach (var item in n)
            {
                var it = Read(item);
                arr.Append(it);
            }

            return arr;

        }

        private JsltJson ReadObject(JObject n)
        {

            string name = string.Empty;

            var result = new JsltObject() { Name = name };

            foreach (var item in n.Properties())
                result.Append(Read(item) as JsltProperty);

            //if (result.Source != null)
            //{
            //    if (result.Source is JsltConstant c)
            //        if (c.Value is string v)
            //        {
            //            var service = this._configuration.Services.GetService(v);
            //            if (service != null)
            //                return new JsltFunction()
            //                {
            //                    ServiceProvider = service,
            //                };
            //            else
            //                throw new MissingServiceException(v);
            //        }
            //}

            //if (result.Where != null)
            //{
            //    if (result.Where is JsltConstant c)
            //        if (c.Value is string v)
            //        {
            //            var service = this._configuration.Services.GetService(v);
            //            if (service != null)
            //                return new JsltFunction(result) { ServiceProvider = service };
            //            else
            //                throw new MissingServiceException(v);
            //        }

            //}

            return result;

        }

        private JsltJson ReadFunction(JfunctionDefinition n)
        {

            var name = n.Name;
            var value = Read(n.Value);

            var result = new JsltProperty()
            {
                Name = name,
                Value = value
            };

            return result;

        }

        private JsltJson ReadFunctionCall(JFunctionCall n)
        {

            var types = ResolveArgumentsTypes(n);
            var service = this._FunctionFoundry.GetService(n.Name, types);

            List<JsltJson> _arguments = new List<JsltJson>(10);
            foreach (var item in n.Children())
            {
                JsltJson arg = Read(item);
                _arguments.Add(arg);
            }

            if (service != null)
                return new JsltFunction(_arguments)
                {
                    ServiceProvider = service,
                    //Type = result.Name,
                };

            Stop();

            throw new MissingServiceException(n.Name);

        }


        private JsltJson ReadWhenOperation(JWhenExpression n)
        {
            
            Stop();

            var expression = Read(n.Expression);
            List<JsltJson> cases = new List<JsltJson>();
            foreach (var @case in n.Cases)
                cases.Add(Read(@case));

            throw new NotImplementedException();
        }

        private JsltJson ReadCaseOperation(JCaseExpression n)
        {

            Stop();

            var expression = Read(n.Expression);
            var content = Read(n.Content);

            throw new NotImplementedException();
        }

        private JsltJson ReadDefaultCaseOperation(JDefaultCaseExpression n)
        {
            Stop();
            var content = Read(n.Content);
            throw new NotImplementedException();
        }


        private JsltJson ReadSubOperation(JSubExpression n)
        {
            Stop();
            var sub = Read(n.Sub);
            throw new NotImplementedException();
        }

        private JsltJson ReadBinaryOperation(JBinaryOperation n)
        {
            var left = Read(n.Left);
            var right = Read(n.Right);
            return new JsltBinaryOperator(left, n.Operator, right);
        }

        private JsltJson ReadUnaryOperation(JUnaryOperation n)
        {
            var left = Read(n.Left);
            return new JsltOperator(left, n.Operator);
        }

        private Type[] ResolveArgumentsTypes(JFunctionCall n)
        {

            var c = n.Children();
            List<Type> _types = new List<Type>(10);
            foreach (var item in c)
            {
                if (item is JFunctionCall ctor)
                {
                    Stop();
                    var types = ResolveArgumentsTypes(ctor);
                    var service = this._FunctionFoundry.GetService(ctor.Name, types);


                }
                else if (item is JValue v)
                {
                    switch (v.Type)
                    {

                        case JTokenType.Integer:
                            if (v.Value is long l && l <= int.MaxValue)
                                _types.Add(typeof(int));
                            else
                                _types.Add(typeof(long));
                            break;

                        case JTokenType.Float:
                            if (v.Value is double d && d <= int.MaxValue)
                                _types.Add(typeof(Single));
                            else
                                _types.Add(typeof(double));
                            break;

                        case JTokenType.String:
                            _types.Add(typeof(string));
                            break;

                        case JTokenType.Boolean:
                            _types.Add(typeof(bool));
                            break;

                        case JTokenType.Guid:
                            _types.Add(typeof(Guid));
                            break;

                        case JTokenType.Uri:
                            _types.Add(typeof(Uri));
                            break;

                        case JTokenType.TimeSpan:
                            _types.Add(typeof(TimeSpan));
                            break;

                        case JTokenType.Date:
                            _types.Add(typeof(DateTimeOffset));
                            break;

                        case JTokenType.Object:
                            _types.Add(typeof(JObject));
                            break;

                        case JTokenType.Array:
                            break;

                        case JTokenType.Null:
                            Stop();
                            break;

                        case JTokenType.Bytes:
                            Stop();
                            break;

                        case JTokenType.Raw:
                        case JTokenType.Property:
                        case JTokenType.Constructor:
                        case JTokenType.Undefined:
                        case JTokenType.Comment:
                        case JTokenType.None:
                            break;
                        default:
                            break;
                    }
                }
                else if (item is JPath p)
                {
                    Stop();
                    _types.Add(typeof(JToken));
                }
                else if (item is JRaw r)
                {
                    Stop();
                }
                else
                {
                    Stop();

                }
            }

            return _types.ToArray();

        }

        private JsltJson ReadProperty(JProperty n)
        {

            var name = n.Name;
            var value = Read(n.Value);

            var result = new JsltProperty()
            {
                Name = name,
                Value = value
            };

            return result;

        }



        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        private readonly JToken _root;
        private readonly TranformJsonAstConfiguration _configuration;
        private readonly FunctionFoundry _FunctionFoundry;

    }



}
