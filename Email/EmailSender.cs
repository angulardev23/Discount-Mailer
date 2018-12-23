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
using Microsoft.Extensions.Options;

namespace Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailConfig> _emailConfig;
        public EmailSender(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public bool SendEmail(EmailRecipient emailRecipient, string subject, string body)
        {
            try
            {
                var senderEmail = _emailConfig.Value.EmailAddress;
                var senderPassword = _emailConfig.Value.Password;
                var client = new SmtpClient(_emailConfig.Value.Host, _emailConfig.Value.Port);

                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                var mailMessage = new MailMessage(senderEmail, emailRecipient.emailAddress, subject, body)
                {
                    BodyEncoding = UTF8Encoding.UTF8
                };
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in send SendEmail for {emailRecipient} {ex}");
                return false;
            }
        }

    }
}