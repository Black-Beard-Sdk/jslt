using Bb;
using Bb.Json.Linq;
using Bb.JsonParser;
using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Bb.LiteDb;
using Bb.Jslt;

namespace Black.Beard.Jslt.UnitTests
{

    [TestClass]
    public class BigLoaderTest : TemplateHelper
    {

        [TestMethod]
        public void Test1()
        {

            JObject model = null;
            var o = new JObject
            (
                new JProperty("p1", 1),
                new JProperty("p2", new JObject
                (
                    new JProperty("p11", 2)
                ))
            );

            using var loader = new BigJsonReader(GetFile(o));
            loader.Parse(
                c =>
                {
                    model = (JObject)c.JsonModel;
                });

            Assert.IsNotNull(model);
            Assert.AreEqual(model["p1"], 1);
            Assert.AreEqual(model["p2"]["p11"], 2);

        }

        [TestMethod]
        public void Test2()
        {

            JObject model = null;
            var o = new JObject
            (
                new JProperty("p1", 1),
                new JProperty("p2", new JArray
                (
                    2, 4
                ))
            );

            using var loader = new BigJsonReader(GetFile(o));
            model = (JObject)loader.Select(c => c.JsonModel).FirstOrDefault();

            Assert.IsNotNull(model);
            Assert.AreEqual(model["p1"], 1);

            var a = (JArray)model["p2"];

            Assert.AreEqual(a[0], 2);
            Assert.AreEqual(a[1], 4);

        }

        [TestMethod]
        public void Test3()
        {

            JObject model = null;
            var o = new JObject
            (
                new JProperty("p1", 1),
                new JProperty("p2", new JArray
                (
                    new JObject
                    (
                        new JProperty("p1", 1),
                        new JProperty("p2", new JArray
                        (
                            2, 4
                        ))
                    )
                ))
            );

            using var loader = new BigJsonReader(GetFile(o));
            model = (JObject)loader.Select(c => c.JsonModel).FirstOrDefault();

            Assert.IsNotNull(model);
            Assert.AreEqual(model["p1"], 1);

            var a = (JArray)model["p2"];
            var o2 = (JObject)a[0];

            Assert.AreEqual(o2["p1"], 1);
            Assert.AreEqual(o2["p2"][1], 4);

        }

        [TestMethod]
        public void Test4()
        {

            JArray model = null;
            var o = new JArray
            (
                new JObject
                (
                    new JProperty("p1", 1),
                    new JProperty("p2", new JArray
                    (
                        2, 4
                    ))
                )
            );

            using var loader = new BigJsonReader(GetFile(o));
            loader.Parse(c =>
            {
                model = (JArray)c.JsonModel;
            });

            Assert.IsNotNull(model);
            Assert.AreEqual(model[0]["p1"], 1);
            Assert.AreEqual(model[0]["p2"][1], 4);

        }

        [TestMethod]
        public void Test5()
        {

            JObject model = null;
            var o = new JObject
            (
                new JProperty("a1", new JObject(new JProperty("a12", new JObject(new JProperty("a123", 5))))),
                new JProperty("b1", new JObject(new JProperty("b12", new JObject(new JProperty("b123", 10))))),
                new JProperty("c1", new JObject(new JProperty("c12", new JObject(new JProperty("c123", 10)))))
            );

            using var loader = new BigLoadJsonParser(new BigJsonReader(GetFile(o)))
                .Filter("$.b1.b12.b123");
            model = (JObject)loader.Select(c => c.JsonModel).FirstOrDefault();

            Assert.IsNotNull(model);
            Assert.AreEqual(model.ContainsKey("a1"), false);
            Assert.AreEqual(model.ContainsKey("c1"), false);
            Assert.AreEqual(model.ContainsKey("b1"), true);

        }

        [TestMethod]
        public void Test6()
        {

            List<JToken> model = null;
            var o = new JArray();

            for (int i = 0; i < 1000; i++)
            {
                var j = new JObject
                (
                    new JProperty("a1", i % 3)
                );
                o.Add(j);
            }

            using var loader = new BigJsonReader(GetFile(o), "$.*");
            model = loader.Select(c => c.JsonModel).ToList();

        }



        private static string GetFile(JToken o)
        {
            var filePath = Path.GetTempPath().Combine("unitTest-", System.Guid.NewGuid().ToString(), ".json");
            filePath.Save(o.ToString());
            return filePath;

        }


    }


}
