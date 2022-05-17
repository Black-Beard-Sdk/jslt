using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Bb.Sql;
using Oldtonsoft.Json;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Jslt.Output.StoreSql
{

    public class Outputs
    {


        static Outputs()
        {

            // Parse all loaded assemblies and resolve all DbProviderFactory
            var list = ResolveFactoryHelper.GetFactoriesFromLoadedAssemblies();

            // Register the factories
            list.RegisterFactories();

        }

        [JsltExtensionMethod("to_sqlserver", ForOutput = FunctionKindEnum.Output)]
        public static StringBuilder ExecuteToSqlServer(RuntimeContext ctx, string connection)
        {

            var source = ctx.TokenResult;
            var result = new StringBuilder();

            //JsonSchema schemaObject = JsonSchema.FromSampleJson(source.ToString());
            //var datasPayload = schemaObject.ToJson();
            //var datas = JObject.Parse(datasPayload);

            //var visitor = new JsonSchemaVisitor();
            //visitor.Visit(schemaObject);


            return result;

        }

    }

}
