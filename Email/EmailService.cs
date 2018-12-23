using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Email
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public int SendCsvEmails(ICollection<EmailRecipient> emailRecipients)
        {
            int emailsSent = 0;
            Console.WriteLine("Start Sending Csv Emails...");

            Parallel.ForEach (emailRecipients, (emailRecipient) =>
            {
                if (emailRecipient.endDateTime > DateTime.Now || emailRecipient.endDateTime == null)
                {
                    var body = BodyBuilder.GetBodyString(emailRecipient.name, emailRecipient.surname, emailRecipient.endDateTime);
                    _emailSender.SendEmail(emailRecipient, "Znizka 50% ! ! !", body);
                    emailsSent++;
                }
                Console.WriteLine("Processing {0} on thread {1}", emailRecipient, Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("Sending Csv Emails done.");
            return emailsSent;
        }
    }
}
