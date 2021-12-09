using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace Bb
{

    public static partial class ContentHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string LoadContentFromText(this byte[] text)
        {

            string textContents = string.Empty;
            System.Text.Encoding encoding = null;

            using (MemoryStream fs = new MemoryStream(text))
            {

                Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                    encoding = System.Text.Encoding.GetEncoding(cdet.Charset);
                else
                    encoding = System.Text.Encoding.UTF8;

                fs.Position = 0;

                byte[] ar = new byte[text.Length];
                fs.Read(ar, 0, ar.Length);
                textContents = encoding.GetString(ar);
            }

            if (textContents.StartsWith("ï»¿"))
                textContents = textContents.Substring(3);

            if (encoding != System.Text.Encoding.UTF8)
            {
                var datas = System.Text.Encoding.UTF8.GetBytes(textContents);
                textContents = System.Text.Encoding.UTF8.GetString(datas);
            }

            StringBuilder sb = new StringBuilder(textContents.Length);
            for (int i = 0; i < textContents.Length; i++)
            {
                var c = textContents[i];
                if ((int)c != 65279)
                    sb.Append(c);
            }

            return sb.ToString();

        }

        /// <summary>
        /// encode the specified <see cref="string"/> in base 64 encoded value
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ConvertToBase64(this string self)
        {

            if (string.IsNullOrEmpty(self))
                return string.Empty;

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(self);
            var result = Convert.ToBase64String(bytes);
            return result;
        }

        /// <summary>
        /// decode the specified base 64 <see cref="string"/> encoded value.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ConvertFromBase64(this string self)
        {

            if (string.IsNullOrEmpty(self))
                return string.Empty;

            byte[] bytes = Convert.FromBase64String(self); ;
            string result = System.Text.Encoding.UTF8.GetString(bytes);

            return result;

        }

        /// <summary>
        /// convert the <see cref="Object"/> in <see cref="JToken" />
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static JToken ConvertToJson(this object self)
        {
            return JToken.FromObject(self);
        }

        /// <summary>
        /// convert the <see cref="StringBuilder"/> in <see cref="JToken" />
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static JToken ConvertToJson(this StringBuilder self)
        {
            return JToken.Parse(self.ToString());
        }

        /// <summary>
        /// convert the <see cref="string"/> in <see cref="JToken" />
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static JToken ConvertToJson(this string self)
        {
            return JToken.Parse(self);
        }

        /// <summary>
        /// Read the <see cref="MemoryStream" /> and return the result in <see cref="string"/>
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ConvertToString(this MemoryStream self)
        {
            return self.ToArray().LoadContentFromText();
        }

        public static string Serialize(this object self, Formatting formatting = Formatting.Indented)
        {
            string json = JsonConvert.SerializeObject(self, Formatting.Indented, new StringEnumConverter());
            return json;
        }

        public static TargetType Deserialize<TargetType>(this string self)
        {
            TargetType instance = JsonConvert.DeserializeObject<TargetType>(self);
            return instance;
        }

    }


}
