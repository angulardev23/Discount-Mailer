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

    }
}
