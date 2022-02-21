using System.IO;

namespace Bb.Maj
{
    public static partial class DirectoryHelper
    {

        public static int MoveTo(this DirectoryInfo source, DirectoryInfo target)
        {

            int result = 0;

            // move files
            foreach (var fileSource in source.GetFiles())
            {

                var fileTarget = new FileInfo(Path.Combine(target.FullName, fileSource.Name));

                if (fileTarget.Exists)
                    fileTarget.Delete();

                try
                {
                    fileSource.MoveTo(fileTarget.FullName);
                }
                catch (System.Exception)
                {
                    result++;
                }

            }

            // Replicate folders
            foreach (var sourceDir in source.GetDirectories())
            {

                string name = sourceDir.Name;

                var targetDir = new DirectoryInfo(Path.Combine(target.FullName, name));
                
                if (!targetDir.Exists)
                    targetDir.Create();

                try
                {
                    result += MoveTo(sourceDir, targetDir);
                    sourceDir.Delete();
                }
                catch (System.Exception)
                {
                    result++;
                }

            }

            return result;

        }

    }

}
