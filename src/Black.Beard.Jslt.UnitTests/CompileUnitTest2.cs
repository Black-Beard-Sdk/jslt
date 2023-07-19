using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.CustomServices;
using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Black.Beard.Jslt.UnitTests
{
    [TestClass]
    public class CompileUnitTest2
    {


        [TestMethod]
        public void TestEscapeCharset()
        {
            var c = new JsltConstant(@"^([A-Za-z0-9]?\s?-?)+$", JsltKind.String);
            var value = c.ToString();
            Assert.AreEqual(value, @"""^([A-Za-z0-9]?\\s?-?)+$""");
        }



        [TestMethod]
        public void TestGenerationOfDirectives()
        {

            var result = new JsltObject();

            var d = new JsltDirectives()
                .SetCulture(CultureInfo.CurrentCulture)
                .Output(c => c.SetFilter("$.value"))
                ;
            result.Append(d);

            result.Append(new JsltProperty() { Name = "value", Value = new JsltConstant(true, JsltKind.Boolean) });

            var resultTxt = result.ToString()
                .Replace("\t", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\"", "'")

                ;

            var expected = "{'$directives' : {'culture' : 'fr-FR','output' : {'filter' : $.value}},'value' : true}";

            Assert.AreEqual(resultTxt, expected);

        }


        [TestMethod]
        public void TestGenerationArray()
        {

            List<JsltBase> list = new List<JsltBase>()
            {
                new JsltConstant("Business", JsltKind.String),
                new JsltConstant("Private", JsltKind.String),
            };
            var result = new JsltFunctionCall("getrandom_in_list", new JsltArray(list));

            string expected = @"getrandom_in_list(['Business', 'Private'])";
            var resultTxt = result.ToString()
                .Replace("\t", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\"", "'")
                .Trim()

                ;
            Assert.AreEqual(resultTxt, expected);

        }

        [TestMethod]
        public void TestUseGetRandomInList()
        {

            HashSet<string> _h = new HashSet<string>() { "Business", "Private" };
            var list = new List<Oldtonsoft.Json.Linq.JToken>();

            foreach (string s in _h)
                list.Add(new Oldtonsoft.Json.Linq.JValue(s));

            var ctx = new RuntimeContext();

            var o = Services.GetRandomInList(ctx, new Oldtonsoft.Json.Linq.JArray(list));
            Assert.IsTrue(_h.Contains(o.ToString()));

        }

        [TestMethod]
        public void TestGenerationArray2()
        {

            HashSet<string> _h = new HashSet<string>() { "Business", "Private" };
            List<JsltBase> list = new List<JsltBase>();

            foreach (string s in _h)
                list.Add(new JsltConstant(s, JsltKind.String));

            var r = new JsltObject();
            r.Append("value", new JsltFunctionCall("getrandom_in_list", new JsltArray(list)));

            var oo = JsltTemplate.GetTemplate(r);
            var r2 = oo.Transform(Sources.GetEmpty());
            var pp = r2.TokenResult["value"].ToString();
            
            Assert.IsTrue(_h.Contains(pp));

        }

    }

}