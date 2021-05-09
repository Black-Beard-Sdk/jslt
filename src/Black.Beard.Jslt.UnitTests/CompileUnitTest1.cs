using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            Assert.AreEqual(o2["propertyName"], 6L);

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber2()
        {

            var o = new JObject(new JProperty("propertyName", 6.7)).ToString();

            var template = o.ToString();
            var source = "{ }";

            RuntimeContext result = Test(template, source);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], 6.7D);

        }


        [TestMethod]
        public void TestMObjectWithPropertyArray()
        {

            var o = new JObject(new JProperty("propertyName", new JArray() { 6.6, "test", new JObject() { new JProperty("test2", 6) } }));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);

            var source = "{ }";

            RuntimeContext result = Test(expected, source);

            var r = result.TokenResult.ToString(Newtonsoft.Json.Formatting.None);
            Assert.AreEqual(expected, r);

        }

        [TestMethod]
        public void TestMObjectWithconstructor()
        {

            var o = new JObject(new JProperty("propertyName", new JFunctionCall("myMethod", 6.6, "test")));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);

            var source = "{ }";

            RuntimeContext result = Test(expected, source, ("myMethod", typeof(DataClass)));
            Assert.AreEqual(result.TokenResult["propertyName"]["Uuid"], 6.6);

        }

        [TestMethod]
        public void TestJPath()
        {

            var o = new JObject(new JProperty("propertyName", new JPath("$.prop1.SubPprop1")));

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);

            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 2);

        }

        [TestMethod]
        public void TestJPathUnary()
        {

            var o = new JObject(
                new JProperty("propertyName",
                    new JUnaryOperation(new JPath("$.prop1"), OperationEnum.Not)
                    )
                );

            var expected = o.ToString(Newtonsoft.Json.Formatting.None);

            var source = "{ 'prop1': false }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], true);

        }

        [TestMethod]
        public void TestJPathBinary()
        {

            var expected = "{'propertyName':'$.prop1.SubPprop1' + '$.prop2' }".Replace("'", "\""); 
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 5);

        }


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



        private static RuntimeContext Test(string templatePayload, string source, params (string, Type)[] services)
        {
            var src = new Sources(SourceJson.GetFromText(source));
            var template = GetProvider(templatePayload, services);
            var result = template.Transform(src);
            return result;
        }


        private static JsltTemplate GetProvider(string payloadTemplate, params (string, Type)[] services)
        {

            StringBuilder sb = new StringBuilder(payloadTemplate.Replace('\'', '"').Replace('§', '\''));

            var configuration = new TranformJsonAstConfiguration();
            foreach (var item in services)
                configuration.AddService(item.Item2, item.Item1);

            TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);
            JsltTemplate template = Templateprovider.GetTemplate(sb);

            return template;

        }


    }

    public class DataClass : ITransformJsonService
    {

        public DataClass(double id1, string id2)
        {
            this.Id1 = id1;
            this.Id2 = id2;
        }

        public double Id1 { get; set; }

        public string Id2 { get; set; }

        public JToken Execute(RuntimeContext ctx, JToken source)
        {

            return new JObject(
                    new JProperty("Uuid", new JValue(Id1))
                );

        }

    }

}