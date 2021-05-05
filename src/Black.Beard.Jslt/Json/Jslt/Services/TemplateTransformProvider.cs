using Bb.Json.Jslt.Parser;
using Bb.JSon;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bb.Json.Jslt.Services
{
    public class TemplateTransformProvider
    {

        public TemplateTransformProvider(TranformJsonAstConfiguration configuration = null)
        {

            if (configuration == null)
                configuration = new TranformJsonAstConfiguration();

            this._configuration = configuration;

        }

        public JsltTemplate GetTemplate(StringBuilder sb)
        {

            JToken obj = null;

            for (int i = 0; i < sb.Length; i++)
            {
                char ii = sb[i];
                if (ii == '\r' || ii == '\n')
                {
                    ii = ' ';
                    sb[i] = ii;
                }
            }

            Dictionary<string, JfunctionDefinition> functions = null;
            try
            {
                if (sb.Length > 0)
                {
                    var parser = ScriptParser.ParseString(sb);
                    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);
                    obj = (JObject)parser.Visit(visitor);
                    functions = visitor.EmbeddedFunctions;
                }
            }
            catch (Exception e)
            {
                throw new ParsingJsonException("Failed to parse Json. " + e.Message, e);
            }

            

            TranformJsonTemplateReader reader = new TranformJsonTemplateReader(obj, this._configuration, functions);
            var tree = reader.Tree();

            JsltTemplate result = new JsltTemplate()
            {
                Rule = sb,
                Configuration = this._configuration,
                Rules = reader.Get(tree)
            };

            return result;

        }

        private TranformJsonAstConfiguration _configuration;

    }

}
