using Bb.Json.Attributes;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Services;
using Fare;
using Oldtonsoft.Json.Linq;
using RandomDataGenerator.Data.Models;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {

        [JsltExtensionMethod("getrandom_integer")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("exclusiveMinimum", "specify if the minimum value is include")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        [JsltExtensionMethodParameter("exclusiveMaximum", "specify if the maximum value is include")]
        public static JToken GetRandomInteger(RuntimeContext ctx, decimal? minimum, bool? exclusiveMinimum, decimal? maximum, bool? exclusiveMaximum)
        {

            int min = minimum.HasValue ? Math.Min((int)minimum.Value, int.MaxValue) : 0;
            int max = maximum.HasValue ? Math.Max((int)maximum.Value, 1) : 0;

            if (exclusiveMinimum.HasValue && exclusiveMinimum.Value && min > int.MinValue)
                min--;

            if (exclusiveMaximum.HasValue && exclusiveMaximum.Value && max < int.MaxValue)
                max++;

            var options = new FieldOptionsInteger()
            {
                Min = min,
                Max = max,
                UseNullValues = false,
                ValueAsString = true,
            };

            var randomizer = new RandomizerNumber<int>(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_byte")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("exclusiveMinimum", "specify if the minimum value is include")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        [JsltExtensionMethodParameter("exclusiveMaximum", "specify if the maximum value is include")]
        public static JToken GetRandombyte(RuntimeContext ctx, byte? minimum, bool? exclusiveMinimum, byte? maximum, bool? exclusiveMaximum)
        {

            byte min = minimum.HasValue ? Math.Min(minimum.Value, byte.MaxValue) : (byte)0;
            byte max = maximum.HasValue ? Math.Max(maximum.Value, (byte)1) : (byte)0;

            if (exclusiveMinimum.HasValue && exclusiveMinimum.Value && min > int.MinValue)
                min--;

            if (exclusiveMaximum.HasValue && exclusiveMaximum.Value && max < int.MaxValue)
                max++;

            var options = new FieldOptionsInteger()
            {
                Min = min,
                Max = max,
                UseNullValues = false,
                ValueAsString = true,
            };

            var randomizer = new RandomizerNumber<int>(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_double")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("exclusiveMinimum", "specify if the minimum value is include")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        [JsltExtensionMethodParameter("exclusiveMaximum", "specify if the maximum value is include")]
        public static JToken GetRandomDouble(RuntimeContext ctx, double? minimum, bool? exclusiveMinimum, double? maximum, bool? exclusiveMaximum)
        {

            double min = minimum.HasValue ? Math.Min(minimum.Value, double.MaxValue) : 0;
            double max = maximum.HasValue ? Math.Max(maximum.Value, 1) : 0;

            if (exclusiveMinimum.HasValue && exclusiveMinimum.Value && min > int.MinValue)
                min--;

            if (exclusiveMaximum.HasValue && exclusiveMaximum.Value && max < int.MaxValue)
                max++;

            var options = new FieldOptionsDouble()
            {
                Min = min,
                Max = max,
                UseNullValues = false,
                ValueAsString = true,
            };

            var randomizer = new RandomizerNumber<double>(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_float")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("exclusiveMinimum", "specify if the minimum value is include")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        [JsltExtensionMethodParameter("exclusiveMaximum", "specify if the maximum value is include")]
        public static JToken GetRandomFloat(RuntimeContext ctx, float? minimum, bool? exclusiveMinimum, float? maximum, bool? exclusiveMaximum)
        {

            float min = minimum.HasValue ? Math.Min(minimum.Value, float.MaxValue) : 0;
            float max = maximum.HasValue ? Math.Max(maximum.Value, 1) : 0;

            if (exclusiveMinimum.HasValue && exclusiveMinimum.Value && min > int.MinValue)
                min--;

            if (exclusiveMaximum.HasValue && exclusiveMaximum.Value && max < int.MaxValue)
                max++;

            var options = new FieldOptionsFloat()
            {
                Min = min,
                Max = max,
                UseNullValues = false,
                ValueAsString = true,
            };

            var randomizer = new RandomizerNumber<float>(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_long")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("exclusiveMinimum", "specify if the minimum value is include")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        [JsltExtensionMethodParameter("exclusiveMaximum", "specify if the maximum value is include")]
        public static JToken GetRandomLong(RuntimeContext ctx, long? minimum, bool? exclusiveMinimum, long? maximum, bool? exclusiveMaximum)
        {

            long min = minimum.HasValue ? Math.Min(minimum.Value, long.MaxValue) : 0;
            long max = maximum.HasValue ? Math.Max(maximum.Value, 1) : 0;

            if (exclusiveMinimum.HasValue && exclusiveMinimum.Value && min > int.MinValue)
                min--;

            if (exclusiveMaximum.HasValue && exclusiveMaximum.Value && max < int.MaxValue)
                max++;

            var options = new FieldOptionsLong()
            {
                Min = min,
                Max = max,
                UseNullValues = false,
                ValueAsString = true,
            };

            var randomizer = new RandomizerNumber<long>(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_short")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("exclusiveMinimum", "specify if the minimum value is include")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        [JsltExtensionMethodParameter("exclusiveMaximum", "specify if the maximum value is include")]
        public static JToken GetRandomShort(RuntimeContext ctx, short? minimum, bool? exclusiveMinimum, short? maximum, bool? exclusiveMaximum)
        {

            short min = minimum.HasValue ? Math.Min(minimum.Value, short.MaxValue) : (short)0;
            short max = maximum.HasValue ? Math.Max(maximum.Value, (short)1) : (short)256;

            if (exclusiveMinimum.HasValue && exclusiveMinimum.Value && min > int.MinValue)
                min--;

            if (exclusiveMaximum.HasValue && exclusiveMaximum.Value && max < int.MaxValue)
                max++;

            var options = new FieldOptionsLong()
            {
                Min = min,
                Max = max,
                UseNullValues = false,
                ValueAsString = true,
            };

            var randomizer = new RandomizerNumber<long>(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }


        [JsltExtensionMethod("getrandom_string")]
        [JsltExtensionMethodParameter("minlength", "specify if the result has minimum value length")]
        [JsltExtensionMethodParameter("maxlength", "specify if the result has maximum value length")]
        [JsltExtensionMethodParameter("pattern", "specify if the result must to match with regex pattern")]
        public static JToken GetRandomString(RuntimeContext ctx, int? minLength, int? maxLength, string pattern)
        {


            if (!string.IsNullOrEmpty(pattern))
            {
                var options = new FieldOptionsTextRegex()
                {
                    Pattern = pattern,
                    ValueAsString = true,
                };
                var randomizer = new RandomizerTextRegex(options);
                var result = randomizer.Generate(false);
                return new JValue(result);
            }

            var options2 = new FieldOptionsText()
            {
                Min = minLength.HasValue ? Math.Min((int)minLength.Value, 1) : 1,
                Max = maxLength.HasValue ? Math.Max((int)maxLength.Value,1) :1,
                UseLetter = true,
                UseLowercase = true,
                UseUppercase = true,
                UseSpace = true,
                UseNumber = true,
                ValueAsString = true,
                UseSpecial = false,
            };

            var randomizer2 = new RandomizerText(options2);
            var result2 = randomizer2.Generate(false);
            return new JValue(result2);

        }

        [JsltExtensionMethod("getrandom_datatime")]
        public static JToken GetRandomDateTime(RuntimeContext ctx)
        {

            var options = new FieldOptionsDateTime()
            {
                IncludeTime = true,
                //Seed =  1,
                //To = DateTime.Now,
                ValueAsString = true,
            };
            var randomizer = new RandomizerDateTime(options);
            var result = randomizer.Generate();
            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_timespan")]
        public static JToken GetRandomTimeSpan(RuntimeContext ctx)
        {

            var options = new FieldOptionsTimeSpan()
            {
                IncludeMilliseconds = true,
                ValueAsString = true,
            };
            var randomizer = new RandomizerTimeSpan(options);
            var result = randomizer.Generate();
            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_email")]
        public static JToken GetRandomEmail(RuntimeContext ctx)
        {

            var options = new FieldOptionsEmailAddress()
            {
                Female = true,
                Male = true,
                //Left2Right = true,
                ValueAsString = true,
            };
            var randomizer = new RandomizerEmailAddress(options);
            var result = randomizer.Generate();
            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_ipv4")]
        public static JToken GetRandomIpv4(RuntimeContext ctx)
        {
            var options = new FieldOptionsIPv4Address()
            {
                ValueAsString = true,
            };
            var randomizer = new RandomizerIPv4Address(options);
            var result = randomizer.Generate();
            return new JValue(result);
        }

        [JsltExtensionMethod("getrandom_ipv6")]
        public static JToken GetRandomIpv6(RuntimeContext ctx)
        {

            var options = new FieldOptionsIPv6Address()
            {
                Uppercase = true,
                ValueAsString = true,
            };
            var randomizer = new RandomizerIPv6Address(options);
            var result = randomizer.Generate();
            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_binary")]
        [JsltExtensionMethodParameter("minlength", "specify if the result has minimum value length")]
        [JsltExtensionMethodParameter("maxlength", "specify if the result has maximum value length")]
        public static JToken GetRandomBinary(RuntimeContext ctx, int? minLength, int? maxLength)
        {

            var options = new FieldOptionsBytes()
            {
                Min = minLength.HasValue ? Math.Min((int)minLength.Value, int.MaxValue) : 0,
                Max = maxLength.HasValue ? Math.Max((int)maxLength.Value, 1) : 0,
                ValueAsString = true,
            };
            var randomizer = new RandomizerBytes(options);
            var result = randomizer.Generate();

            return new JValue(Convert.ToBase64String(result));

        }

        [JsltExtensionMethod("getrandom_boolean")]
        public static JToken GetRandomBoolean(RuntimeContext ctx)
        {
            return new JValue(DateTime.Now.Millisecond % 2 == 0);
        }

        [JsltExtensionMethod("getrandom_city")]
        public static JToken GetRandomCity(RuntimeContext ctx)
        {

            var options = new FieldOptionsCity()
            {
                ValueAsString = true,
            };
            var randomizer = new RandomizerCity(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_country")]
        public static JToken GetRandomCountry(RuntimeContext ctx)
        {

            var options = new FieldOptionsCountry()
            {
                ValueAsString = true,
            };
            var randomizer = new RandomizerCountry(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_lastname")]
        public static JToken GetRandomLastname(RuntimeContext ctx)
        {

            var options = new FieldOptionsLastName()
            {
                ValueAsString = true,
            };
            var randomizer = new RandomizerLastName(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_firstname")]
        public static JToken GetRandomFirstname(RuntimeContext ctx)
        {

            var options = new FieldOptionsFirstName()
            {
                Female = true,
                Male = true,
                ValueAsString = true,
            };
            var randomizer = new RandomizerFirstName(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_fullname")]
        public static JToken GetRandomFullname(RuntimeContext ctx)
        {

            var options = new FieldOptionsFullName()
            {
                Female = true,
                Male = true,
                ValueAsString = true,
            };
            var randomizer = new RandomizerFullName(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_iban")]
        [JsltExtensionMethodParameter("countryCodeIso2", "country code Iso 2")]
        [JsltExtensionMethodParameter("includeIban", "include Iban")]
        [JsltExtensionMethodParameter("includeBban", "include bban")]
        public static JToken GetRandomIban(RuntimeContext ctx, string countryCodeIso2, bool? includeIban, bool? includeBban)
        {

            string type = "";
            if (includeBban.HasValue && includeBban.Value)
                type = (includeIban.HasValue || true) ? "BOTH" : "BBAN";

            var options = new FieldOptionsIBAN()
            {
                CountryCode = countryCodeIso2,
                Type = type,
                ValueAsString = true,
            };
            var randomizer = new RandomizerIBAN(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_macaddress")]
        [JsltExtensionMethodParameter("minimum", "specify the minimum value")]
        [JsltExtensionMethodParameter("maximum", "specify the maximum value")]
        public static JToken GetRandomMacAddress(RuntimeContext ctx, string? minimum, string? maximum)
        {

            var options = new FieldOptionsMACAddress()
            {
                Min = minimum,
                Max = maximum,
                Uppercase = true,
                ValueAsString = true,
            };
            var randomizer = new RandomizerMACAddress(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_lipsum")]
        [JsltExtensionMethodParameter("paragraphs", "specify the count of paragraph")]
        public static JToken GetRandomLipsum(RuntimeContext ctx, int paragraphs)
        {

            var options = new FieldOptionsTextLipsum()
            {
                Paragraphs = paragraphs,
                UseNullValues = false,
                ValueAsString = true,
            };
            var randomizer = new RandomizerTextLipsum(options);
            var result = randomizer.Generate();

            return new JValue(result);

        }

        [JsltExtensionMethod("getrandom_naughtystrings")]
        public static JToken GetRandomNaughtyStrings(RuntimeContext ctx)
        {

            var options = new FieldOptionsTextNaughtyStrings()
            {
                UseNullValues = false,
                ValueAsString = true,
            };
            var randomizer = new RandomizerTextNaughtyStrings(options);
            var result = randomizer.Generate();

            return new JValue(result);


        }

        [JsltExtensionMethod("getrandom_in_list")]
        public static JToken GetRandomInList(RuntimeContext ctx, JArray items)
        {
            var m = items.Count;
            var index = DateTime.Now.Millisecond % m;
            JToken item = items[index];
            return item;

        }


        //[JsltExtensionMethod("getrandomhostname")]
        //public static JToken GetRandomHostname(RuntimeContext ctx, JToken token)
        //{

        //    var options = new FieldOptionsEmailAddress()
        //    {
        //        Female = true,
        //        Male = true,
        //        //Left2Right = true,
        //        ValueAsString = true,
        //    };
        //    var randomizer = new RandomizerEmailAddress(options);
        //    var result = randomizer.Generate();
        //    return new JValue(result);

        //}


        //[JsltExtensionMethod("getrandomuri")]
        //public static JToken GetRandomUri(RuntimeContext ctx, JToken token)
        //{
        //    return new JValue(sb.ToString());
        //}


        [JsltExtensionMethod("getrandom_password")]
        public static JToken GetRandomPassword(RuntimeContext ctx, JToken token, int length)
        {

            if (length == 0)
                length = 12;

            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--) res.Append(valid[rnd.Next(valid.Length)]);

            return new JValue(res.ToString());
        }

        private const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890&é'(-è_çà)=$ù%*µ,?;:/.?'";

    }

}
