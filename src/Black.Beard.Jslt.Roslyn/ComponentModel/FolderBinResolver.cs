using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{


    /// <summary>
    /// Ressolve the folder's list of binaries files
    /// </summary>
    public class FolderBinResolver
    {


        /// <summary>
        ///     return value indicate if the current
        ///     <see cref="AppDomain.GetAssemblies()" contains items from Microsoft technology stack Web libraries />
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is system web assembly loaded; otherwise, <c>false</c>.
        /// </value>
        public static bool HasSystemWebAssemblyLoaded
        {
            get
            {
                if (!_isSystemWebAssemblyLoaded.HasValue)
                    _isSystemWebAssemblyLoaded = _hasSystemWebAssemblyLoaded_Impl();
                return _isSystemWebAssemblyLoaded.Value;
            }
        }

        private static bool _hasSystemWebAssemblyLoaded_Impl()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (assembly.FullName.StartsWith("System.Web,", StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        /// <summary>
        ///     Gets bin path for the case the running application is a console application.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DirectoryInfo> GetConsoleBinPath()
        {

            var _h = new HashSet<string>();
            var appDomain = AppDomain.CurrentDomain;

            if (!string.IsNullOrEmpty(appDomain.RelativeSearchPath))
                if (_h.Add(appDomain.RelativeSearchPath))
                    yield return new DirectoryInfo(appDomain.RelativeSearchPath);

            if (_h.Add(appDomain.BaseDirectory))
                yield return new DirectoryInfo(appDomain.BaseDirectory);
        }

        /// <summary>
        ///     Gets loaded assemblies.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetLoadedAssemblies()
        {
            var items = AppDomain.CurrentDomain.GetAssemblies().ToList();
            return items;
        }

        private static bool? _isSystemWebAssemblyLoaded;

    }
}