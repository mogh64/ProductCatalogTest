using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sup.Framework.Base;
using Sup.Framework.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProductCatalog.Web.DependencyConfiguration
{
    public class ServiceResolver
    {
        private static IContainer container;
        private static IServiceProvider serviceProvider;
        private ConventionalDependencyRegistrar dependencyRegistrar;


        public ServiceResolver(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            
            builder.Populate(services);
            
            this.dependencyRegistrar = new ConventionalDependencyRegistrar();
            //Register your components in container
            this.dependencyRegistrar.RegisterAssemblies(builder, ProjectHelper.GetAssemblyNames(Constants.ProjectName));
            this.dependencyRegistrar.RegisterAssemblies(builder, new string[] { "Sup.Framework" });



            container = builder.Build();
            builder.RegisterInstance<IContainer>(container);
            //then
            serviceProvider = new AutofacServiceProvider(container);
        }

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
        
    }
}
