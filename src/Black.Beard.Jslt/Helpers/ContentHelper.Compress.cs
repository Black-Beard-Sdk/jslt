using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.IO;
using System.Text;

namespace Bb
{

    public static partial class ContentHelper
    {

        public static void Uncompress(this FileInfo inputFile, DirectoryInfo outputDir)
        {

            if (!outputDir.Exists)
                outputDir.Create();

            var option = new ExtractionOptions()
            {
                ExtractFullPath = true,
                Overwrite = true
            };

            var outpath = outputDir.FullName;

            using (Stream stream = inputFile.OpenRead())
            using (var reader = ReaderFactory.Open(stream))
                while (reader.MoveToNextEntry())
                    if (!reader.Entry.IsDirectory)
                        //Console.WriteLine(reader.Entry.Key);
                        reader.WriteEntryToDirectory(outpath, option);

        }

    }


}
