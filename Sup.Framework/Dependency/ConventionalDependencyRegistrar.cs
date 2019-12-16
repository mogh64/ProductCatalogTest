using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Sup.Framework.Base;

namespace Sup.Framework.Dependency
{
    public class ConventionalDependencyRegistrar 
    {
        public void RegisterAssemblies(ContainerBuilder container, string[] assemblyNames)
        {
            foreach (var assembly in assemblyNames)
            {
                
                container.RegisterAssemblyTypes(Assembly.Load(assembly))
                    .AssignableTo<ITransientDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerDependency();
                container.RegisterAssemblyTypes(Assembly.Load(assembly))
                    .AssignableTo<ISingletonDependency>()
                    .AsImplementedInterfaces()
                    .SingleInstance();
                container.RegisterAssemblyTypes(Assembly.Load(assembly))
                    .AssignableTo<IScopedDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();

            }
        }
    }
}
