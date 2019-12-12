using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Sup.Framework.Dependency
{
    public class ConventionalDependencyRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssemblies(IWindsorContainer container, string[] assemblyNames)
        {
            foreach (var assembly in assemblyNames)
            {
                container.Register(
                Classes.FromAssemblyNamed(assembly)
                .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );
                container.Register(
                Classes.FromAssemblyNamed(assembly)
                .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleSingleton()
                );
                container.Register(
                Classes.FromAssemblyNamed(assembly)
                .IncludeNonPublicTypes()
                    .BasedOn<IScopedDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleScoped()
                );
            }
        }
    }
}
