using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Wizards
{

    public class FileAction : ParserObject
    {

        public FileAction(FileInfo file)
            : base(Path.GetFileNameWithoutExtension(file.Name))
        {

            this._file = file;

        }

        public override void Click(object sender, ParserObbjectEventArgs e)
        {

            var exe = new FileInfo(Assembly.GetEntryAssembly().Location);
            exe = new FileInfo( Path.Combine(  exe.Directory.FullName,  Path.GetFileNameWithoutExtension(exe.Name)) + ".exe");

            if (exe.Exists)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = $"play \"{ this._file.FullName }\"",
                    FileName = exe.FullName,
                    WorkingDirectory = _file.Directory.FullName,
                };

                var result = Process.Start(startInfo);


            }


        }

        private readonly FileInfo _file;


    }

}



