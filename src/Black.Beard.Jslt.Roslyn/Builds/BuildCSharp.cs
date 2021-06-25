using Bb.Compilers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.Builds
{

    public class BuildCSharp
    {


        public BuildCSharp()
        {

            _compiledAssemblies = new Dictionary<string, AssemblyResult>();

            Sources = new SourceCodes();
            References = new HashSet<Assembly>()
            {
                typeof(BuildCSharp).Assembly,
                typeof(Uri).Assembly,
            };

            OutputPath = System.IO.Path.GetTempPath();
            if (!System.IO.Directory.Exists(OutputPath))
                System.IO.Directory.CreateDirectory(OutputPath);
        }


        public string OutputPath { get; set; }

        public SourceCodes Sources { get; }

        public HashSet<Assembly> References { get; }

        public AssemblyResult Build(string assemblyName = null)
        {
            
            List<SourceCode> list = new List<SourceCode>();

            var key = assemblyName ?? Sources.GetUniqueAssemblyName();

            if (!_compiledAssemblies.TryGetValue(key, out AssemblyResult result))
            {

                var compiler = new RoslynCompiler(new HashSet<Assembly>(References));

                foreach (var item in Sources.Documents)
                    compiler.AddCodeSource(item.Datas, item.Filename);

                result = compiler.SetOutput(OutputPath)
                       .Generate()
                   ;

                if (result.Success)
                    _compiledAssemblies.Add(key, result);

            }

            return result;

        }


        private readonly Dictionary<string, AssemblyResult> _compiledAssemblies;

    }



}
