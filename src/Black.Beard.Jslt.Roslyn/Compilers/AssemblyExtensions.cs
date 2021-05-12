using System;
using System.Linq;
using System.Reflection;

namespace Bb.Compilers
{

    public static class AssemblyExtensions
    {

        static AssemblyExtensions()
        {
            RefreshList();
        }

        public static void RefreshList()
        {
            AssemblyExtensions._assemblies = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .ToLookup(c => c.GetName().Name);
        }

        public static Assembly ResolveAssemblyByName(this string name)
        {
            var ass = _assemblies[name];
            if (ass != null)
            {
                var assembly = ass.FirstOrDefault();
                if (assembly != null)
                    return assembly;
            }

            return null;

        }

        private static ILookup<string, Assembly> _assemblies;

    }

}
