using CSV;
using Email;
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

        public void Run()
        {
            //GlobalConfiguration.Configuration.UseSqlServerStorage("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
            GlobalConfiguration.Configuration.UseMemoryStorage();

            var manager = new RecurringJobManager();
            //manager.AddOrUpdate("some-id", Job.FromExpression(() => _cSVService.ReadCSV()), Cron.Minutely);
            RecurringJob.AddOrUpdate(() => _cSVService.ReadCSV(), Cron.Minutely);
            var a = _cSVService.ReadCSV();

            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("Recurring!"),
                Cron.Minutely);

            using (var server = new BackgroundJobServer())
            {
                //var emailRecipientsIEnumerable = CSVService.ReadCSV(settings.CSVFile);
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }


    }
}
