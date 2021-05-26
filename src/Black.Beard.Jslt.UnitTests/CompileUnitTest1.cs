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

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], "toto");

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber()
        {

            var expected = "{ 'propertyName': 6 }".Replace("'", "\"");
            var source = "{ }";

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], 6L);

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber2()
        {

            var expected = "{ 'propertyName': 6.7 }".Replace("'", "\"");
            var source = "{ }";

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            var o2 = result.TokenResult as JObject;

            Assert.AreEqual(o2["propertyName"], 6.7D);

        }

        [TestMethod]
        public void TestMObjectWithPropertyArray()
        {

            var expected = "{ 'propertyName': [6.6, 'test'] }".Replace("'", "\"");
            var source = "{ }";

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"][0], 6.6);

        }

        [TestMethod]
        public void TestMObjectWithFunctionStatic()
        {

            var expected = "{ 'propertyName': .crc32('test') }".Replace("'", "\"");
            var source = "{ }";

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src, ("myMethod", typeof(DataClass)));
            Assert.AreEqual(result.TokenResult["propertyName"], 3632233996);

        }

        [TestMethod]
        public void TestMObjectWithFunction()
        {

            var expected = "{ 'propertyName': .myMethod(6.6, 'test') }".Replace("'", "\"");
            var source = "{ }";

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src, ("myMethod", typeof(DataClass)));
            Assert.AreEqual(result.TokenResult["propertyName"]["Uuid"], 6.6);
        }

        [TestMethod]
        public void TestJPath()
        {

            var expected = "{ 'propertyName': '$.prop1.SubPprop1' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 2);

        }

        [TestMethod]
        public void TestJPathUnary()
        {

            var expected = "{ 'propertyName': '$.prop1' }".Replace("'", "\"");
            var source = "{ 'prop1': false }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], false);

        }

        [TestMethod]
        public void TestJPathBinaryAddDecimal()
        {

            var expected = "{'propertyName':'$.prop1.SubPprop1' + '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2.5 }, 'prop2':3 }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 5.5);

        }

        [TestMethod]
        public void TestJPathBinaryAdd()
        {

            var expected = "{'propertyName':'$.prop1.SubPprop1' + '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 5);

        }

        [TestMethod]
        public void TestJPathconcat()
        {

            var expected = "{'propertyName':'$.prop1' + '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': 'hello', 'prop2':' world' }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], "hello world");


        }
        
        [TestMethod]
        public void TestJPathBinarySubstractDecimal()
        {
            var expected = "{'propertyName':'$.prop1' - '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1':2.5, 'prop2':1 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 1.5);
        }

        [TestMethod]
        public void TestJPathBinarySubstractInt()
        {
            var expected = "{'propertyName':'$.prop1.SubPprop1' - '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], -1);
        }

        [TestMethod]
        public void TestJPathBinaryMultiplyInt()
        {
            var expected = "{'propertyName':'$.prop1.SubPprop1' * '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 6);
        }

        [TestMethod]
        public void TestJPathBinaryModuloInt()
        {
            var expected = "{'propertyName':'$.prop1.SubPprop1' % '$.prop2' }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':7 }, 'prop2':3 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 1);
        }

        [TestMethod]
        public void TestCaseWhen()
        {
            var expected = @"
{

    'propertyName': .when('$.prop1') 
                    {
                        '1' : { 'sub1' : 11 },
                        '3' : { 'sub1' : 22 }
                    }

}".Replace("'", "\"")
 .Replace("`", "'")
;
            var source = "{ 'prop1':3 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"]["sub1"], 22);
        }

        [TestMethod]
        public void TestMethodCompiled()
        {
            var expected = @"
{ 

    '$functions': ['DataClass2.cs'],

    'propertyName': .mult('$.prop1', 2)

}".Replace("'", "\"")
 .Replace("`", "'")
;
            var source = "{ 'prop1':3 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 6.0D);
        }

        [TestMethod]
        public void TestCoalesce()
        {
            var expected = @"
{ 
    'propertyName': '$.prop1' ?? '$.prop2' ?? '$.prop3'

}".Replace("'", "\"")
 .Replace("`", "'")
;
            var source = "{ 'prop3':3 }".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 3);
        }

        [TestMethod]
        public void TestMethodMerge()
        {
            var expected = @"
{ 
    '@var1' : '$.prop1', 
    'propertyName': .get('src2', '$[?(@.Id == @@var1)]' @string)

}".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ 'prop1':2 }".Replace("'", "\"");
            var source2 = "[ { 'Id':1, Name:'name1'}, { 'Id':2, Name:'name2' }, { 'Id':3, Name:'name3' } ]".Replace("'", "\"");
            var src = new SourceJson[] { SourceJson.GetFromText(source1), SourceJson.GetFromText(source2, "src2") };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["propertyName"]["Name"], "name2");
        }


        [TestMethod]
        public void TestSum()
        {
            var expected = @"
{ 'prices': .sum('$..n') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ 'prices': [{'n' : 1}, {'n' : 2}, {'n' : 3}] }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["prices"], 6);
        }


        [TestMethod]
        public void Testconcat()
        {
            var expected = @"
{ 'result': .concat('$..n', null, null) } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ 'prices': [{'n' : 1}, {'n' : 2}, {'n' : 3}] }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], "123");
        }

        [TestMethod]
        public void TestCrc32()
        {
            var expected = @"
{ 'result': .crc32('toto') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], 281847025);
        }

        [TestMethod]
        public void TestId()
        {
            var expected = @"
{ 'result': .uuid() } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            var g = (Guid)result.TokenResult["result"];
            Assert.AreNotEqual(g, null);
        }

        [TestMethod]
        public void TestFormatInteger()
        {

            var expected = @"
{ 'result': .format(103254895, 'C', 'fr-FR') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], "103 254 895,00 €");
        }

        [TestMethod]
        public void TestParsedate()
        {

            var expected = @"
{ 'result': .parsedate('Freitag, 31. Oktober 2008', 'de-DE') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], new DateTime(2008, 10, 31));
        }

        [TestMethod]
        public void TestTobase64()
        {

            var expected = @"
{ 'result': .tobase64('test') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], "dGVzdA==");
        }

        [TestMethod]
        public void TestFrombase64()
        {

            var expected = @"
{ 'result': .Frombase64('dGVzdA==') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], "test");
        }

        [TestMethod]
        public void TestGetNow()
        {

            var expected = @"
{ 'result': .now(false) } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "{ }".Replace("'", "\"");

            var dte1 = DateTime.Now;
            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);

            var dte = ((JValue)result.TokenResult["result"]).Value<DateTime>();

            Assert.AreEqual(dte>dte1, true);
        }

        [TestMethod]
        public void TestDistinct()
        {

            var expected = @"
{ 'result': .distinct('$') } 
".Replace("'", "\"")
 .Replace("`", "'")
;
            var source1 = "[1,2,1,3]".Replace("'", "\"");

            var src = new SourceJson[] { SourceJson.GetFromText(source1) };
            RuntimeContext result = Test(expected, src);
            Assert.AreEqual(result.TokenResult["result"], "test");
        }


        private static RuntimeContext Test(string templatePayload, SourceJson[] sources, params (string, Type)[] services)
        {
            
            var src = new Sources(sources[0]);
            for (int i = 1; i < sources.Length; i++)
                src.Add(sources[i]);

            var template = GetProvider(templatePayload, services);

            if (!template.Diagnostics.Success)
            {
                var error = template.Diagnostics.Errors.First();
                throw new Exception(error.Message);
            }

            var result = template.Transform(src);

            return result;
        }


        private static JsltTemplate GetProvider(string payloadTemplate, params (string, Type)[] services)
        {

            StringBuilder sb = new StringBuilder(payloadTemplate.Replace('\'', '"').Replace('§', '\''));

            var configuration = new TranformJsonAstConfiguration()
            {
                
            };
            foreach (var item in services)
                configuration.Services.ServiceDiscovery.AddService(item.Item2, item.Item1);

            TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);
            JsltTemplate template = Templateprovider.GetTemplate(sb, string.Empty);

            return template;

        }


    }

}