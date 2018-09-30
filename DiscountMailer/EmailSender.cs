using System;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net.Mail;
using System.IO;
using Mvc.Mailer;

namespace DiscountMailer
{
    public class EmailSender
    {
        private SmtpClientWrapper _smtpClient;
        private MvcMailMessage _mailMessage;
        private DirectoryInfo _mailDirectory;

        //public void Sending(string customerEmail, string text)
        public void Sending()
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory
            };

            string customerEmail = "klocu321@interia.pl";
            string text = "Witaj mój drogi";

            _mailDirectory = Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Mails"));
            smtpClient.PickupDirectoryLocation = _mailDirectory.FullName;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Host = "smtpClient";
            smtpClient.Credentials = new System.Net.NetworkCredential("randomowyemail", "randomoweHaslo");
            _smtpClient = new SmtpClientWrapper { InnerSmtpClient = smtpClient };
            _mailMessage = new MvcMailMessage { From = new MailAddress("randomowymvcemail@gmail.com") };
            _mailMessage.To.Add(customerEmail);
            _mailMessage.Subject = "Discount!";
            _mailMessage.Body = text;

            _mailMessage.Send(_smtpClient); //Sending settings
        }

    }
}