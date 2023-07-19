using Bb.Asts;
using Oldtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("const {Type.Name} {Value}")]
    public class JsltConstant : JsltBase
    {

        public static JsltKind Resolve(object value)
        {

            if (value == null)
                return JsltKind.Null;

            if (value is TimeSpan)
                return JsltKind.TimeSpan;

            if (value is Uri)
                return JsltKind.Uri;

            if (value is Guid)
                return JsltKind.Guid;

            if (value is string)
                return JsltKind.String;

            if (value is byte[])
                return JsltKind.Bytes;

            if (value is bool)
                return JsltKind.Boolean;

            if (value is string)
                return JsltKind.String;

            if (value is double)
                return JsltKind.Float;

            if (value is float)
                return JsltKind.Float;

            if (value is long)
                return JsltKind.Integer;

            if (value is ulong)
                return JsltKind.Integer;

            if (value is int)
                return JsltKind.Integer;

            if (value is uint)
                return JsltKind.Integer;

            if (value is short)
                return JsltKind.Integer;

            if (value is ushort)
                return JsltKind.Integer;

            if (value is DateTime)
                return JsltKind.Date;

            if (value is TimeSpan)
                return JsltKind.TimeSpan;

            throw new NotImplementedException($"{value.GetType().Name} is not managed. Please resolve JsltKind manually.");

        }

        public JsltConstant(object value, JsltKind kind)
        {

            this.Kind = kind;
            var _value = value;
            
            if (_value != null)
            {
                            
                switch (kind)
                {

                    case JsltKind.TimeSpan:
                        if (_value is TimeSpan s1)
                            this.Value = s1;
                        else
                            this.Value = Convert.ChangeType(_value, typeof(TimeSpan));
                        break;

                    case JsltKind.Uri:
                        if (_value is Uri s2)
                            this.Value = s2;

                        if (_value is string s3)
                            this.Value = new Uri(s3);

                        else
                            this.Value = new Uri(Convert.ToString(_value));
                        break;

                    case JsltKind.Guid:
                        if (_value is Guid s4)
                            this.Value = s4;

                        if (_value is string s5)
                            this.Value = Guid.Parse(s5);

                        else
                            this.Value = Convert.ChangeType(_value, typeof(Guid));
                        break;

                    case JsltKind.Bytes:
                        if (_value is Byte[] s6)
                            this.Value = s6;

                        if (_value is string s7)
                            this.Value = System.Text.Encoding.UTF8.GetBytes(s7);

                        else
                            this.Value = Convert.ChangeType(_value, typeof(byte[]));
                        break;

                    case JsltKind.Date:
                        if (_value is DateTime s8)
                            this.Value = s8;
                        else
                            this.Value = Convert.ChangeType(_value, typeof(DateTime), CultureInfo.InvariantCulture);
                        break;

                    case JsltKind.Boolean:
                        if (_value is bool s9)
                            this.Value = s9;
                        else
                            this.Value = Convert.ChangeType(_value, typeof(bool));
                        break;

                    case JsltKind.String:
                        if (_value is string t1)
                            this.Value = t1;
                        else
                            this.Value = Convert.ChangeType(_value, typeof(string));
                        break;

                    case JsltKind.Float:
                        if (_value is Double t2)
                            this.Value = t2;
                        else
                            this.Value = Convert.ChangeType(_value, typeof(double));
                        break;

                    case JsltKind.Integer:
                        if (_value is long t3)
                            this.Value = t3;
                        else
                            this.Value = Convert.ChangeType(_value, typeof(long));
                        break;

                    default:
                        Debug.WriteLine($"{kind} is not managed in JsltConstant");
                        this.Value = _value;
                        break;

                }

            }


        }

        public object Value { get; }

        public Type Type { get => Value?.GetType() ?? typeof(object); }


        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitConstant(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            return WriteValue(writer, Value);

        }

        private static bool WriteValue(Writer writer, object value)
        {

            if (value == null)
            {
                writer.Append("null");
                return true;
            }

            var type = value.GetType();
            switch (type.Name)
            {

                case nameof(Decimal):
                    writer.Append(((decimal)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(Single):
                    writer.Append(((float)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(Double):
                    writer.Append(((double)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(Int64):
                    writer.Append(((long)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(Int32):
                    writer.Append(((int)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(Int16):
                    writer.Append(((short)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(DateTime):
                    writer.Append(((DateTime)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(DateTimeOffset):
                    writer.Append(((DateTimeOffset)value).ToString(writer.Strategy.Culture));
                    return true;

                case nameof(String):

                    if (value != null)
                    {
                        writer.Append("\"");

                        if (value is string s)
                        {
                            if (s.Contains('\\'))
                            {
                                s = s.Replace("\\", "\\\\");
                                writer.Append(s);
                            }
                            else
                                writer.Append(value);

                        }
                        else
                            writer.Append(value);

                        writer.Append("\"");
                    }
                    else
                        writer.Append("null");

                    return true;

                case nameof(Boolean):
                    writer.Append(value.ToString().ToLower());
                    return true;

                default:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        var property = type.GetProperty("HasValue");
                        var hasValue = (bool)property.GetValue(value, null);
                        if (hasValue)
                        {
                            property = type.GetProperty("Value");
                            var value2 = (bool)property.GetValue(value, null);
                            return WriteValue(writer, value2);
                        }

                        writer.Append("null");
                        return true;

                    }

                    writer.Append(value);
                    return true;

            }

        }

        public JToken ToJson()
        {
            return new JValue(Value);
        }

    }

}
