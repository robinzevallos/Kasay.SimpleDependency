[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("UnitTest")]
namespace Kasay.SimpleDependency
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal class AssemblyFactory
    {
        readonly IEnumerable<String> assemblyNames;

        public AssemblyFactory()
        {
            assemblyNames = GetAssemblyNames();
        }

        internal IEnumerable<Assembly> GetAssemblies()
        {
            foreach (var assemblyName in assemblyNames)
            {
                Assembly assembly;

                try
                {
                    assembly = AppDomain.CurrentDomain.Load(assemblyName);
                }
                catch
                {
                    continue;
                }

                if (IsTargetAssembly(assembly))
                    yield return assembly;
            }
        }

        IEnumerable<String> GetAssemblyNames()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var dllFiles = new DirectoryInfo(path).GetFiles("*.dll");
            var assemblyNames = dllFiles
                .Select(_ => _.Name.Substring(0, _.Name.IndexOf(".dll")));

            return assemblyNames;
        }

        Boolean IsTargetAssembly(Assembly assembly)
        {
            return assembly.GetReferencedAssemblies()
                .Any(_ => _.Name == "Kasay.SimpleDependency");
        }
    }
}
