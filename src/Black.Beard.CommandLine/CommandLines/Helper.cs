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
             
        public static Parameters Parameters { get; set; }

        //public static List<TypeToShow> ConvertDataToShow(List<TypeModel> datas)
        //{
        //    return datas.Select(c => new TypeToShow(c)).ToList();
        //}

    }

}
