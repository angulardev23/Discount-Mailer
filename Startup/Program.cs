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
        {
            var services = new ServiceCollection();
            var serviceProvider = ContainerConfig.ConfigureContainers(services);

            var _jobService = serviceProvider.GetService<IJobService>();

            _jobService.RunSendCsvEmails();
        }
    }
}
