using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
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
        private static WindsorContainer container;
        private static IServiceProvider serviceProvider;
        private IConventionalDependencyRegistrar dependencyRegistrar;


        public ServiceResolver(IServiceCollection services)
        {
            container = new WindsorContainer();
            this.dependencyRegistrar = new ConventionalDependencyRegistrar();
            //Register your components in container
            this.dependencyRegistrar.RegisterAssemblies(container, ProjectHelper.GetAssemblyNames(Constants.ProjectName));
            //then
            serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
        
    }
}
