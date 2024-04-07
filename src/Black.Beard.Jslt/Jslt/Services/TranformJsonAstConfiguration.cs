using Bb.Analysis.DiagTraces;
using Bb.Builds;
using Bb.ComponentModel;
using Bb.Nugets;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
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
            this._paths = new HashSet<string>
            {
                Environment.CurrentDirectory
            };
            this.OutputPath = string.Empty;

            _sdk = FrameworkVersion.CurrentVersion;
            _nugets = new NugetController()
                    .AddDefaultWindowsFolderIf()
                    .AddDefaultLinuxFolderIf();

        }


        /// <summary>
        /// Add a package to the configuration
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="version"></param>
        /// <param name="diagnostics"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddPackage(string packageName, Version? version, ScriptDiagnostics diagnostics, TextLocation? location = null)
        {

            if (location == null)
                location = TextLocation.Empty;

            var p = _nugets.Resolve(packageName, version, true);
            if (p == null)
            {
                if (_nugets.TryToDownload(_sdk, packageName, null))
                    p = _nugets.Resolve(packageName, version, true);
                else
                    diagnostics.AddError(location, packageName, $"Failed to resolve package {packageName}");
            }

            var lst = p.References.Where(c => c.Framework.Match(_sdk.Key)).ToList();
            if (lst.Any())
                foreach (var item in lst)
                    AddAssemblyFile(item.Location.AsFile(), diagnostics, location);
            else
                diagnostics.AddError(location, packageName, $"The package {packageName} has no assembly for {_sdk}");

            return this;

        }

        /// <summary>
        /// Add a new assembly to the configuration
        /// </summary>
        /// <param name="assemblyname"></param>
        /// <param name="diagnostics"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddAssemblyName(string assemblyname, ScriptDiagnostics diagnostics, TextLocation? location = null)
        {
            try
            {
                var assembly = AssemblyLoader.Instance.LoadAssemblyName(new AssemblyName(assemblyname));
                if (assembly != null)
                {
                    ServiceContainer.AddAssembly(assembly);
                    return this;
                }
            }
            catch (FileNotFoundException)
            {
            }

            if (location == null)
                location = TextLocation.Empty;

            diagnostics.AddError(location, assemblyname, $"Failed to resolve assembly {assemblyname}");

            return this;

        }

        /// <summary>
        /// Add a new assembly file to the configuration
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="diagnostics"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddAssemblyFile(string assemblyFile, ScriptDiagnostics diagnostics, TextLocation? location = null)
        {
            return AddAssemblyFile(assemblyFile.AsFile(), diagnostics, location);
        }

        /// <summary>
        /// Add a new assembly file to the configuration
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="diagnostics"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddAssemblyFile(FileInfo assemblyFile, ScriptDiagnostics diagnostics, TextLocation? location = null)
        {
            try
            {
                var rr = Assembly.LoadFile(assemblyFile.FullName);
                var assembly = AssemblyLoader.Instance.LoadAssembly(assemblyFile);
                if (assembly != null)
                {
                    ServiceContainer.AddAssembly(assembly);
                    return this;
                }
            }
            catch (Exception)
            {
            }

            if (location == null)
                location = TextLocation.Empty;

            diagnostics.AddError(location, assemblyFile.Name, $"Failed to load assembly {assemblyFile.Name}");
            return null;

        }

        /// <summary>
        /// Add a new assembly to the configuration
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddAssembly(Assembly assembly)
        {
            ServiceContainer.AddAssembly(assembly);
            return this;
        }

        /// <summary>
        /// Add a new assembly to the configuration
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddAssembly(Type type)
        {
            ServiceContainer.AddAssembly(type.Assembly);
            return this;
        }
    
        /// <summary>
        /// Add new services to the configuration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddServices(params (string, Type)[] services)
        {
            foreach (var item in services)
                ServiceContainer.Instance.ServiceDiscovery.AddService(item.Item2, item.Item1);
            return this;
        }

        /// <summary>
        /// Add new services to the configuration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddServices(params Type[] services)
        {
            foreach (var item in services)
                ServiceContainer.Instance.ServiceDiscovery.AddService(item);

            return this;
        }

        /// <summary>
        /// Add new paths to the configuration for search assemblies
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public TranformJsonAstConfiguration AddPaths(params string[] paths)
        {

            if (paths != null)
                foreach (var item in paths)
                    if (!string.IsNullOrEmpty(item))
                        _paths.Add(item);

            return this;

        }

        public static TranformJsonAstConfiguration Configuration { get; set; }

        /// <summary>
        /// List of path for search assemblies
        /// </summary>
        public IEnumerable<string> Paths { get => _paths; }

        public CultureInfo Culture { get; set; }

        public string OutputPath { get; set; }


        public FileInfo ResolveFile(string filename)
        {

            var file = filename.AsFile();

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


        private readonly FrameworkVersion _sdk;
        private readonly NugetController _nugets;
        private HashSet<string> _paths; 

    }

}
