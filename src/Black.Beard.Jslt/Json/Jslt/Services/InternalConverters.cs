using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Json.Jslt.Services
{

    public static class InternalConverters
    {


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
