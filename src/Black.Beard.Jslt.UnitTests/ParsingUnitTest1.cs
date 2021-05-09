using Bb.Json.Jslt.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Black.Beard.Jslt.UnitTests
{
    [TestClass]
    public class ParsingUnitTest1
    {

        [TestMethod]
        public void TestMObjectWithPropertyString()
        {

            var o = new JObject(new JProperty("propertyName", "toto")).ToString();

            var expected = o.ToString();
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var resultTxt = result.ToString();

            Assert.AreEqual(expected, resultTxt);

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber()
        {

            var o = new JObject(new JProperty("propertyName", 6)).ToString();

            var expected = o.ToString();
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var resultTxt = result.ToString();

            Assert.AreEqual(expected, resultTxt);

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber2()
        {

            var o = new JObject(new JProperty("propertyName", 6.6)).ToString();

            var expected = o.ToString();
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var resultTxt = result.ToString();

            Assert.AreEqual(expected, resultTxt);

        }

        [TestMethod]
        public void TestMObjectWithPropertyArray()
        {

            var o = new JObject(new JProperty("propertyName", new JArray() { 6.6, "test", new JObject() { new JProperty("test2", 6) } }));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var resultTxt = result.ToString(Newtonsoft.Json.Formatting.None);

            Assert.AreEqual(expected, resultTxt);

        }


        [TestMethod]
        public void TestMObjectWithconstructor()
        {

            var o = new JObject(new JProperty("propertyName", new JFunctionCall("myMethod",  6.6, "test", new JObject() { new JProperty("test2", 6) }) ));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var resultTxt = result.ToString(Newtonsoft.Json.Formatting.None);

            Assert.AreEqual(expected, resultTxt);

        }

        [TestMethod]
        public void TestMObjectWithJPath()
        {

            var o = new JObject(new JProperty("propertyName", new JPath("$..test")));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var resultTxt = result.ToString(Newtonsoft.Json.Formatting.None);

            Assert.AreEqual(expected, resultTxt);

        }

        [TestMethod]
        public void TestMObjectWithFunctionNamed()
        {

            var functionBody = new JfunctionBodyDefinition(".js", "fi(arg1){ return arg1; }");
            var fnc = new JfunctionDefinition("f1", functionBody);

            var o = new JObject(new JProperty("$funcs", new JObject()
            {
                fnc
            }));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);
            var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
            var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

            var result = (JObject)parser.Visit(visitor);

            var fnc2 = visitor.EmbeddedFunctions["f1"];
            var resultTxt = fnc2.ToString(Newtonsoft.Json.Formatting.None);

            Assert.AreEqual(fnc.ToString(Newtonsoft.Json.Formatting.None), resultTxt);

        }

    }
}
