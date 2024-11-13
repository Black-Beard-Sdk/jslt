using Bb.Expressions;
using Bb.Attributes;
using Bb.Jslt.Services;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using Bb.Jslt.Parser;

namespace Bb.Jslt.CustomServices
{

    public static partial class CServices
    {

        [JsltExtensionMethod("loadjson")]
        [JsltExtensionMethodParameter("sourcePath", "directory source path")]
        public static JToken ExecuteLoadSource(RuntimeContext ctx, string sourcePath)
        {

            var file = ctx.Configuration.ResolveFile(sourcePath);

            if (file.Exists)
                return file.FullName
                    .LoadFromFile()
                    .ConvertToJson();
            else
            {
                ctx.Diagnostics.AddWarning(string.Empty, ctx.GetCurrentLocation(), "file.FullName", $"file '{file.FullName}' not found");
            }

            return JValue.CreateNull();

        }

        /// <summary>
        /// return the current datetime
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="token"></param>
        /// <param name="utc"></param>
        /// <returns></returns>
        [JsltExtensionMethod("now")]
        [JsltExtensionMethodParameter("utc", "specifiy the time must be utc")]
        public static JToken ExecuteNow(RuntimeContext ctx, bool utc)
        {
            var n = utc ? DateTime.UtcNow : DateTime.Now;
            return new JValue(n);
        }

        [JsltExtensionMethod("uuid")]
        public static JToken ExecuteUuid(RuntimeContext ctx)
        {
            return new JValue(Guid.NewGuid());
        }

        [JsltExtensionMethod("parsedate")]
        [JsltExtensionMethodParameter("token", "must be a string")]
        [JsltExtensionMethodParameter("culture", "culture name. can be null")]
        public static JToken ExecuteParseDate(RuntimeContext ctx, JToken token, string culture)
        {

            if (token is JValue v)
            {

                CultureInfo _culture = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(culture))
                    _culture = CultureInfo.GetCultureInfo(culture);

                if (v.Type == JTokenType.String)
                    return new JValue(DateTime.Parse(v.Value.ToString(), _culture));

            }

            return token;

        }

        [JsltExtensionMethod("convert")]
        [JsltExtensionMethodParameter("token", "item to convert")]
        [JsltExtensionMethodParameter("targetType", "target type")]
        public static JToken ExecuteConvert(RuntimeContext ctx, JToken token, Type targetType)
        {

            if (token != null)
                try
                {

                    if (token is JValue v)
                    {
                        object value = ConverterHelper.ToObject(v.Value, targetType);
                        return new JValue(value);
                    }

                    return new JValue(token.ToString(Bb.Json.Formatting.None));

                }
                catch (Exception ex)
                {
                    var location = ctx.GetCurrentLocation();
                    ctx.Diagnostics.AddError(location, $"convert method {token} to {targetType}", ex.Message);
                }


            return new JValue(targetType.GetDefaultValue());

        }


        [JsltExtensionMethod("isnull")]
        [JsltExtensionMethodParameter("token", "token to evaluate")]
        public static JToken ExecuteIsNull(RuntimeContext ctx, JToken token)
        {

            if (token == null)
                return new JValue(true);

            if (token is JValue v)
                return new JValue(object.Equals(v.Value, null));

            return false;

        }

        [JsltExtensionMethod("isnotnull")]
        [JsltExtensionMethodParameter("token", "token to evaluate")]
        public static JToken ExecuteIsNotNull(RuntimeContext ctx, JToken token)
        {

            if (token == null)
                return new JValue(false);

            if (token is JValue v)
                return new JValue(!object.Equals(v.Value, null));

            return false;

        }

    }

}
