using Bb.Json.Jslt.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Json.Jslt.Asts
{
    public static partial class JExpression
    {

        public static JsltPath Path(string path)
        {
            return new JsltPath() { Value = path };
        }

        public static JsltProperty Property(string name, JsltBase value)
        {
            return new JsltProperty() { Name = name, Value = value };
        }

        public static JsltArgument Argument(string name, JsltBase value)
        {
            return new JsltArgument() { Name = name, Value = value };
        }

        public static JsltVariable Variable(string variableName)
        {
            return new JsltVariable(variableName);
        }

        public static JsltTranslateVariable Translate(JsltBase value, params string[] variables)
        {
            var result = new JsltTranslateVariable(value);
            foreach (var item in variables)
                result.VariableNames.Add(item);
            return result;
        }

        public static JsltArray Array(Func<IEnumerable<JsltBase>> items)
        {
            var i = items().ToArray();
            var result = new JsltArray(i);
            return result;
        }

        public static JsltArray Array(params JsltBase[] items)
        {
            var result = new JsltArray(items);
            return result;
        }

        public static JsltSwitch Switch(JsltBase expression, params JsltCase[] cases)
        {
            var result = new JsltSwitch()
            {
                Expression = expression
            };

            foreach (var item in cases)
                result.Cases.Add(item);
            return result;
        }

        public static JsltSwitch Switch(JsltBase expression, Func<IEnumerable<JsltCase>> cases)
        {
            var result = new JsltSwitch()
            {
                Expression = expression
            };

            foreach (var item in cases().ToList())
                result.Cases.Add(item);

            return result;

        }

        public static JsltCase Case(JsltBase expression, JsltBase block)
        {
            var result = new JsltCase()
            {
                RightExpression = expression,
                Block = block
            };
            return result;
        }

        public static JsltCase Case(JsltBase expression, Func<JsltBase> block)
        {
            var result = new JsltCase()
            {
                RightExpression = expression,
                Block = block()
            };
            return result;
        }

        public static JsltObject Object(params JsltProperty[] properties)
        {
            var result = new JsltObject();
            foreach (var item in properties)
                result.AddProperty(item);
            return result;
        }

        public static JsltObject Object(Func<IEnumerable<JsltProperty>> properties)
        {
            var result = new JsltObject();
            foreach (var item in properties().ToList())
                result.AddProperty(item);
            return result;
        }

        public static JsltOperator Operator(JsltBase left, OperationEnum @operator)
        {
            var result = new JsltOperator(left, @operator);
            return result;
        }

        public static JsltOperator Operator(JsltBase left, OperationEnum @operator, JsltBase right)
        {
            var result = new JsltBinaryOperator(left, @operator, right);
            return result;
        }

        public static JsltMetadata Metadata(object value)
        {
            var result = new JsltMetadata(value);
            return result;
        }

        public static JsltLinkedCode LinkedCode(object value, params JsltBase[] links)
        {
            var result = new JsltLinkedCode();
            foreach (var item in links)
                result.Append(item);
            return result;
        }

        public static JsltConstant Constant(object value, JsltKind? kind)
        {
            var result = new JsltConstant(value, kind.HasValue ? kind.Value : JsltConstant.Resolve(value));
            return result;
        }

        public static JsltFunctionCall Call(string functionName, JsltBase[] arguments)
        {
            var result = new JsltFunctionCall(functionName, arguments);
            return result;
        }

    }

}
