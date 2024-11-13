using Bb.ComponentModel;
using Bb.ComponentModel.Accessors;
using Bb.Attributes;
using Bb.Jslt.CustomServices;
using Bb.Jslt.Services;
using Bb.Util;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using static Refs.System.Net.WebSockets;

namespace Bb.Jslt.Services.Sql
{

    public static partial class ServicesSql
    {
        
        [JsltExtensionMethod("connectsql")]
        [JsltExtensionMethodParameter("client", "client key")]
        [JsltExtensionMethodParameter("connection", "connection")]
        [JsltExtensionMethodParameter("sql", "sql query")]
        public static JToken CreateSqlConnexion(RuntimeContext ctx, string client, string connexion)
        {

            DbProviderFactory clientFactory = Get(client);

            using (var cnx = clientFactory.CreateConnection())
            {
                cnx.ConnectionString = connexion;
                try
                {
                    cnx.Open();
                    return new JObject()
                    {
                        { "client", client },
                        { "connection", connexion }
                    };
                }
                catch (Exception ex)
                {
                    ctx.Diagnostics.AddError(ctx.GetCurrentLocation(), connexion, $"the connection '{connexion}' can't be resolved.");
                    throw ex;
                }

            }

        }


        [JsltExtensionMethod("readsql")]
        [JsltExtensionMethodParameter("client", "client key")]
        [JsltExtensionMethodParameter("connection", "connection")]
        [JsltExtensionMethodParameter("sql", "sql query")]
        public static JToken ExecuteSql(RuntimeContext ctx, JObject connection, string sql)
        {

            //var datas = RuntimeContext.GetVariable(ctx, connectionName, typeof(JObject), ctx.GetCurrentLocation());

            var client = connection["client"].Value<string>();
            var cnx = connection["connection"].Value<string>();

            var clientFactory = DbProviderFactories.GetFactory(client);
            var result = ReadSql(ctx, clientFactory, cnx, sql);

            return result;

        }


        private static JArray ReadSql(RuntimeContext ctx, DbProviderFactory factory, string connexion, string sql)
        {

            List<JToken> list = new List<JToken>(500);

            using (var cnx = factory.CreateConnection())
            {

                cnx.ConnectionString = connexion;

                try
                {
                    cnx.Open();
                }
                catch (Exception)
                {
                    ctx.Diagnostics.AddError(ctx.GetCurrentLocation(), connexion, $"the connection '{connexion}' can't be resolved.");
                    return new JArray();
                }

                using (var cmd = factory.CreateCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = sql;
                    int line = 0;

                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {

                            line++;

                            var o = new JObject
                            {
                                new JProperty("$_line", line)
                            };

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                var n = reader.GetName(i);
                                string name = ServiceCsv.GetLabel(n);

                                var value = reader.GetValue(i);

                                o.Add(new JProperty(name, value));

                            }

                            list.Add(o);

                        }

                }

            }

            var result = new JArray(list);

            return result;

        }



        private static DbProviderFactory Get(string @namespace)
        {

            try
            {
                DbProviderFactory clientFactory = DbProviderFactories.GetFactory(@namespace);
                return clientFactory;
            }
            catch (Exception)
            {

                var instance = GetDbProviderFactory(@namespace);
                if (instance != null)
                {
                    DbProviderFactories.RegisterFactory(@namespace, instance);
                    return instance;
                }

                throw;
            }

        }

        private static DbProviderFactory GetDbProviderFactory(string @namespace)
        {

            var types = TypeDiscovery.Instance.GetTypesAssignableFrom(typeof(DbProviderFactory)).ToList();

            foreach (var item in types)
            {
                if (item.Namespace == @namespace)
                {
                    var instance = GetDbProviderFactory(item);
                    if (instance != null)
                        return instance;
                }
            }

            return null;
        }

        private static DbProviderFactory GetDbProviderFactory(Type type)
        {

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(c => typeof(DbProviderFactory).IsAssignableFrom(c.PropertyType))
                .ToList();
            if (properties.Any())
                return (DbProviderFactory)properties[0].GetValue(null);

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(c => typeof(DbProviderFactory).IsAssignableFrom(c.FieldType))
                .ToList();
            if (fields.Any())
                return (DbProviderFactory)fields[0].GetValue(null);

            return null;

        }


    }

}
