using Bb.Jslt.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Jslt.Asts
{

    public static partial class JExpression
    {

        /// <summary>
        /// Create a new instance of JsltPath
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JsltPath AsJsltPath(this string path)
        {
            return new JsltPath() { Value = path };
        }

        /// <summary>
        /// Create a new instance of JsltProperty
        /// </summary>
        /// <param name="name">name of the property</param>
        /// <param name="value">value of the property</param>
        /// <returns></returns>
        public static JsltProperty AsJsltProperty(string name, JsltBase value)
        {
            return new JsltProperty() { Name = name, Value = value };
        }

        /// <summary>
        /// Create a new instance of JsltVariable
        /// </summary>
        /// <param name="variableName">Name of the variable</param>
        /// <returns></returns>
        public static JsltVariable AsJsltVariable(this string variableName)
        {
            return new JsltVariable(variableName);
        }

        /// <summary>
        /// Create a new instance of JsltTranslateVariable
        /// </summary>
        /// <param name="value">object to translate</param>
        /// <param name="variables">list of variable</param>
        /// <returns></returns>
        public static JsltTranslateVariable AsJsltTranslate(JsltBase value, params string[] variables)
        {
            var result = new JsltTranslateVariable(value);
            foreach (var item in variables)
                result.VariableNames.Add(item);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltArray
        /// </summary>
        /// <param name="items">items of the JsltArray</param>
        /// <returns></returns>
        public static JsltArray AsJsltArray(this JsltBase[] items)
        {
            var result = new JsltArray(items);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltSwitch
        /// </summary>
        /// <param name="expression">expression use like left operand</param>
        /// <param name="cases">List of right operand</param>
        /// <returns></returns>
        public static JsltSwitch AsJsltSwitch(this JsltBase expression, params JsltSwitchCase[] cases)
        {
            var result = new JsltSwitch()
            {
                Expression = expression
            };

            foreach (var item in cases)
                result.Cases.Add(item);
            return result;
        }

        /// <summary>
        /// create a new instance of JsltSwitch
        /// </summary>
        /// <param name="expression">expression use like left operand</param>
        /// <param name="cases">List of right operand</param>
        /// <returns></returns>
        public static JsltSwitch AsJsltSwitch(this JsltBase expression, Func<IEnumerable<JsltSwitchCase>> cases)
        {
            var result = new JsltSwitch()
            {
                Expression = expression
            };

            foreach (var item in cases().ToList())
                result.Cases.Add(item);

            return result;

        }

        /// <summary>
        /// Create a new instance of JsltSwitchCase
        /// </summary>
        /// <param name="expression">expression to use in right operand</param>
        /// <param name="block">block of instruction to execute if operands match</param>
        /// <returns></returns>
        public static JsltSwitchCase AsJsltCase(this JsltBase expression, JsltBase block)
        {
            var result = new JsltSwitchCase()
            {
                RightExpression = expression,
                Block = block
            };
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltSwitchCase
        /// </summary>
        /// <param name="expression">expression to use in right operand</param>
        /// <param name="block">block of instruction to execute if operands match</param>
        /// <returns></returns>
        public static JsltSwitchCase AsJsltCase(this JsltBase expression, Func<JsltBase> block)
        {
            var result = new JsltSwitchCase()
            {
                RightExpression = expression,
                Block = block()
            };
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltObject
        /// </summary>
        /// <param name="properties">List of properties of the object</param>
        /// <returns></returns>
        public static JsltObject AsJsltObject(params JsltProperty[] properties)
        {
            var result = new JsltObject();
            foreach (var item in properties)
                result.AddProperty(item);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltObject
        /// </summary>
        /// <param name="properties">List of properties of the object</param>
        /// <returns></returns>
        public static JsltObject AsJsltObject(Func<IEnumerable<JsltProperty>> properties)
        {
            var result = new JsltObject();
            foreach (var item in properties().ToList())
                result.AddProperty(item);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltFunctionCall
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="operator">unary operator</param>
        /// <returns></returns>
        public static JsltOperator AsJsltOperation(JsltBase left, OperationEnum @operator)
        {
            var result = new JsltOperator(left, @operator);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltMetadata
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static JsltMetadata AsJsltMetadata(object value)
        {
            var result = new JsltMetadata(value);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltLinkedCode
        /// </summary>
        /// <param name="value">Initial expression</param>
        /// <param name="links">expression to add on the first</param>
        /// <returns></returns>
        public static JsltLinkedCode AsJsltLinkedCode(this JsltBase value, params JsltBase[] links)
        {
            var result = new JsltLinkedCode();
            result.Append(value);
            if (links != null)
                foreach (var item in links)
                    result.Append(item);
            return result;
        }

        /// <summary>
        /// Create a new instance of JsltConstant
        /// </summary>
        /// <param name="value">value of the constant</param>
        /// <param name="kind">kind of the constant</param>
        /// <returns></returns>
        public static JsltConstant AsJsltConstant(this object value, JsltKind? kind)
        {
            var result = new JsltConstant(value, kind.HasValue ? kind.Value : JsltConstant.Resolve(value));
            return result;
        }

    }

}
