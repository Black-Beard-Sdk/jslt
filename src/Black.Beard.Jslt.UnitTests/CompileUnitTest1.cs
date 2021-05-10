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

            var expected = "{ 'propertyName': 'toto' }".Replace("'", "\"");
            var source = "{ }";

            RuntimeContext result = Test(expected, source);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], "toto");

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber()
        {

            var expected = "{ 'propertyName': 6 }".Replace("'", "\"");
            var source = "{ }";

            RuntimeContext result = Test(expected, source);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], 6L);

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber2()
        {

            var expected = "{ 'propertyName': 6.7 }".Replace("'", "\"");
            var source = "{ }";

            RuntimeContext result = Test(expected, source);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], 6.7D);

        }

        [TestMethod]
        public void TestMObjectWithPropertyArray()
        {

            var expected = "{ 'propertyName': [6.6, 'test'] }".Replace("'", "\"");
            var source = "{ }";

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"][0], 6.6);

        }

        [TestMethod]
        public void TestMObjectWithconstructor()
        {

            var expected = "{ 'propertyName': .myMethod(6.6, 'test') }".Replace("'", "\"");
            var source = "{ }";

            RuntimeContext result = Test(expected, source, ("myMethod", typeof(DataClass)));
            Assert.AreEqual(result.TokenResult["propertyName"]["Uuid"], 6.6);

        }

        [TestMethod]
        public void TestJPath()
        {

            var expected = "{ 'propertyName': '$.prop1.SubPprop1' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 2);

        }

        [TestMethod]
        public void TestJPathUnary()
        {

            var expected = "{ 'propertyName': '$.prop1' }".Replace("'", "\"");
            var source = "{ 'prop1': false }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], false);

        }

        [TestMethod]
        public void TestJPathBinaryAddDecimal()
        {

            var expected = "{'propertyName':'$.prop1.SubPprop1' + '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2.5 }, 'prop2':3 }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 5.5);

        }

        [TestMethod]
        public void TestJPathBinaryAdd()
        {

            var expected = "{'propertyName':'$.prop1.SubPprop1' + '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 5);

        }

        [TestMethod]
        public void TestJPathconcat()
        {

            var expected = "{'propertyName':'$.prop1' + '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': 'hello', 'prop2':' world' }".Replace("'", "\"");

            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], "hello world");


        }
        
        [TestMethod]
        public void TestJPathBinarySubstractDecimal()
        {
            var expected = "{'propertyName':'$.prop1' - '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1':2.5, 'prop2':1 }".Replace("'", "\"");
            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 1.5);
        }

        [TestMethod]
        public void TestJPathBinarySubstractInt()
        {
            var expected = "{'propertyName':'$.prop1.SubPprop1' - '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");
            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], -1);
        }

        [TestMethod]
        public void TestJPathBinaryMultiplyInt()
        {
            var expected = "{'propertyName':'$.prop1.SubPprop1' * '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");
            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 6);
        }

        [TestMethod]
        public void TestJPathBinaryModuloInt()
        {
            var expected = "{'propertyName':'$.prop1.SubPprop1' % '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':7 }, 'prop2':3 }".Replace("'", "\"");
            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"], 1);
        }

        [TestMethod]
        public void TestEmbeddedCSharp()
        {
            var expected = @"
{ 

    'propertyName': .when '$.prop1'
                    case 1 : 
                    {
                        { 'sub1' : 11 }
                    } 
                    case 3 : 
                    {
                        { 'sub1' : 22 }
                    } 

}".Replace("'", "\"")
 .Replace("`", "'")
;
            var source = "{ 'prop1':3 }".Replace("'", "\"");
            RuntimeContext result = Test(expected, source);
            Assert.AreEqual(result.TokenResult["propertyName"]["sub1"], 22);
        }



        //        [TestMethod]
        //        public void TestEmbeddedCSharp()
        //        {
        //            var expected = @"
        //{
        //    '$funcs':
        //    {
        //        'myMethod': ```.cs

        //        EmbeddedMethod(JToken self) 
        //        {
        //            return self;
        //        }

        //```
        //    },
        //    'propertyName': .myMethod('$.prop1')
        //}
        //".Replace("'", "\"")
        // .Replace("`", "'")
        //;
        //            var source = "{ 'prop1':3 }".Replace("'", "\"");
        //            RuntimeContext result = Test(expected, source);
        //            Assert.AreEqual(result.TokenResult["propertyName"], 1);
        //        }



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