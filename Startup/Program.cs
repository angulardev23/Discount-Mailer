using Autofac;
using CSV;
using Email;
using Job;
using Microsoft.Extensions.DependencyInjection;
using Startup;
using System;
using System.Collections.Generic;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {   //read and create settings file
            //var settings = new Settings();
            var services = new ServiceCollection();
            var serviceProvider = ContainerConfig.ConfigureContainers(services);

            var _csvJobService = serviceProvider.GetService<ICsvJobService>();

            _csvJobService.Run();
        }
    }
}
