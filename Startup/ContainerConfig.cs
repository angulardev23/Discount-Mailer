using Autofac;
using Autofac.Extensions.DependencyInjection;
using CSV;
using Email;
using Hangfire;
using Hangfire.MemoryStorage;
using Job;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Startup
{
    public static class ContainerConfig
    {
        public static IServiceProvider ConfigureContainers(IServiceCollection services)
        {
            var settings = new Settings();
            services.AddOptions();
            services.Configure<CsvConfig>(p =>
                settings.Config.GetSection("ApplicationSettings").Bind(p));
            services.Configure<EmailConfig>(p =>
                settings.Config.GetSection("ApplicationSettings").GetSection("smtpClient").Bind(p));

            var builder = new ContainerBuilder();
            builder.RegisterType<CSVService>().As<ICSVService>();
            builder.RegisterType<CsvEmailService>().As<ICsvEmailService>();
            builder.RegisterType<JobService>().As<IJobService>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<EmailSender>().As<IEmailSender>();


            builder.Populate(services);

            var container = builder.Build();

            GlobalConfiguration.Configuration.UseMemoryStorage();
            GlobalConfiguration.Configuration.UseAutofacActivator(container);

            return new AutofacServiceProvider(container);
        }
    }
}
