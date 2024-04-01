using Bb.Json.Jslt.Parser;
using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{
    public static partial class JsltVisitorExtension
    {

        /// <summary>
        /// Creates a new instance of JsltArgument
        /// </summary>
        /// <param name="self">name of the argument</param>
        /// <param name="value">value to use in the argument</param>
        /// <returns></returns>
        public static JsltArgument AsJsltArgument(this string self, JsltBase value)
        {
            return new JsltArgument() { Name = self, Value = value };
        }


        /// <summary>
        /// Creates a new instance of JsltArray
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static JsltArray AsJsltArray(this IEnumerable<JsltBase> self)
        {
            return new JsltArray(self);
        }

        /// <summary>
        /// Creates a new instance of JsltOperator
        /// </summary>
        /// <param name="self"></param>
        /// <param name="operator"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static JsltBinaryOperator AsJsltOperation(this JsltBase self, OperationEnum @operator, JsltBase right)
        {
            return new JsltBinaryOperator(self, @operator, right);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="TimeSpan"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this TimeSpan self)
        {
            return new JsltConstant(self, JsltKind.TimeSpan);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="Uri"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this Uri self)
        {
            return new JsltConstant(self, JsltKind.Uri);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="Guid"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this Guid self)
        {
            return new JsltConstant(self, JsltKind.Guid);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="string"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this string self)
        {
            return new JsltConstant(self, JsltKind.String);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="byte[]"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this byte[] self)
        {
            return new JsltConstant(self, JsltKind.Bytes);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="bool"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this bool self)
        {
            return new JsltConstant(self, JsltKind.Boolean);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="double"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this double self)
        {
            return new JsltConstant(self, JsltKind.Float);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="float"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this float self)
        {
            return new JsltConstant(self, JsltKind.Float);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="long"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this long self)
        {
            return new JsltConstant(self, JsltKind.Integer);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="ulong"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this ulong self)
        {
            return new JsltConstant(self, JsltKind.Integer);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="int"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this int self)
        {
            return new JsltConstant(self, JsltKind.Integer);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="uint"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this uint self)
        {
            return new JsltConstant(self, JsltKind.Integer);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="short"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this short self)
        {
            return new JsltConstant(self, JsltKind.Integer);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="ushort"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this ushort self)
        {
            return new JsltConstant(self, JsltKind.Integer);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="DateTime"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this DateTime self)
        {
            return new JsltConstant(self, JsltKind.Date);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self"> <see cref="DateTime"/> </param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this DateTimeOffset self)
        {
            return new JsltConstant(self, JsltKind.Date);
        }

        /// <summary>
        /// Creates a new instance of JsltBinaryOperator
        /// </summary>
        /// <param name="self">name of the function</param>
        /// <param name="arguments">arguments of the function</param>
        /// <returns></returns>
        public static JsltFunctionCall AsJsltFunction(this string self, params JsltBase[] arguments)
        {
            return new JsltFunctionCall(self, arguments);
        }


    }


}
