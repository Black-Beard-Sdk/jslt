using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Jslt.Services.Sql
{

    public static partial class ServicesSql
    {


        [JsltExtensionMethod("readsqlserver")]
        [JsltExtensionMethodParameter("connection", "connection")]
        [JsltExtensionMethodParameter("sql", "sql query")]
        public static JToken ExecuteSqlServer(RuntimeContext ctx, string connection, string sql)
        {
            var factory = System.Data.SqlClient.SqlClientFactory.Instance;
            var result = ReadSql(ctx, factory, connection, sql);
            return result;
        }

        private static JArray ReadSql(RuntimeContext ctx, System.Data.SqlClient.SqlClientFactory factory, string connexion, string sql)
        {

            var resultValue = new JArray();

            using (var cnx = factory.CreateConnection())
            {

                cnx.ConnectionString = connexion;

                try
                {
                    cnx.Open();
                }
                catch (Exception)
                {
                    ctx.Diagnostics.AddError(String.Empty, null, connexion, $"the connection '{connexion}' can't be resolved.");
                    return resultValue;
                }

                using (var cmd = factory.CreateCommand())
                {

                    cmd.CommandText = sql;
                    int line = 0;

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            line++;

                            var o = new JObject();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                var n = reader.GetName(i);
                                string name = GetLabel(n);

                                var value = reader.GetValue(i);

                                o.Add(new JProperty(name, value));

                            }

                            resultValue.Add(o);

                        }

                    }

                }

            }

            return resultValue;

        }

        public static string GetLabel(string n)
        {

            var sb = new StringBuilder(n.Length);

            foreach (var c in n)
            {
                var p = (int)c;

                //if (p == 65279) // Bom // { } 
                if (_accepted.TryGetValue(c, out char v))
                    sb.Append(v);

            }

            return sb.ToString()
                 .Replace("___", "_")
                 .Replace("__", "_");

        }

        private static Dictionary<char, char> _accepted = build();

        private static Dictionary<char, char> build()
        {

            var dic = new Dictionary<char, char>();

            Add(dic, (int)'a', (int)'z');
            Add(dic, (int)'A', (int)'Z');
            Add(dic, (int)'0', (int)'9');

            dic.Add(' ', '_');
            dic.Add('\'', '_');
            dic.Add('"', '_');
            dic.Add('é', 'e');
            dic.Add('è', 'e');
            dic.Add('ë', 'e');
            dic.Add('î', 'i');
            dic.Add('ï', 'i');
            dic.Add('Ï', 'I');
            dic.Add('Ö', 'O');
            dic.Add('Ü', 'U');
            dic.Add('ô', 'o');
            dic.Add('à', 'a');
            dic.Add('ê', 'e');
            dic.Add('ñ', 'n');
            dic.Add('Ñ', 'N');
            dic.Add('¡', 'i');
            dic.Add('á', 'a');
            dic.Add('í', 'i');
            dic.Add('ó', 'o');
            dic.Add('ú', 'u');
            dic.Add('Á', 'A');
            dic.Add('É', 'E');
            dic.Add('Í', 'I');
            dic.Add('Ó', 'O');
            dic.Add('Ú', 'U');
            dic.Add('ä', 'a');
            dic.Add('ö', 'o');
            dic.Add('Ä', 'A');
            dic.Add('Ë', 'E');

            return dic;

        }

        private static void Add(Dictionary<char, char> dic, int s, int e)
        {
            for (int i = s; i <= e; i++)
                dic.Add((char)i, (char)i);
        }

    }

}
