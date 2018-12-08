using Autofac;
using Autofac.Extensions.DependencyInjection;
using CSV;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Startup
{
    public static class ContainerConfig
    {
        public static void ConfigureContainers(IServiceCollection services)
        {
            var settings = new Settings();
            services.AddOptions();
            services.Configure<CsvConfig>(p =>
                settings.Config.GetSection("ApplicationSettings").Bind(p));

            var builder = new ContainerBuilder();
            builder.RegisterType<CSVService>().As<ICSVService>();
            builder.Populate(services);
        }
    }
}
