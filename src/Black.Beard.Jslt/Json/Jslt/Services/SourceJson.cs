using Oldtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace Bb.Json.Jslt.Services
{

    public class SourceJson
    {

        private static JToken GetDatas(string payload)
        {

            if (string.IsNullOrEmpty(payload))
                return new JObject();

            return JToken.Parse(Normalize(payload));

        }

        public static SourceJson GetFromFile(string filename, string name = null)
        {

            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(filename);

            // Charge and evaluate source
            var filePathSource = new FileInfo(filename);
            if (!filePathSource.Exists)
                throw new FileNotFoundException(filePathSource.FullName);

            var getDatas = GetDatas(filename.LoadFromFile());

            return new SourceJson(getDatas, name);

        }

        public static SourceJson GetFromFile(FileInfo file, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(file.Name);

            // Charge and evaluate source

            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            var getDatas = GetDatas(file.LoadFromFile());

            return new SourceJson(getDatas, name);

        }

        public static SourceJson GetFromText(StringBuilder payload, string name = null)
        {
            if (payload == null)
                throw new NullReferenceException(nameof(payload));

            var getDatas = GetDatas(payload.ToString());
            return new SourceJson(getDatas, name);
        }

        public static SourceJson GetEmpty(string name = null)
        {
            var getDatas = GetDatas(String.Empty);
            return new SourceJson(getDatas, name);
        }

        public static SourceJson GetFromText(string payload, string name = null)
        {
            var getDatas = GetDatas(payload);
            return new SourceJson(getDatas, name);
        }

        public static SourceJson GetFromJson(JToken payload, string name = null)
        {
            return new SourceJson(payload, name);
        }

        private SourceJson(JToken datas, string name = null)
        {
            this.Name = name;
            this.Datas = datas;
        }

        public string Name { get; }

        public JToken Datas { get; }

        public static SourceJson Empty { get; private set; }

        public static implicit operator SourceJson(StringBuilder sb)
        {
            return SourceJson.GetFromText(sb);
        }

        public static implicit operator SourceJson(string sb)
        {
            return SourceJson.GetFromText(sb);
        }

        public static implicit operator SourceJson(FileInfo file)
        {
            return SourceJson.GetFromFile(file);
        }

        public static implicit operator SourceJson(JToken sb)
        {
            return SourceJson.GetFromJson(sb);
        }


        private static string Normalize(string payload)
        {

            var length = payload.Length;
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {

                char c = payload[i];

                if ((int)c != 65279)
                    sb.Append(c);

            }


            return sb.ToString();

        }


    }


}
