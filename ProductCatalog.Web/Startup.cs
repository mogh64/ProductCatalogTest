using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductCatalog.EFCore;
using ProductCatalog.Web.DependencyConfiguration;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductCatalogDbContext>(options=> {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                

                c.SwaggerDoc("v1", new Info { Title = "Product Api", Version = "v1" });
                c.SwaggerDoc("v2", new Info { Title = "Product Api", Version = "v2" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddApiVersioning(config =>
            {

                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            var container = new ServiceResolver(services).GetServiceProvider();
            return container;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products Api V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Products Api V2");
            });

        }
    }
}
