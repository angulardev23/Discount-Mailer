using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using CsvHelper;
using Email;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;

namespace Email
{
    public static class EmailSender
    {

        public static bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string senderEmail = "mailernetservice@gmail.com";
                string senderPassword = "netmailer123";
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, body);
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in send e-mail {ex}");
                return false;
            }
        }

    }
}