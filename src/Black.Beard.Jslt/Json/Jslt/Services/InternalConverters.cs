using Bb.Expressions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Json.Jslt.Services
{

    public static class InternalConverters
    {

        public static bool ToBoolean(JValue self)
        {

            if (self == null)
                return false;

            var value = self.Value;
            
            if (value is Boolean valueB)
                return valueB;

            var targetType = typeof(bool);
          
            var result = ConverterHelper.ToObject(value, targetType);

            return (bool)result;

        }


        public static bool ToBoolean(string self)
        {
            var v1 = self.Trim().ToLower();
            var value = v1.Equals("true") || v1.Equals("1") || v1.Equals("vrai");
            return value;
        }

        public static bool ToBoolean(int self)
        {
            var v1 = self.ToString().Trim('-');
            var value = v1.Equals("true") || v1.Equals("1") || v1.Equals("vrai");
            return value;
        }

        public static string ToString(JToken self)
        {

            if (self is JValue v)
                return v.ToString();

            return self?.ToString() ?? string.Empty;

        }

        public static JToken ToJToken(string self)
        {

            try
            {

                if (!string.IsNullOrEmpty(self))
                {

                    if (self.Contains("{") || self.Contains("["))
                        return JToken.Parse(self);
                    else
                        return new JValue(self);

                }

            }
            catch (Exception ex)
            {
                return new JValue($"failed to convert {self} to token {ex.Message}");
            }

            return JValue.CreateNull();

        }

        public static JToken ToJToken(int self)
        {
            return new JValue(self);
        }

        public static JToken ToJToken(DateTime self)
        {
            return new JValue(self);
        }

        public static JToken ToJToken(double self)
        {
            return new JValue(self);
        }

        public static JToken ToJToken(long self)
        {
            return new JValue(self);
        }

        public static JToken ToJToken(bool self)
        {
            return new JValue(self);
        }

        public static JToken ToJToken(short self)
        {
            return new JValue(self);
        }

        public static JToken ToJToken(uint self)
        {
            return new JValue(self);
        }

    }
}
