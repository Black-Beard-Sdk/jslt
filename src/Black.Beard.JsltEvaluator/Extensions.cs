using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AppJsonEvaluator
{
    public static class Extensions
    {


        //public static void Load(this RichTextBox richTextBox, string filename)
        //{
        //    TextRange textRange = richTextBox.GetRange();
        //    textRange.Text = System.IO.Path.Combine(Environment.CurrentDirectory, filename).LoadFile();
        //}

        //public static void Save(this RichTextBox richTextBox, string filename)
        //{
        //    TextRange textRange = richTextBox.GetRange();
        //    System.IO.Path.Combine(Environment.CurrentDirectory, filename).WriteInFile(textRange.Text);
        //}

        public static TextRange GetRange(this RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange;
        }

        public static T Deserialize<T>(this string self)
        {

            return JsonConvert.DeserializeObject<T>(self);

        }

        public static string Serialize<T>(this T self)
        {

            return JsonConvert.SerializeObject(self);

        }

        public static string LoadFile(this string filename)
        {
            return File.ReadAllText(filename);
        }

        public static void WriteInFile(this string self, string content)
        {

            if (File.Exists(self))
                File.Delete(self);

            byte[] array = System.Text.UTF8Encoding.UTF8.GetBytes(content);

            using (var file = File.OpenWrite(self))
            {
                file.Write(array, 0, array.Length);
            }

        }

        public static TemplateTransformProvider GetProvider(string[] paths, params Type[] services)
        {

            var configuration = new TranformJsonAstConfiguration();

            if (paths != null)
            foreach (var item in paths)
                if (!string.IsNullOrEmpty(item))
                    configuration.Paths.Add(item);

            foreach (var item in services)
                configuration.Services.ServiceDiscovery.AddService(item);

            TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);

            return Templateprovider;

        }

        public static JsltTemplate GetTransformProvider(this string self, string[] paths, params Type[] services)
        {

#if UNIT_TEST
            StringBuilder sb = new StringBuilder(self.Replace('\'', '"').Replace('§', '\''));
#else
            StringBuilder sb = new StringBuilder(self);
#endif

            var provider = GetProvider(paths, services);
            JsltTemplate template = provider.GetTemplate(sb, "");
            return template;

        }

    }

}
