using Autofac;
using Autofac.Extensions.DependencyInjection;
using ecommerce_skinet_shop.API.Errors;
using ecommerce_skinet_shop.API.Extensions;
using ecommerce_skinet_shop.API.Helpers;
using ecommerce_skinet_shop.API.Middlewares;
using ecommerce_skinet_shop.Core;
using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Infrustructure;
using ecommerce_skinet_shop.MembershipModule;
using ecommerce_skinet_shop.MembershipModule.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public static ILifetimeScope AutofacContainer { get; private set; }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = Configuration.GetConnectionString(connectionStringName);
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;

            builder.RegisterModule(new APIModule(connectionString, migrationAssemblyName));
            builder.RegisterModule(new CoreModule(connectionString, migrationAssemblyName));
            builder.RegisterModule(new InfrustructureModule(connectionString, migrationAssemblyName));
            builder.RegisterModule(new MembershipAuthModule(connectionString, migrationAssemblyName));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = Configuration.GetConnectionString(connectionStringName);
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName)));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName)));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddApplicationServices();
            services.AddIdentityService(Configuration);
            services.AddSwaggerDocumentation();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:4200");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
