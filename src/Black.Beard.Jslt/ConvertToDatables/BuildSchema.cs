using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace Bb.ConvertToDatables
{

    public class BuildSchema
    {

        public BuildSchema()
        {

        }

        public Parser ParseTemplate(JToken schema)
        {

            var p = new Parser(null, new StructureSchema(new DataSet()));

            if (schema is JObject o)
            {

                foreach (var item in o.Properties().Where(c => c.Name == "$schema"))
                    p.Schema.Populate(item.Value);

                ParseObjectProperties(o, p);

                p.Initialize();

            }


            return p;
        }

        private void ParseObjectProperties(JObject o, Parser parser)
        {

            foreach (var item in o.Properties())
            {

                if (item.Name.ToLower() == "$schema" && item.Value is JObject schema)
                {
                    // Managed in root   
                }
                else if (item.Name.ToLower() == "$news" && item.Value is JArray arrNewLignes)
                {
                    foreach (var item3 in arrNewLignes)
                    {
                        string tableName = item3.ToString();
                        parser.AppendNewLine(tableName);
                    }
                }
                else
                {

                    if (item.Value is JObject oo)
                    {
                        if (oo.Properties().Any(c => c.Name == "$path"))
                            ParseMapping(parser, item, oo);

                        else
                        {
                            var parser2 = parser.AddSub(item.Name);
                            ParseObjectProperties(oo, parser2);
                        }
                    }
                    else if (item.Value is JArray arr2)
                    {

                        var parser2 = parser.AddSub(item.Name);
                        parser2.IsArray = true;

                        var item1 = arr2[0];
                        if (item1 is JObject oo2)
                            ParseObjectProperties(oo2, parser2);

                        else
                        {

                        }

                    }

                }

            }

        }

        private void ParseMapping(Parser parser, JProperty item, JObject oo)
        {
            var property = parser.AddProperty(item.Name);

            foreach (var item2 in oo.Properties())
            {
                switch (item2.Name)
                {

                    case "$path":

                        if (item2.Value is JArray a)
                        {
                            foreach (JValue item3 in a)
                                property.AppendTargetPath(item3.Value.ToString(), item.Name, parser.Schema);

                        }

                        break;

                    default:
                        break;
                }
            }

        }

    }


}
