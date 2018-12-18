using CSV;
using Email;
using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job
{
    public class CsvJobService : ICsvJobService
    {
        private readonly ICSVService _cSVService;
        public CsvJobService(ICSVService cSVService)
        {
            _cSVService = cSVService;
        }

        public void Run()
        {
            //GlobalConfiguration.Configuration.UseSqlServerStorage("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
            GlobalConfiguration.Configuration.UseMemoryStorage();

            RecurringJob.AddOrUpdate<ICSVService>(
                x => x.ReadCSV(), 
                Cron.Minutely);

            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("Second Job!"),
                Cron.Minutely);

            using (new BackgroundJobServer())
            {
                //var emailRecipientsIEnumerable = CSVService.ReadCSV(settings.CSVFile);
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }


    }
}
