﻿using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {

        [JsltExtensionMethod("concat")]
        [JsltExtensionMethodParameter("token", "array to concatenate")]
        [JsltExtensionMethodParameter("splitChar", "split char")]
        [JsltExtensionMethodParameter("delimitChar", "delimiter charset")]
        public static JToken ExecuteConcat(RuntimeContext ctx, JToken token, string splitChar, string delimitChar)
        {

            string _delimitChar = delimitChar ?? string.Empty;
            string _splitChar = splitChar ?? string.Empty;

            StringBuilder sb = new StringBuilder();

            if (token != null)
            {

                if (token is JArray a && a.Count > 0)
                {

                    bool t = false;
                    foreach (var item in a)
                    {

                        if (t)
                        {
                            sb.Append(_splitChar);
                            sb.Append(_delimitChar);
                        }

                        string i = item.Value<string>();
                        sb.Append(i);

                        if (t)
                        {
                            sb.Append(_delimitChar);
                        }

                        t = true;

                    }

                }

            }

            return new JValue(sb.ToString());

        }

        [JsltExtensionMethod("format")]
        [JsltExtensionMethodParameter("token", "")]
        [JsltExtensionMethodParameter("mask", "mask")]
        [JsltExtensionMethodParameter("culture", "culture. It can be null")]
        public static JToken ExecuteFormat(RuntimeContext ctx, JToken token, string mask, string culture)
        {

            if (token is JValue v)
            {

                CultureInfo _culture = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(culture))
                    _culture = CultureInfo.GetCultureInfo(culture);

                if (v.Type == JTokenType.Integer)
                {
                    var i = v.Value<int>();
                    return new JValue(i.ToString(mask, _culture));
                }
                if (v.Type == JTokenType.Float)
                {
                    var i = v.Value<double>();
                    return new JValue(i.ToString(mask, _culture));
                }
                if (v.Type == JTokenType.Date)
                {
                    var i = v.Value<DateTime>();
                    return new JValue(i.ToString(mask, _culture));
                }
                if (v.Type == JTokenType.TimeSpan)
                {
                    var i = v.Value<TimeSpan>();
                    return new JValue(i.ToString(mask, _culture));
                }
                if (v.Type == JTokenType.Guid)
                {
                    var i = v.Value<Guid>();
                    return new JValue(i.ToString(mask, _culture));
                }

                return new JValue(v.Value.ToString());

            }

            return new JValue(token.ToString());
        }

        [JsltExtensionMethod("stringlenght")]
        [JsltExtensionMethodParameter("token", "string value")]
        public static JToken ExecuteStringLenght(RuntimeContext ctx, JToken token)
        {
            if (token is JValue v)
            {
                if (v.Value is string t)
                    return new JValue(t.Length);
            }
            else if (token is JArray a)
                return new JValue(a.Count);
            return new JValue(0);
        }

        [JsltExtensionMethod("stringcontains")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("containStr", "chain to compare")]
        public static JToken Executecontains(RuntimeContext ctx, JToken token, string containStr)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.Contains(containStr));
            return new JValue(false);
        }

        [JsltExtensionMethod("lower")]
        [JsltExtensionMethodParameter("token", "string value")]
        public static JToken ExecuteLower(RuntimeContext ctx, JToken token)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.ToLower());
            return new JValue(false);
        }

        [JsltExtensionMethod("upper")]
        [JsltExtensionMethodParameter("token", "")]
        public static JToken ExecuteUpper(RuntimeContext ctx, JToken token)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.ToUpper());
            return new JValue(false);
        }

        [JsltExtensionMethod("startswith")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("txt", "")]
        public static JToken ExecuteStartsWith(RuntimeContext ctx, JToken token, string txt)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.StartsWith(txt));
            return new JValue(false);
        }

        [JsltExtensionMethod("endswith")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("txt", "")]
        public static JToken ExecuteEndsWith(RuntimeContext ctx, JToken token, string txt)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.EndsWith(txt));
            return new JValue(false);
        }

        [JsltExtensionMethod("trim")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("txt", "")]
        public static JToken ExecuteTrim(RuntimeContext ctx, JToken token, string txt)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.Trim(txt.ToCharArray()));
            return new JValue(false);
        }

        [JsltExtensionMethod("indexof")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("txt", "")]
        public static JToken ExecuteIndexOf(RuntimeContext ctx, JToken token, string txt)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.IndexOf(txt[0]));
            return new JValue(false);
        }

        [JsltExtensionMethod("lastindexof")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("txt", "")]
        public static JToken ExecuteLastIndexOf(RuntimeContext ctx, JToken token, string txt)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.LastIndexOf(txt[0]));
            return new JValue(false);
        }

        [JsltExtensionMethod("normalize")]
        [JsltExtensionMethodParameter("token", "string value")]
        public static JToken ExecuteNormalize(RuntimeContext ctx, JToken token)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.Normalize());
            return new JValue(false);
        }

        [JsltExtensionMethod("padleft")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("lenght", "lenght")]
        [JsltExtensionMethodParameter("charset", "charset")]
        public static JToken ExecutePadLeft(RuntimeContext ctx, JToken token, int lenght, string charset)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.PadLeft(lenght, charset[0]));
            return new JValue(false);
        }

        [JsltExtensionMethod("padright")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("lenght", "lenght")]
        [JsltExtensionMethodParameter("charset", "charset")]
        public static JToken ExecutePadRight(RuntimeContext ctx, JToken token, int lenght, string charset)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.PadRight(lenght, charset[0]));
            return new JValue(false);
        }

        [JsltExtensionMethod("split")]
        [JsltExtensionMethodParameter("token", "string value")]
        [JsltExtensionMethodParameter("charset", "charset")]
        public static JToken ExecuteSplit(RuntimeContext ctx, JToken token, string charset)
        {
            if (token is JValue v)
                if (v.Value is string t)
                    return new JValue(t.Split(charset[0]));
            return new JValue(false);

        }

    }

}