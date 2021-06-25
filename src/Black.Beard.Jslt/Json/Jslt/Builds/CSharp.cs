using Bb.Compilers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.Builds
{

    internal static class CSharp
    {

        static CSharp()
        {
            Sources = new SourceCodes();
            References = new HashSet<Assembly>()
            {
                typeof(CSharp).Assembly,
                typeof(Uri).Assembly,
            };

            _compiledAssemblies = new Dictionary<uint, List<AssemblyResult>>();
            OutputPath = System.IO.Path.GetTempPath();
            if (!System.IO.Directory.Exists(OutputPath))
                System.IO.Directory.CreateDirectory(OutputPath);
        }


        public static string OutputPath { get; set; }

        public static SourceCodes Sources { get; }

        public static HashSet<Assembly> References { get; }

        public static AssemblyResult GetAssembly(string[] filenames)
        {

            List<SourceCode> list = new List<SourceCode>();

            bool changed = false;
            uint key = 0;
            foreach (var filename in filenames)
            {
                var src = Sources.Add(filename);
                if (src.HasUpdated())
                    changed = true;
                list.Add(src);
                key ^= filename.Calculate();
            }

            if (!_compiledAssemblies.TryGetValue(key, out List<AssemblyResult> result))
                _compiledAssemblies.Add(key, result = new List<AssemblyResult>());

            if (result.Count == 0 || changed)
            {

                var compiler = new RoslynCompiler(new HashSet<Assembly>(References));

                foreach (var item in list)
                    compiler.AddCodeSource(item.Datas, item.Name);

                var result1 = compiler.SetOutput(OutputPath)
                       .Generate()
                   ;

                if (result1.Success)
                    result.Add(result1);

                return result1;

            }

            return result.Last();

        }


        private readonly static Dictionary<uint, List<AssemblyResult>> _compiledAssemblies;

    }



}
