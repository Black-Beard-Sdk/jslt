using Bb.Jslt.Asts;
using Bb.Jslt.Parser;
using Bb.Jslt.Services;
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
    public class ToStringUnitTest
    {


        [TestMethod]
        public void TestProperties()
        {

            var expected = @"{	
	""propertyName1"" : ""toto"",
	""propertyName2"" : ""toto"",
	""propertyName3"" : ""toto""
}";

            var i = new JsltObject()
                .Append("propertyName1", "toto".AsJsltConstant())
                .Append("propertyName2", "toto".AsJsltConstant())
                .Append("propertyName3", "toto".AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyInt()
        {

            var expected = @"{	
	""propertyName1"" : 1
}";

            var i = new JsltObject()
                .Append("propertyName1", (1).AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyDecimal()
        {

            var expected = @"{	
	""propertyName1"" : 1,6
}";

            var i = new JsltObject()
                .Append("propertyName1", (1.6).AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyDateTime()
        {

            var n = DateTime.Now;

            var expected = @"{	
	""propertyName1"" : """ + n.ToString() + @"""
}";

            var i = new JsltObject()
                .Append("propertyName1", n.AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyDateTimeOffset()
        {

            var n = DateTimeOffset.Now;

            var expected = @"{	
	""propertyName1"" : """ + n.ToString() + @"""
}";

            var i = new JsltObject()
                .Append("propertyName1", n.AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyUri()
        {

            var expected = @"{	
	""propertyName1"" : ""http://localhost/""
}";

            var i = new JsltObject()
                .Append("propertyName1", new Uri("http://localhost").AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyBytes()
        {

            var expected = @"{	
	""propertyName1"" : ""#A""
}";

            var i = new JsltObject()
                .Append("propertyName1", (new byte[] { 18, 27, 35, 65 }).AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyGuid()
        {

            var expected = @"{	
	""propertyName1"" : ""00000000-0000-0000-0000-000000000000""
}";

            var i = new JsltObject()
                .Append("propertyName1", Guid.Empty.AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertiesWithSource()
        {

            var expected = @"{	
	""$source"" : @body,
	""propertyName1"" : ""toto"",
	""propertyName2"" : ""toto"",
	""propertyName3"" : ""toto""
}";

            var i = new JsltObject()
                .Append("propertyName1", "toto".AsJsltConstant())
                .Append("propertyName2", "toto".AsJsltConstant())
                .Append("propertyName3", "toto".AsJsltConstant())
                ;
            i.Source = "body".AsJsltVariable();

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertiesWithMethod()
        {

            var expected = @"{	
	""$source"" : @body,
	""propertyName1"" : toto(""arg1"", $.PropertyName)
}";

            var i = new JsltObject()
                .Append("propertyName1", "toto".AsJsltFunction("arg1".AsJsltConstant(), "$.PropertyName".AsJsltPath()))
                ;
            i.Source = "body".AsJsltVariable();

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestArray()
        {

            var expected = @"[	
	""toto""
]";

            var i = new JsltArray()
                .Append("toto".AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestArray2()
        {

            var expected = @"[	
	""toto"", 
	""toto""
]";

            var i = new JsltArray()
                .Append("toto".AsJsltConstant())
                .Append("toto".AsJsltConstant())
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestArray3()
        {

            var expected = @"[	
	""toto"", 
	{	
		""propertyName1"" : toto(""arg1"", $.PropertyName)
	}
]";

            var i = new JsltArray()
                .Append("toto".AsJsltConstant())
                .Append(new JsltObject()
                .Append("propertyName1", "toto".AsJsltFunction("arg1".AsJsltConstant(), "$.PropertyName".AsJsltPath())))
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }

        [TestMethod]
        public void TestPropertyVariable()
        {

            var expected = @"[	
	{	
		""$source"" : @body,
		""key"" : $.Key
	}
]";

            var i = new JsltArray()
                .Append(new JsltObject()
                    .SetSource("body".AsJsltVariable())
                    .Append("key", "$.Key".AsJsltPath())
                    )
                ;

            var payload = i.ToString();

            Assert.AreEqual(expected, payload);

        }


    }

}