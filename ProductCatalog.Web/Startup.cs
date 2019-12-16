using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductCatalog.Core.Products;
using ProductCatalog.EFCore;
using ProductCatalog.EFCore.Repositories;
using ProductCatalog.Web.DependencyConfiguration;
using Sup.Framework.Base;
using Sup.Framework.Base.Extensions;
using Sup.Framework.Middlewares;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog.Web
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            StaticConsts.CurrentDirectory = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductCatalogDbContext>(options=> {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            },ServiceLifetime.Scoped);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(System.Reflection.Assembly.Load(Constants.ProjectName + "." + "Application"));

            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(DefaultCorsPolicyName));
            }                         
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
                    builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            Configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

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
            app.UseCors(DefaultCorsPolicyName);
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
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
