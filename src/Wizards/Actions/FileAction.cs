using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Wizards.Actions
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
            exe = new FileInfo(Path.Combine(exe.Directory.FullName, Path.GetFileNameWithoutExtension(exe.Name)) + ".exe");

            if (exe.Exists)
            {

                string debug = Parameters.Instance.Debug ? "--debug" : string.Empty;

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = $"play \"{ this._file.FullName }\" {debug}",
                    FileName = exe.FullName,
                    WorkingDirectory = _file.Directory.FullName,

                };

                var result = Process.Start(startInfo);

                //var p = Process.GetProcessById(result.Id);                               
                //if (Parameters.Instance.Debug)
                //    Process.EnterDebugMode();

                // var ErrorStream = result.StandardError;

                // result.WaitForExit();

            }


        }

        private readonly FileInfo _file;


    }

}



