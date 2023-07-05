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

        

    }

}