﻿using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Bb.Sql;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
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

        [JsltExtensionMethod("to_sqlserver", ForOutput = true)]
        public static StringBuilder ExecuteToSqlServer(RuntimeContext ctx, string connection)
        {

            var source = ctx.TokenResult;
            var result = new StringBuilder();

            var schemaObject = JsonSchema.FromSampleJson(source.ToString());
            var datasPayload = schemaObject.ToJson();
            var datas = JObject.Parse(datasPayload);




            return result;

        }

    }

}