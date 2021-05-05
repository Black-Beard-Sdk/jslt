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

        public TranformJsonTemplateReader(JToken root, TranformJsonAstConfiguration configuration, Dictionary<string, JfunctionDefinition> functions)
        {
            this._root = root;
            this._configuration = configuration;
            this._functions = functions;
        }

        public JsltJson Tree()
        {
            if (_root != null)
                return Read(_root);
            return null;
        }

        public Func<RuntimeContext, JToken, JToken> Get(JsltJson tree)
        {

            Func<RuntimeContext, JToken, JToken> fnc;

            if (tree != null)
            {
                var builder = new TemplateBuilder() { Configuration = this._configuration, EmbbededFunction = this._functions };
                fnc = builder.Compile(tree);
            }
            else // Template empty
            {
                var arg = Expression.Parameter(typeof(RuntimeContext), "arg0");
                var arg1 = Expression.Parameter(typeof(JToken), "arg1");
                var lbd = Expression.Lambda<Func<RuntimeContext, JToken, JToken>>(arg1, arg, arg1);

                if (lbd.CanReduce)
                    lbd.ReduceAndCheck();

                fnc = lbd.Compile();
            }

            return fnc;

        }

        #region read values

        private JsltJson Read(JToken n)
        {

            switch (n.Type)
            {

                case JTokenType.Object:
                    return ReadObject(n as JObject);

                case JTokenType.Array:
                    if (n is JChained c)
                        return ReadChained(c);
                    else
                        return ReadArray(n as JArray);

                case JTokenType.Constructor:
                    return ReadConstructor(n as JConstructor);

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
                    if (n is JPath p)
                        return ReadPath(p);
                    else if (n is JType t)
                        return ReadType(t);
                    else if (n is JfunctionDefinition fb)
                        return ReadFunction(fb);
                    break;

                case JTokenType.Comment:
                case JTokenType.None:
                case JTokenType.Undefined:
                default:
                    break;
            }

            throw new System.NotImplementedException();

        }

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

        private JsltJson ReadfunctionBodyDefinition(JfunctionBodyDefinition n)
        {
            var value = n.Value?.ToString();
            return new JsltPath() { Value = value, Kind = JsltKind.Jpath };
        }

        //private JsltJson ConvertChildToType(JsltJson node)
        //{

        //    if (node is JsltPath jp)
        //    {
        //        if (jp.Type != "jpath")
        //        {

        //            var service = this._configuration.Services.GetService(jp.Type);
        //            if (service == null)
        //                throw new MissingServiceException(jp.Type);

        //            return new JsltType(jp.TypeObject) { Type = jp.Type, ServiceProvider = service };

        //        }

        //        if (jp.Child != null)
        //            jp.Child = ConvertChildToType(jp.Child);
        //    }
        //    else if (node is JsltType t)
        //    {

        //        var service = this._configuration.Services.GetService(t.Type);
        //        if (service == null)
        //            throw new MissingServiceException(t.Type);
        //        t.ServiceProvider = service;

        //    }
        //    return node;

        //}

        private JsltJson ReadFloat(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Float };
        }

        private JsltJson ReadInteger(JValue n)
        {
            return new JsltConstant() { Value = n.Value, Kind = JsltKind.Integer };
        }

        private JsltJson ReadConstructor(JConstructor n)
        {

            //var node = new JsltType() { Value = n.Value, Kind = JsltKind.Integer };

            //var service = this._configuration.Services.GetService(t.Type);
            //if (service == null)
            //    throw new MissingServiceException(t.Type);
            //t.ServiceProvider = service;



            //return node;

            return null;

        }

        #endregion read values

        private JsltJson ReadArray(JArray n)
        {

            var arr = new JsltArray(n.Count);

            foreach (var item in n)
            {

                var it = arr.Item = Read(item);

                if (it.Source != null)
                {
                    arr.Source = it.Source;
                    it.Source = null;
                }
                else
                    throw new MissingFieldException("$source");

                if (it.Where != null)
                {
                    arr.Where = it.Where;
                    it.Where = null;
                }

            }

            return arr;

        }

        private JsltJson ReadChained(JChained n)
        {

            var arr = new JsltArray(n.Count);

            foreach (var item in n)
            {

                var it = arr.Item = Read(item);

                if (it.Source != null)
                {
                    arr.Source = it.Source;
                    it.Source = null;
                }
                else
                    throw new MissingFieldException("$source");

                if (it.Where != null)
                {
                    arr.Where = it.Where;
                    it.Where = null;
                }

            }

            return arr;

        }

        private JsltJson ReadObject(JObject n)
        {

            string name = string.Empty;

            var result = new JsltObject() { Name = name };

            foreach (var item in n.Properties())
                result.Append(Read(item) as JsltProperty);

            if (result.Source != null)
            {
                if (result.Source is JsltConstant c)
                    if (c.Value is string v)
                    {
                        var service = this._configuration.Services.GetService(v);
                        if (service != null)
                            return new JsltFunction(result)
                            {
                                ServiceProvider = service,
                            };
                        else
                            throw new MissingServiceException(v);
                    }
            }
            else if (!string.IsNullOrEmpty(result.Name))
            {
                var service = this._configuration.Services.GetService(result.Name);
                if (service != null)
                    return new JsltFunction(result)
                    {
                        ServiceProvider = service,
                        Type = result.Name,
                    };
                else
                    throw new MissingServiceException(result.Name);
            }

            if (result.Where != null)
            {
                if (result.Where is JsltConstant c)
                    if (c.Value is string v)
                    {
                        var service = this._configuration.Services.GetService(v);
                        if (service != null)
                            return new JsltFunction(result) { ServiceProvider = service };
                        else
                            throw new MissingServiceException(v);
                    }

            }

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


        private readonly JToken _root;
        private readonly TranformJsonAstConfiguration _configuration;
        private readonly Dictionary<string, JfunctionDefinition> _functions;
        //private Stack<object> _path;

    }



}
