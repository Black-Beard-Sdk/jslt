using Bb.Attributes;
using Bb.Json.Linq;
using System;

namespace Bb.Jslt.CustomServices
{



    public static partial class CServices
    {



        [JsltExtensionMethod("pow")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        [JsltExtensionMethodParameter("tokenRight", "Number value")]
        public static JToken ExecutePow(RuntimeContext ctx, JToken tokenLeft, JToken tokenRight)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Pow(d, (double)RuntimeContext.ConvertTo(tokenRight, typeof(double))));
                    else if (v.Value is Int64 i64)
                        return new JValue(Math.Pow(i64, (double)RuntimeContext.ConvertTo(tokenRight, typeof(Int64))));
                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("min")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        [JsltExtensionMethodParameter("tokenRight", "Number value")]
        public static JToken ExecuteMin(RuntimeContext ctx, JToken tokenLeft, JToken tokenRight)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Min(d, (double)RuntimeContext.ConvertTo(tokenRight, typeof(double))));
                    else if (v.Value is Int64 i64)
                        return new JValue(Math.Min(i64, (double)RuntimeContext.ConvertTo(tokenRight, typeof(Int64))));
                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("max")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        [JsltExtensionMethodParameter("tokenRight", "Number value")]
        public static JToken ExecuteMax(RuntimeContext ctx, JToken tokenLeft, JToken tokenRight)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Max(d, (double)RuntimeContext.ConvertTo(tokenRight, typeof(double))));
                    else if (v.Value is Int64 i64)
                        return new JValue(Math.Max(i64, (double)RuntimeContext.ConvertTo(tokenRight, typeof(Int64))));
                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("abs")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteAbs(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Abs(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Abs(i32));
                    else if (v.Value is Int64 i64)
                        return new JValue(Math.Abs(i64));
                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("sqrt")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteSqrt(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Sqrt(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Sqrt(i32));
                    else if (v.Value is Int64 i64)
                        return new JValue(Math.Abs(i64));
                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("acos")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteAcos(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Acos(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Acos((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));
                   
                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("acosh")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteAcosh(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Acosh(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Acosh((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("asin")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteAsin(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Asin(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Asin((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("asinh")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecutePow(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Asinh(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Asinh((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("atan")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteAtan(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Atan(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Atan((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("cos")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteCos(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Cos(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Cos((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("cosh")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteCosh(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Cosh(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Cosh((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("exp")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteExp(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Exp(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Exp((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("floor")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteFloor(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Floor(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Floor((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("logarithm")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteLog(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Log(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Log((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("logarithm10")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteLog10(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Log10(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Log10((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("logarithm2")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteLog2(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Log2(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Log2((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("round")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteRound(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Round(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Round((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("sin")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteSin(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Sin(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Sin((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("sinh")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteSinh(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Sinh(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Sinh((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("tan")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteTan(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Tan(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Tan((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("tanh")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteTanh(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Tanh(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Tanh((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("truncate")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteTruncate(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Truncate(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Truncate((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("atan2")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        [JsltExtensionMethodParameter("tokenRight", "Number value")]
        public static JToken ExecuteAtan2(RuntimeContext ctx, JToken tokenLeft, JToken tokenRight)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Atan2(d, (double)RuntimeContext.ConvertTo(tokenRight, typeof(double))));
                    else if (v.Value is int i32)
                        return new JValue(Math.Atan2((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double)), (double)RuntimeContext.ConvertTo(tokenRight, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("atanh")]
        [JsltExtensionMethodParameter("tokenLeft", "Number value")]
        public static JToken ExecuteAtanh(RuntimeContext ctx, JToken tokenLeft)
        {

            if (tokenLeft != null)
            {

                if (tokenLeft is JValue v)
                {
                    if (v.Value is double d)
                        return new JValue(Math.Atanh(d));
                    else if (v.Value is int i32)
                        return new JValue(Math.Atanh((double)RuntimeContext.ConvertTo(tokenLeft, typeof(double))));

                }

            }

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("sum")]
        [JsltExtensionMethodParameter("token", "should be an array")]
        public static JToken ExecuteSum(RuntimeContext ctx, JToken token)
        {

            double result = 0;
            if (token != null)
            {

                if (token is JArray a && a.Count > 0)
                {

                    foreach (var item in a)
                    {

                        if (item.Type == JTokenType.Integer)
                        {
                            int i = item.Value<int>();
                            result += i;
                        }
                        else if (item.Type == JTokenType.Float)
                        {
                            float i = item.Value<float>();
                            result += i;
                        }
                        else
                            throw new InvalidOperationException("Interger or float expected value");

                    }

                }

            }

            var r = (int)result;
            if (r < result)
                return new JValue(result);

            return new JValue(r);

        }

        [JsltExtensionMethod("pi")]
        public static JToken ExecutePi(RuntimeContext ctx)
        {
            return new JValue(Math.PI);
        }

        [JsltExtensionMethod("e")]
        public static JToken ExecuteE(RuntimeContext ctx)
        {
            return new JValue(Math.E);
        }


    }

}
