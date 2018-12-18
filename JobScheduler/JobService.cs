﻿using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job
{
    public class JobService : IJobService
    {
        private readonly ICsvEmailService _csvEmailJobService;
        public JobService(ICsvEmailService csvEmailJobService)
        {
            _csvEmailJobService = csvEmailJobService;
        }
        public void RunSendCsvEmails() {
            GlobalConfiguration.Configuration.UseMemoryStorage();

            RecurringJob.AddOrUpdate<ICsvEmailService>(
                _csvEmailJobService => _csvEmailJobService.SendCsvEmails(),
                Cron.Minutely);

            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
