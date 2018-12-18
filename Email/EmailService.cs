using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public void SendCsvEmails()
        {
            Console.WriteLine("Start Sending Csv Emails...");
            _emailSender.SendEmail("garnoslaw94@gmail.com", "Powitanie", "Czesc sprawdzam poprawnosc wysylania eMaili");
            Console.WriteLine();
        }
    }
}
