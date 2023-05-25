using System;
using System.IO;
using System.Reflection;
using Teigha.Runtime;

namespace KpblcNCadWindows
{
    public class ExtensionInitialize : IExtensionApplication
    {
        public void Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
        }
        
        public void Terminate()
        {
            throw new NotImplementedException();
        }

        private Assembly? CurrentDomainAssemblyResolve(object? sender, ResolveEventArgs args)
        {
            string name = GetAssemblyName(args);
            string path = Path.Combine(Path.GetDirectoryName(typeof(ExtensionInitialize).Assembly.Location),
                name + ".dll");
            if (File.Exists(path))
            {
                Assembly assembly = Assembly.LoadFrom(path);
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }

            return null;
        }

        private string GetAssemblyName(ResolveEventArgs Args)
        {
            if (Args.Name.IndexOf(",") > -1)
            {
                return Args.Name.Substring(0, Args.Name.IndexOf(","));
            }

            return Args.Name;
        }
    }
}
