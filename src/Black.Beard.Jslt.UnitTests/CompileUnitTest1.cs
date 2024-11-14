using Bb;
using Bb.Jslt.Asts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bb.Json.Linq;
using System;
using System.Data.Common;
using System.Globalization;
using Bb.Jslt;

namespace Black.Beard.Jslt.UnitTests
{
    [TestClass]
    public class CompileUnitTest1 : TemplateHelper
    {


        [TestMethod]
        public void TestMObjectWithPropertyString()
        {

            var template = "{ 'propertyName': 'toto' }".Replace("'", "\"");
            var source = "{ }";

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            var o2 = result.TokenResult;

            Assert.AreEqual(o2["propertyName"], "toto");

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber()
        {

            var template = "{ 'propertyName': 6 }".Replace("'", "\"");
            var source = "{ }";

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            var o2 = result.TokenResult;

            Assert.AreEqual(o2["propertyName"], 6L);

        }

        [TestMethod]
        public void TestMObjectWithPropertyNumber2()
        {

            var template = "{ 'propertyName': 6.7 }".Replace("'", "\"");
            var source = "{ }";

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            var o2 = result.TokenResult;

            Assert.AreEqual(o2["propertyName"], 6.7D);

        }

        [TestMethod]
        public void TestMObjectWithPropertyArray()
        {

            var template = "{ 'propertyName': [6.6, 'test'] }".Replace("'", "\"");
            var source = "{ }";

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"][0], 6.6);

        }

        [TestMethod]
        public void TestMObjectWithFunctionStatic()
        {

            var template = "{ 'propertyName': crc32('test') }".Replace("'", "\"");
            var source = "{ }";

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            Action<TranformJsonAstConfiguration> initializerConfiguration = (c) =>
            {
                c.AddAssembly(typeof(DataClass));
            };
            RuntimeContext result = Test(template, src, initializerConfiguration);
            Assert.AreEqual(result.TokenResult["propertyName"], 3632233996);

        }

        [TestMethod]
        public void TestMObjectWithFunction()
        {

            var template = "{ 'propertyName': myMethod(6.6, 2.0) }".Replace("'", "\"");
            var source = "{ }";
            Action<TranformJsonAstConfiguration> initializerConfiguration = (c) =>
            {
                c.AddAssembly(typeof(DataClass));
            };
            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };  
            RuntimeContext result = Test(template, src, initializerConfiguration);
            Assert.AreEqual(result.TokenResult["propertyName"]["Uuid"], 6.6);
        }

        [TestMethod]
        public void TestPropertyVariable()
        {

            string source = @"[{ 'Key': 2 }, { 'Key': 3 } ]".Replace("'", "\"");

            var i = new JsltArray()
                .Append(new JsltObject()
                    .SetSource("body".AsJsltVariable())
                    .Append("key", "$.Key".AsJsltPath())
            );

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source, "body"));
            };
            RuntimeContext result = Test(i,  src);
            var a = result.TokenResult as JArray;

            Assert.AreEqual(a.Count, 2);
            Assert.AreEqual(a[0]["key"], 2);
            Assert.AreEqual(a[1]["key"], 3);

        }

        [TestMethod]
        public void TestJPath()
        {

            var template = "{ 'propertyName': $.prop1.SubPprop1 }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 2);

        }

        [TestMethod]
        public void TestJPathUnary()
        {
            var template = "{ 'propertyName': $.prop1 }".Replace("'", "\"");
            var source = "{ 'prop1': false }".Replace("'", "\"");

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], false);

        }

        [TestMethod]
        public void TestJPathBinaryAddDecimal()
        {

            var template = "{'propertyName': $.prop1.SubPprop1 + $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2.5 }, 'prop2':3 }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 5.5);

        }

        [TestMethod]
        public void TestJPathBinaryAdd()
        {

            var template = "{'propertyName': $.prop1.SubPprop1 +  $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 5);

        }

        [TestMethod]
        public void TestJPathconcat()
        {

            var template = "{'propertyName': $.prop1  +  $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1': 'hello', 'prop2':' world' }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], "hello world");
        
        }

        [TestMethod]
        public void TestJPathBinarySubstractDecimal()
        {
            var template = "{'propertyName': $.prop1 - $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1':2.5, 'prop2':1 }".Replace("'", "\"");

            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 1.5);
        }

        [TestMethod]
        public void TestJPathBinarySubstractInt()
        {
            var template = "{'propertyName': $.prop1.SubPprop1 - $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");
            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], -1);
        }

        [TestMethod]
        public void TestJPathBinaryMultiplyInt()
        {
            var template = "{'propertyName': $.prop1.SubPprop1 * $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':2 }, 'prop2':3 }".Replace("'", "\"");
            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 6);
        }

        [TestMethod]
        public void TestJPathBinaryModuloInt()
        {
            var template = "{'propertyName': $.prop1.SubPprop1 % $.prop2 }".Replace("'", "\"");
            var source = "{ 'prop1': { 'SubPprop1':7 }, 'prop2':3 }".Replace("'", "\"");
            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 1);
        }

        [TestMethod]
        public void TestCaseWhen()
        {
            var template = @"
            {
                'propertyName': when($.prop1) 
                {
                    '1' : { 'sub1' : 11 },
                    '3' : { 'sub1' : 22 }
                }
            }"
            .Replace("'", "\"")
            .Replace("`", "'");

            var source = "{ 'prop1':3 }".Replace("'", "\"");
            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"]["sub1"], 22);
        }

        [TestMethod]
        public void TestMethodCompiled()
        {
            var template = @"
            { 
                '$functions': ['DataClass2.cs'],
                'propertyName': mult($.prop1, 2)
            }".Replace("'", "\"")
             .Replace("`", "'");
            var source = "{ 'prop1':3 }".Replace("'", "\"");
            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 6.0D);
        }

        [TestMethod]
        public void TestCoalesce()
        {
            var template = @"
            { 
                'propertyName': $.prop1 ?? $.prop2 ?? $.prop3

            }".Replace("'", "\"")
             .Replace("`", "'");
            var source = "{ 'prop3':3 }".Replace("'", "\"");
            Action<Sources> src = (s) =>
            {
                s.SetSource(SourceJson.GetFromText(source));
            };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"], 3);
        }

        [TestMethod]
        public void TestJpath1()
        {
            var template = @"
            { 
                'propertyName': $[?(@.Id == 2)]

            }".Replace("'", "\"")
             .Replace("`", "'");

            var source = "[ { 'Id':1, Name:'name1'}, { 'Id':2, Name:'name2' }, { 'Id':3, Name:'name3' } ]".Replace("'", "\"");
            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["propertyName"]["Name"], "name2");
        }

        [TestMethod]
        public void TestJpath2()
        {
            var template = @"
            { 
                'var1:' : [ { 'Id':1, 'Name':'name1'}, { 'Id':2, 'Name':'name2' }, { 'Id':3, 'Name':'name3' } ],
                'propertyName': var1:$[?(@.Id == 2)]

            }".Replace("'", "\"")
             .Replace("`", "'");

            RuntimeContext result = Test(template, null);
            Assert.AreEqual(result.TokenResult["propertyName"]["Name"], "name2");
        }

        [TestMethod]
        public void TestVariable()
        {
            var template = @"
            { 
                'var1:' : 2, 
                'propertyName': var1: #string

            }".Replace("'", "\"")
             .Replace("`", "'");            

            RuntimeContext result = Test(template, false);
            Assert.AreEqual(result.TokenResult["propertyName"], "2");
        }     

        [TestMethod]
        public void TestSum()
        {
            var template = @"{ 'prices': sum($..n) }"
                .Replace("'", "\"")
                .Replace("`", "'");
            var source1 = "{ 'prices': [{'n' : 1}, {'n' : 2}, {'n' : 3}] }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["prices"], 6);
        }

        [TestMethod]
        public void Testconcat()
        {
            var template = @"
            { 'result': concat($..n, null, null) } 
            ".Replace("'", "\"")
             .Replace("`", "'");
            var source1 = "{ 'prices': [{'n' : 1}, {'n' : 2}, {'n' : 3}] }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["result"], "123");
        }

        [TestMethod]
        public void TestCrc32()
        {
            var template = @"{ 'result': crc32('toto') }"
                .Replace("'", "\"")
                .Replace("`", "'");
            var source1 = "{ }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["result"], 281847025);
        }

        [TestMethod]
        public void TestId()
        {
            var template = @"
            { 'result': uuid() } 
            ".Replace("'", "\"")
             .Replace("`", "'");

            var source1 = "{ }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            var g = (Guid)result.TokenResult["result"];
            Guid dright = default;
            Assert.AreNotEqual(g, dright);
        }

        [TestMethod]
        public void TestFormatInteger()
        {

            var template = @"
            { 'result': format(103254895, 'C', 'fr-FR') } 
            ".Replace("'", "\"")
             .Replace("`", "'");
            var source1 = "{ }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["result"], "103 254 895,00 €");
        }

        [TestMethod]
        public void TestParsedate()
        {

            var template = @"
            { 'result': parsedate('Freitag, 31. Oktober 2008', 'de-DE') } 
            ".Replace("'", "\"")
             .Replace("`", "'");
            var source1 = "{ }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["result"], new DateTime(2008, 10, 31));
        }

        [TestMethod]
        public void TestTobase64()
        {

            var template = @"
            { 'result': tobase64('test') } 
            ".Replace("'", "\"")
             .Replace("`", "'");
            var source1 = "{ }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["result"], "dGVzdA==");
        }

        [TestMethod]
        public void TestFrombase64()
        {

            var template = @"
            { 'result': Frombase64('dGVzdA==') } 
            ".Replace("'", "\"")
             .Replace("`", "'");
            var source1 = "{ }".Replace("'", "\"");

            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            Assert.AreEqual(result.TokenResult["result"], "test");
        }

        [TestMethod]
        public void TestGetNow()
        {

            var template = @"
            { 'result': now(false) } 
            ".Replace("'", "\"")
             .Replace("`", "'");
            var source1 = "{ }".Replace("'", "\"");

            var dte1 = DateTime.Now;
            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);

            var dte = (result.TokenResult["result"]).Value<DateTime>();

            Assert.AreEqual(dte > dte1, true);
        }

        [TestMethod]
        public void TestDistinct()
        {

            var template = @" { 'result': distinct($, $.*) }"
                    .Replace("'", "\"")
                    .Replace("`", "'");

            var source1 = "[1,2,1,3]".Replace("'", "\"");
            Action<Sources> src = (s) => { s.SetSource(SourceJson.GetFromText(source1)); };
            RuntimeContext result = Test(template, src);
            var j = (JArray)result.TokenResult["result"];
            Assert.AreEqual(j.Count, 3);
            Assert.AreEqual(j[0], 1);
            Assert.AreEqual(j[1], 2);
            Assert.AreEqual(j[2], 3);
        }

        [TestMethod]
        public void TestDirectiveAssemblies()
        {

            var db = "c:\\temp\\test.db";
            var dbFile = db.AsFile();

            if (dbFile.Exists)
                dbFile.Delete();

            else if (!dbFile.Directory.Exists)
                dbFile.Directory.Create();


            var cnx = $"Data Source={db}";

            var instance = System.Data.SQLite.SQLiteFactory.Instance;
            using (DbConnection cnn = instance.CreateConnection())
            {

                cnn.ConnectionString = cnx;
                cnn.Open();

                using (var cmd = instance.CreateCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "CREATE TABLE table1 (key INTEGER PRIMARY KEY, value TEXT)";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = instance.CreateCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "INSERT INTO table1 VALUES(1, 'test1')";
                    cmd.ExecuteNonQuery();
                }
            }


            string sql = "SELECT * FROM table1";

            var template = new JsltObject()
                 .Append(new JsltDirectives()
                     .SetAssemblies("Microsoft.Data.Sqlite")
                     .SetAssemblies("Black.Beard.Jslt.Services")
                     .SetCulture(CultureInfo.CurrentCulture))
                 .Append(new JsltVariable("cnx").SetValue(new JsltFunctionCall("connectsql", "Microsoft.Data.Sqlite".AsJsltConstant(), cnx.AsJsltConstant())))
                 .Append(new JsltProperty("Data").SetValue(new JsltFunctionCall("readsql", "cnx".AsJsltVariable(), sql.AsJsltConstant())))
                 ;

            RuntimeContext result = Test(template, false);
            var a = result.TokenResult as Bb.Json.Linq.JObject;
            var b = a["Data"][0] as Bb.Json.Linq.JObject;

            Assert.AreEqual(b["$_line"], 1);
            Assert.AreEqual(b["value"], "test1");

        }

        [TestMethod]
        public void TestDirectivePackage()
        {

            var db = "c:\\temp\\test.db";
            var dbFile = db.AsFile();

            if (dbFile.Exists)
                dbFile.Delete();

            else if (!dbFile.Directory.Exists)
                dbFile.Directory.Create();


            var cnx = $"Data Source={db}";

            var instance = System.Data.SQLite.SQLiteFactory.Instance;
            using (DbConnection cnn = instance.CreateConnection())
            {

                cnn.ConnectionString = cnx;
                cnn.Open();

                using (var cmd = instance.CreateCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "CREATE TABLE table1 (key INTEGER PRIMARY KEY, value TEXT)";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = instance.CreateCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "INSERT INTO table1 VALUES(1, 'test1')";
                    cmd.ExecuteNonQuery();
                }
            }

            string sql = "SELECT * FROM table1";

            var template = new JsltObject()
                 .Append(new JsltDirectives()
                     .SetPackages("Microsoft.Data.SqlClient")
                     .SetAssemblies("Black.Beard.Jslt.Services")
                     .SetCulture(CultureInfo.CurrentCulture))
                 .Append(new JsltVariable("cnx").SetValue(new JsltFunctionCall("connectsql", "Microsoft.Data.SqlClient".AsJsltConstant(), cnx.AsJsltConstant())))
                 .Append(new JsltProperty("Data").SetValue(new JsltFunctionCall("readsql", "cnx".AsJsltVariable(), sql.AsJsltConstant())))
                 ;

            RuntimeContext result = Test(template);
            var a = result.TokenResult as JObject;
            var b = a["Data"][0] as JObject;

            Assert.AreEqual(b["$_line"], 1);
            Assert.AreEqual(b["value"], "test1");

        }

    }

}