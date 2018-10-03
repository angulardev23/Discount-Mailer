using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Startup
{
    class Settings
    {
        String CSVFile;
        public IConfiguration Configuration { get; set; }

        public Settings()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var gar = builder.Build();
            var dir = Directory.GetCurrentDirectory();
            Configuration = builder.Build();

            var env = Configuration["ApplicationSettings:Environment"];
            CSVFile = Configuration["ApplicationSettings:CSVfile"];
        }

        //    // This method gets called by the runtime. Use this method to add services to the container.
        //    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //    public void ConfigureServices(IServiceCollection services)
        //    {
        //        services.AddMvcCore();
        //    }

        //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //    {
        //        if (env.IsDevelopment())
        //        {
        //            app.UseDeveloperExceptionPage();
        //            app.UseStatusCodePages();
        //        }

        //        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        //        loggerFactory.AddDebug();

        //        app.UseMvc();
        //    }
        //}
    }
}
