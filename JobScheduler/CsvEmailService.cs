using CSV;
using Email;
using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job
{
    public class CsvEmailService : ICsvEmailService
    {
        private readonly ICSVService _cSVService;
        private readonly IEmailService _emailService;

        public CsvEmailService(ICSVService cSVService, IEmailService emailService)
        {
            _cSVService = cSVService;
            _emailService = emailService;
        }


        public void SendCsvEmails()
        {
            Console.WriteLine("Start SendCsvEmails");

            var emailRecipients = _cSVService.ReadCSV();
            var emailsSentNumber = _emailService.SendCsvEmails(emailRecipients);

            if (emailsSentNumber > 0)
            {
                _cSVService.AddCsvIndex(emailsSentNumber);
            }
        }


    }
}
