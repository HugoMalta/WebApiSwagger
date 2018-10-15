using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebApiSwagger.Utils;

namespace WebApiSwagger.v1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            StartupSwagger.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            StartupSwagger.Configure(app);

            app.UseMvc();
        }
    }
    //public class Startup
    //{
    //    //public Startup(IConfiguration configuration)
    //    //{
    //    //    Configuration = configuration;
    //    //}

    //    public Startup(IHostingEnvironment env)
    //    {
    //        var builder = new ConfigurationBuilder()
    //        .SetBasePath(env.ContentRootPath)
    //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
    //        .AddEnvironmentVariables();
    //        Configuration = builder.Build();
    //    }

    //    public IConfiguration Configuration { get; }

    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    //        StartupSwagger.ConfigureServices(services);
    //    }

    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        app.UseStaticFiles();
    //        app.UseCookiePolicy();

    //        StartupSwagger.Configure(app);

    //        app.UseMvc();
    //    }
    //}
}
