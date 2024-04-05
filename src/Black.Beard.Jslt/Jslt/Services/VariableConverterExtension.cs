using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Jslt.Services
{

    //public static class VariableConverterExtension
    //{


    //    static VariableConverterExtension()
    //    {
    //        _hvalues = new HashSet<Type>()
    //        {
    //            typeof(string),
    //            typeof(Uri),
    //            typeof(Guid),
    //            typeof(Byte),
    //            typeof(Byte[]),
    //            typeof(bool),
    //            typeof(double),
    //            typeof(float),
    //            typeof(long),
    //            typeof(ulong),
    //            typeof(int),
    //            typeof(uint),
    //            typeof(short),
    //            typeof(ushort),
    //            typeof(DateTime),
    //            typeof(TimeSpan),
    //        };
    //    }



    //    public static bool ConvertToJvalue(ref object value)
    //    {

    //        if (_hvalues.Contains(value.GetType()))
    //        {

    //            if (value is string s)
    //            {
    //                value = JToken.Parse(s);
    //                return true;
    //            }

    //            value = new JValue(value);
    //            return true;
            
    //        }

    //        return false;

    //    }



    //    public static object Convert(this object value)
    //    {

    //        if (value == null)
    //            return null;

    //        if (ConvertToJvalue(ref value))
    //            return value;

    //        if (value is JToken token)
    //        {

    //            if (value is JValue jv)
    //            {
    //                var jc = jv.Value;
    //                if (ConvertToJvalue(ref jc))
    //                    return jc;
    //            }

    //            if (value is JArray ja)
    //            {

    //                var jc = new JArray();
    //                foreach (var item in ja)
    //                {
    //                    var i2 = item.Convert();
    //                    jc.Add(i2);
    //                }

    //                return jc;
    //            }

    //            var i = token.ToString();
    //            value = JToken.Parse(i);

    //            return value;

    //        }

    //        var vo = JToken.FromObject(value);
    //        return vo;

    //    }


    //    private static HashSet<Type> _hvalues;

    //}

}
