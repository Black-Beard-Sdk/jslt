using System;
using System.IO;
using System.Text;

namespace Bb.Json.Jslt.Builds
{

    public class SourceCode
    {
               
        public static SourceCode GetFromFile(string filename, string name = null)
        {

            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(filename);

            // Charge and evaluate source
            var filePathSource = new FileInfo(filename);
            if (!filePathSource.Exists)
                throw new FileNotFoundException(filePathSource.FullName);

            var getDatas = filename.LoadContentFromFile();

            return new SourceCode(getDatas, name) { Filename = filename };

        }

        public static SourceCode GetFromFile(FileInfo file, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(file.Name);

            // Charge and evaluate source

            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            var getDatas = file.LoadContentFromFile();

            return new SourceCode(getDatas, name);

        }

        public static SourceCode GetFromText(StringBuilder payload, string name = null)
        {
            return new SourceCode(payload.ToString(), name);
        }

        public static SourceCode GetFromText(string payload, string name = null)
        {
            return new SourceCode(payload, name);
        }

        private SourceCode(string datas, string name)
        {
            this.ReadedAt = DateTime.Now;
            this.Name = name;
            this.Datas = datas;
        }

        public DateTime ReadedAt { get; private set; }

        public string Name { get; }

        public string Datas { get; private set; }

        public bool HasUpdated()
        {
            
            if (File.Exists(this.Name))
                 return File.GetLastWriteTime(this.Name) > this.ReadedAt;

            return false;

        }


        public void Reload()
        {
            if (File.Exists(this.Name))
                this.Datas = this.Name.LoadContentFromFile();
        }


        public static SourceCode Empty { get; private set; }
        public string Filename { get; private set; }

        public static implicit operator SourceCode(StringBuilder sb)
        {
            return SourceCode.GetFromText(sb);
        }

        public static implicit operator SourceCode(string sb)
        {
            return SourceCode.GetFromText(sb);
        }

        public static implicit operator SourceCode(FileInfo file)
        {
            return SourceCode.GetFromFile(file);
        }

       
        //private static string Normalize(string payload)
        //{

        //    var length = payload.Length;
        //    StringBuilder sb = new StringBuilder(length);

        //    for (int i = 0; i < length; i++)
        //    {

        //        char c = payload[i];

        //        if ((int)c != 65279)
        //            sb.Append(c);

        //    }

        //    return sb.ToString();

        //}


    }



}
