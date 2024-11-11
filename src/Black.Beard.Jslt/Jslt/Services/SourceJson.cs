using Oldtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace Bb.Jslt.Services
{

    public class SourceJson
    {

        /// <summary>
        /// create a new <see cref="SourceJson"/> with data loaded from file.
        /// </summary>
        /// <param name="filename">file path</param>
        /// <param name="name">name of the source. if null, the filename of the file is used.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
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

        /// <summary>
        /// create a new <see cref="SourceJson"/> with data loaded from file.
        /// </summary>
        /// <param name="file">file path</param>
        /// <param name="name">name of the source. if null, the filename of the file is used.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
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

        /// <summary>
        /// create a new <see cref="SourceJson"/> with payload.
        /// </summary>
        /// <param name="payload">payload to store</param>
        /// <param name="name">name of the source</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static SourceJson GetFromText(StringBuilder payload, string name = null)
        {
            if (payload == null)
                throw new NullReferenceException(nameof(payload));

            var getDatas = GetDatas(payload.ToString());
            return new SourceJson(getDatas, name);
        }

        /// <summary>
        /// Return a new empty named source
        /// </summary>
        /// <param name="name">name of the source</param>
        /// <returns></returns>
        public static SourceJson GetEmpty(string name = null)
        {
            var getDatas = GetDatas(String.Empty);
            return new SourceJson(getDatas, name);
        }

        /// <summary>
        /// create a new <see cref="SourceJson"/> with payload.
        /// </summary>
        /// <param name="payload">payload to store</param>
        /// <param name="name">name of the source</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static SourceJson GetFromText(string payload, string name = null)
        {
            var getDatas = GetDatas(payload);
            return new SourceJson(getDatas, name);
        }

        /// <summary>
        /// create a new <see cref="SourceJson"/> with payload.
        /// </summary>
        /// <param name="datas">payload to store</param>
        /// <param name="name">name of the source</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static SourceJson GetFromJson(JToken datas, string name = null)
        {
            return new SourceJson(datas, name);
        }

        /// <summary>
        /// create a new <see cref="SourceJson"/> with payload.
        /// </summary>
        /// <param name="payload">payload to store</param>
        /// <param name="name">name of the source</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static SourceJson GetFromJson(System.Text.Json.JsonElement payload, string name = null)
        {
            return new SourceJson(payload.ToString(), name);
        }

        /// <summary>
        /// Name of the source
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Data loaded
        /// </summary>
        public JToken Datas { get; }

        /// <summary>
        /// Return an empty source
        /// </summary>
        public static SourceJson Empty { get; private set; } = new SourceJson(JValue.FromObject(null));


        /// <summary>
        /// implicit conversion of <see cref="StringBuilder"/> to <see cref="SourceJson"/>
        /// </summary>
        /// <param name="sb"></param>
        public static implicit operator SourceJson(StringBuilder sb)
        {
            return SourceJson.GetFromText(sb);
        }

        /// <summary>
        /// implicit conversion of <see cref="string"/> to <see cref="SourceJson"/>
        /// </summary>
        /// <param name="sb"></param>
        public static implicit operator SourceJson(string sb)
        {
            return SourceJson.GetFromText(sb);
        }

        /// <summary>
        /// implicit conversion of <see cref="FileInfo"/> to <see cref="SourceJson"/>
        /// </summary>
        /// <param name="file">file to load</param>
        public static implicit operator SourceJson(FileInfo file)
        {
            return SourceJson.GetFromFile(file);
        }

        /// <summary>
        /// implicit conversion of <see cref="JToken"/> to <see cref="SourceJson"/>
        /// </summary>
        /// <param name="sb"></param>
        public static implicit operator SourceJson(JToken sb)
        {
            return SourceJson.GetFromJson(sb);
        }


        private SourceJson(JToken datas, string name = null)
        {
            this.Name = name = Guid.NewGuid().ToString();
            this.Datas = datas;
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

        private static JToken GetDatas(string payload)
        {

            if (string.IsNullOrEmpty(payload))
                return new JObject();

            return JToken.Parse(Normalize(payload));

        }


    }


}
