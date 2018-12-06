using Autofac;
using CSV;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Startup
{
    public static class ContainerConfig
    {
        public static void ConfigureContainers(IServiceCollection serviceCollection)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CSVService>().As<ICSVService>();
        }
    }
}
