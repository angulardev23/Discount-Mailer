using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    public class EmailService : IEmailService
    {
        public void SendCsvEmails()
        {
            Console.WriteLine("Start Sending Csv Emails...");
            EmailSender.SendEmail("garnoslaw94@gmail.com", "Powitanie", "Czesc sprawdzam poprawnosc wysylania eMaili");
            Console.WriteLine();
        }
    }
}
