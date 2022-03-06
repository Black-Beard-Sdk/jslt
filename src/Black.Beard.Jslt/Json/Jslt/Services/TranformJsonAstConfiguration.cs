using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{


    public partial class TranformJsonAstConfiguration
    {

        public TranformJsonAstConfiguration(CultureInfo culture = null)
        {
            this.Culture = culture ?? CultureInfo.InvariantCulture;
            this.Services = ServiceContainer.Common;
            this.Paths = new List<string>();
            this.Paths.Add(Environment.CurrentDirectory);
            this.OutputPath = string.Empty;
            this.Assemblies = new List<Assembly>();
        }

        public ServiceContainer Services { get; }

        public List<string> Paths { get; set; }

        public CultureInfo Culture { get; set; }

        public string OutputPath { get; set; }

        public List<Assembly> Assemblies { get; }

        public FileInfo ResolveFile(string filename)
        {

            var file = new FileInfo(filename);

            if (!file.Exists)
                foreach (var path in this.Paths)
                    if (!string.IsNullOrEmpty(path))
                    {
                        file = new FileInfo(Path.Combine(path, filename));
                        if (file.Exists)
                            return file;
                    }

            return file;

        }

    }



}
