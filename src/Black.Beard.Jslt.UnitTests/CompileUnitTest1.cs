using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Black.Beard.Jslt.UnitTests
{
    [TestClass]
    public class CompileUnitTest1
    {


        [TestMethod]
        public void TestMObjectWithPropertyString()
        {

            var o = new JObject(new JProperty("propertyName", "toto")).ToString();
            var template = o.ToString();

            var source = "{ }";

            RuntimeContext result = Test(template, source);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], "toto");

        }


        [TestMethod]
        public void TestMObjectWithPropertyNumber()
        {

            var o = new JObject(new JProperty("propertyName", 6)).ToString();

            var template = o.ToString();
            var source = "{ }";

            RuntimeContext result = Test(template, source);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], 6);

        }


        //[TestMethod]
        //public void TestMObjectWithPropertyNumber2()
        //{

        //    var o = new JObject(new JProperty("propertyName", 6.6)).ToString();

        //    var expected = o.ToString();
        //    var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
        //    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

        //    var result = (JObject)parser.Visit(visitor);

        //    var resultTxt = result.ToString();

        //    Assert.AreEqual(expected, resultTxt);

        //}

        //[TestMethod]
        //public void TestMObjectWithPropertyArray()
        //{

        //    var o = new JObject(new JProperty("propertyName", new JArray() { 6.6, "test", new JObject() { new JProperty("test2", 6) } }));

        //    var expected = o.ToString(Newtonsoft.Json.Formatting.None);
        //    var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
        //    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

        //    var result = (JObject)parser.Visit(visitor);

        //    var resultTxt = result.ToString(Newtonsoft.Json.Formatting.None);

        //    Assert.AreEqual(expected, resultTxt);

        //}


        //[TestMethod]
        //public void TestMObjectWithconstructor()
        //{

        //    var o = new JObject(new JProperty("propertyName", new JConstructor("myMethod",  6.6, "test", new JObject() { new JProperty("test2", 6) }) ));

        //    var expected = o.ToString(Newtonsoft.Json.Formatting.None);
        //    var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
        //    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

        //    var result = (JObject)parser.Visit(visitor);

        //    var resultTxt = result.ToString(Newtonsoft.Json.Formatting.None);

        //    Assert.AreEqual(expected, resultTxt);

        //}

        //[TestMethod]
        //public void TestMObjectWithJPath()
        //{

        //    var o = new JObject(new JProperty("propertyName", new JPath("$..test")));

        //    var expected = o.ToString(Newtonsoft.Json.Formatting.None);
        //    var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
        //    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

        //    var result = (JObject)parser.Visit(visitor);

        //    var resultTxt = result.ToString(Newtonsoft.Json.Formatting.None);

        //    Assert.AreEqual(expected, resultTxt);

        //}

        //[TestMethod]
        //public void TestMObjectWithFunctionNamed()
        //{

        //    var functionBody = new JfunctionBodyDefinition(".js", "fi(arg1){ return arg1; }");
        //    var fnc = new JfunctionDefinition("f1", functionBody);

        //    var o = new JObject(new JProperty("$funcs", new JObject()
        //    {
        //        fnc
        //    }));

        //    var expected = o.ToString(Newtonsoft.Json.Formatting.None);
        //    var parser = ScriptParser.ParseString(new System.Text.StringBuilder(expected));
        //    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);

        //    var result = (JObject)parser.Visit(visitor);

        //    var fnc2 = visitor.EmbeddedFunctions["f1"];
        //    var resultTxt = fnc2.ToString(Newtonsoft.Json.Formatting.None);

        //    Assert.AreEqual(fnc.ToString(Newtonsoft.Json.Formatting.None), resultTxt);

        //}



        private static RuntimeContext Test(string templatePayload, string source)
        {
            var src = new Sources(SourceJson.GetFromText(source));
            var template = GetProvider(templatePayload);
            var result = template.Transform(src);
            return result;
        }

        private static JsltTemplate GetProvider(string payloadTemplate, params (string, ITransformJsonService)[] services)
        {

            StringBuilder sb = new StringBuilder(payloadTemplate.Replace('\'', '"').Replace('§', '\''));

            var configuration = new TranformJsonAstConfiguration();
            foreach (var item in services)
                configuration.AddService(item.Item1, item.Item2);

            TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);

            JsltTemplate template = Templateprovider.GetTemplate(sb);

            return template;

        }
    }
}
