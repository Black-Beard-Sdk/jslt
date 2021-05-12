using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Bb.ComponentModel
{

    /// <summary>
    /// object extension. convert all properies of the class in <see cref="Dictionary{string, object}"></see>/>
    /// </summary>
    public static class DictionnarySerializerExtension
    {

        static DictionnarySerializerExtension()
        {
            _dic = new Dictionary<Type, Func<object, Dictionary<string, object>>>();
        }

        /// <summary>
        /// format the serialization of the specified object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">object sour to serialized</param>
        /// <param name="format">output format</param>
        /// <returns>string of the format with the source propertie's serialized</returns>
        public static void SerializeObjectToJson(this Dictionary<string, object> self, StringBuilder stringBuilder, bool ignoreCase = true)
        {

            stringBuilder.Append("{ ");

            foreach (var item in self)
            {
                stringBuilder.Append("\"");
                stringBuilder.Append(item.Key);
                stringBuilder.Append("\"");
                stringBuilder.Append(":");

                if (item.Value == null)
                    stringBuilder.Append("null");

                else if (item.Value.GetType().IsValueType || item.Value is string)
                {
                    stringBuilder.Append("\"");
                    stringBuilder.Append(item.Value.ToString());
                    stringBuilder.Append("\"");
                }
                else if (item.Value is Exception e)
                    SerializeException(stringBuilder, e);

                else
                {
                    GetDictionnaryProperties(item.Value, ignoreCase)
                        .SerializeObjectToJson(stringBuilder, ignoreCase);
                }
                stringBuilder.Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            stringBuilder.Append("}");

        }

        private static void SerializeException(StringBuilder stringBuilder, Exception e)
        {

            stringBuilder.Append("{");

            if (e.Data.Count > 0)
            {
                stringBuilder.Append("\"Data\":");
                stringBuilder.Append("{");
                foreach (var key in e.Data.Keys)
                {
                    stringBuilder.Append("\"");
                    stringBuilder.Append(key);
                    stringBuilder.Append("\"");
                    stringBuilder.Append(":");
                    stringBuilder.Append("\"");
                    stringBuilder.Append(e.Data[key].ToString());
                    stringBuilder.Append("\"");
                    stringBuilder.Append(", ");
                }
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                stringBuilder.Append("}, ");
            }

            stringBuilder.Append($", \"Message\":\"{e.Message}\"");
            stringBuilder.Append($",\"StackTrace\":\"{e.StackTrace.ToString()}\"");
            stringBuilder.Append($",\"Source\":\"{e.Source.ToString()}\"");

            if (e.InnerException != null)
            {
                stringBuilder.Append(",\"InnerException\":");
                SerializeException(stringBuilder, e.InnerException);
            }

            stringBuilder.Append("}");
        }

        /// <summary>
        /// format the serialization of the specified object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">object sour to serialized</param>
        /// <param name="format">output format</param>
        /// <returns>string of the format with the source propertie's serialized</returns>
        public static Dictionary<string, object> GetDictionnaryProperties(this object source, bool ignoreCase = true)
        {
            System.Diagnostics.Contracts.Contract.Requires(!object.Equals(source, null), "null reference exception 'source'");
            var function = GetPropertiesMethod(source.GetType(), ignoreCase);

            if (function == null)
            {

            }

            return function(source);
        }


        #region private

        #region Compile object serialization

        /// <summary>
        /// Get compiled method or create
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static Func<object, Dictionary<string, object>> GetPropertiesMethod(Type type, bool ignoreCase)
        {

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!_dic.TryGetValue(type, out Func<object, Dictionary<string, object>> k))
                lock (_lock)
                    if (!_dic.TryGetValue(type, out k))
                        _dic.Add(type, (k = CompileObject(type, ignoreCase)));

            return k;

        }

        /// <summary>
        /// Compile method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeSource"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static Func<object, Dictionary<string, object>> CompileObject(Type typeSource, bool ignoreCase)
        {

            Type containerType = typeof(Dictionary<string, object>);
            Type stringType = typeof(string);
            var _properties = typeSource.GetAllProperties().Where(c => c.CanRead);
            var properties = new HashSet<string>();
            var m = containerType.GetNamedMethod("Add", typeof(string), typeof(object));

            var p1 = Expression.Parameter(typeof(object), "p1");
            // variables
            var var1 = Expression.Variable(typeSource, "arg1");
            var dic = Expression.Variable(containerType, "dic");

            var lst = new List<Expression>()
            {
                // var dic = new Dictionary<string, object>();
                dic.CreateObject(),
                var1.SettedBy(p1.As(var1.Type)),

            };

            foreach (PropertyInfo item in _properties)
            {
                var n = item.Name;

                if (ignoreCase)
                    n = n.ToLower();

                if (properties.Add(item.Name))
                {
                    var p = item.PropertyType;
                    var m1 = var1.Member(item);
                    if (p == typeof(object))
                        lst.Add(dic.Invoke(m, Expression.Constant(n), m1));
                    else
                        lst.Add(dic.Invoke(m, Expression.Constant(n), m1.As(typeof(object))));
                }
            }
            // return builder.ToString();
            lst.Add(dic);

            // Create func
            BlockExpression block = Expression.Block(containerType, new ParameterExpression[] { dic, var1 }, lst);
            var lbd = Expression.Lambda<Func<object, Dictionary<string, object>>>(block, p1);

            return lbd.Compile();

        }

        #endregion Compile object serialization

        public static Dictionary<Type, Func<object, Dictionary<string, object>>> _dic { get; set; }
        public static volatile object _lock = new object();

        #endregion private

    }

}
