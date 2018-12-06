using CSV;
using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job
{
    public class JobScheduler
    {
        private ICSVService _cSVService;
        public JobScheduler(ICSVService cSVService)
        {
            _cSVService = cSVService;
        }

        public static void Run()
        {
            //GlobalConfiguration.Configuration.UseSqlServerStorage("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
            GlobalConfiguration.Configuration.UseMemoryStorage();

            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }


    }
}
