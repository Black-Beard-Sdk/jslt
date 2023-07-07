using Bb.Json.Jslt.Asts;
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

            var resultTxt = result.ToString();

        }
    }

}