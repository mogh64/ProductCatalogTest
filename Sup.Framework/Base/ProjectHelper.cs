using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Base
{
    public class ProjectHelper
    {
        public static string[] GetAssemblyNames(string projectName)
        {
            List<string> assemblies = new List<string>();
            foreach (var layer in  GetLayers())
            {
                assemblies.Add(projectName + "." + layer);
            }
            return assemblies.ToArray();
        }
        private static string[] GetLayers()
        {
            return new string[] { "Application", "Core", "EfCore", "Web" };
        }
    }
}
