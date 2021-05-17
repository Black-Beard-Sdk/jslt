using Bb.CommandLines.Validators;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Bb.CommandLines
{
    public static class Helper
    {


        public static string TrimPath(this string self)
        {

            var o = self.Trim();

            if (o.StartsWith('"') && o.EndsWith('"'))
                o =self.Trim().Trim('"');

            if (o.StartsWith('\'') && o.EndsWith('\''))
                o = self.Trim().Trim('\'');

            return o;

        }

        //static Helper()
        //{
        //    var _path = new FileInfo(typeof(Helper).Assembly.Location).Directory.FullName;
        //    filename = Path.Combine(_path, "mem.json");
        //}

        //public static void Load()
        //{

        //    if (File.Exists(filename))
        //    {
        //        var txt = File.ReadAllText(filename);
        //        Parameters = JsonConvert.DeserializeObject<Parameters>(txt);
        //    }
        //    else
        //        Parameters = new Parameters();

        //    if (!ValidatorExtension.CheckToken())
        //        Helper.Parameters.Token = null;

        //}

        //public static void Save()
        //{
        //    string txt = JsonConvert.SerializeObject(Parameters);
        //    File.WriteAllLines(filename, new List<string>() { txt }, Encoding.UTF8);
        //}

        public static Parameters Parameters { get; set; }

        //public static List<TypeToShow> ConvertDataToShow(List<TypeModel> datas)
        //{
        //    return datas.Select(c => new TypeToShow(c)).ToList();
        //}


        private static readonly string filename;

    }

}
