using Bb.Asts;
using Oldtonsoft.Json.Linq;
using System;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("const {Type.Name} {Value}")]
    public class JsltConstant : JsltBase
    {


        public JsltConstant(object value)
        {
            this.Value = value;
        }

        public JsltConstant()
        {

        }

        public object Value { get; set; }


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
                    writer.Append("\"");
                    writer.Append(value);
                    writer.Append("\"");
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

    }

}
