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
        /// Loads the content of the file.
        /// </summary>
        /// <param name="rootSource">The root source.</param>
        /// <returns></returns>
        public static string LoadContentFromFile(params string[] rootSource)
        {
            string _path = System.IO.Path.Combine(rootSource);
            return LoadContentFromFile(_path);
        }

        public static string LoadContentFromFile(this FileInfo self)
        {
            return LoadContentFromFile(self.FullName);
        }

        public static string LoadFile(this string _path)
        {
            return File.ReadAllText(_path);
        }

        public static string LoadContentFromFile(this string _path)
        {

            string fileContents = string.Empty;
            System.Text.Encoding encoding = null;
            FileInfo _file = new FileInfo(_path);

            using (FileStream fs = _file.OpenRead())
            {

                Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                    encoding = System.Text.Encoding.GetEncoding(cdet.Charset);
                else
                    encoding = System.Text.Encoding.UTF8;

                fs.Position = 0;

                byte[] ar = new byte[_file.Length];
                fs.Read(ar, 0, ar.Length);
                fileContents = encoding.GetString(ar);
            }

            if (fileContents.StartsWith("ï»¿"))
                fileContents = fileContents.Substring(3);

            if (encoding != System.Text.Encoding.UTF8)
            {
                var datas = System.Text.Encoding.UTF8.GetBytes(fileContents);
                fileContents = System.Text.Encoding.UTF8.GetString(datas);
            }

            StringBuilder sb = new StringBuilder(fileContents.Length);
            for (int i = 0; i < fileContents.Length; i++)
            {
                var c = fileContents[i];
                if ((int)c != 65279)
                    sb.Append(c);
            }

            return sb.ToString();

        }

        /// <summary>
        /// Save the content in the specified file.
        /// If the directory don't exist. it is created.
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="content"></param>
        public static void Save(this string _path, string content)
        {

            var file = new FileInfo(_path);
            if (file.Directory != null && !file.Directory.Exists)
                file.Directory.Create();

            File.WriteAllText(file.FullName, content);

        }

        /// <summary>
        /// Save the content in the specified file.
        /// If the directory don't exist. it is created.
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="content"></param>
        public static void Save(this string _path, StringBuilder content)
        {

            var file = new FileInfo(_path);
            if (!file.Directory.Exists)
                file.Directory.Create();

            File.WriteAllText(file.FullName, content.ToString());

        }
        
    }


}
