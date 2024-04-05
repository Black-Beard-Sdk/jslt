using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Bb.Jslt.Services
{

    /// <summary>
    /// configuration for the transformation of json
    /// </summary>
    public partial class TranformJsonAstConfiguration
    {

        static TranformJsonAstConfiguration()
        {
            TranformJsonAstConfiguration.Configuration = new TranformJsonAstConfiguration();
        }

        /// <summary>
        /// Create a new instance of <see cref="TranformJsonAstConfiguration"/>
        /// </summary>
        /// <param name="culture"></param>
        public TranformJsonAstConfiguration(CultureInfo culture = null)
        {
            this.Culture = culture ?? CultureInfo.InvariantCulture;
            this.Services = ServiceContainer.Instance;
            this.Paths = new List<string>
            {
                Environment.CurrentDirectory
            };
            this.OutputPath = string.Empty;
            this.Assemblies = new List<Assembly>();
        }

        public static TranformJsonAstConfiguration Configuration { get; set; }

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
