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
    public class EmailSender : IEmailSender
    {

        public bool SendOptions(string toEmail, string subject, string body)
        {
            try
            {
                string senderEmail = "randomowymvcemail@gmail.com";
                string senderPassword = "randomoweHaslo";
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

        public void isEmailSent()
        {
            bool result = false;

            result = SendOptions("klocu321@interia.pl", "Powitanie", "Czesc sprawdzam poprawnosc wysylania eMaili");
            Console.WriteLine(result);
        }

        public void isEmailSent(string toEmail, string subject, string body)
        {
            bool result = false;

            result = SendOptions(toEmail, subject, body);
            Console.WriteLine(result);
        }

        public void sending(ICollection<EmailRecipient> emailRecipient)
        {

            foreach(object listOfSendingInformation in emailRecipient)
            {
                foreach(IEmailSender property in GetType().GetProperties())
                    {

                        var emailAddress = EmailRecipient.emailAddress;
                        var name = EmailRecipient.name;
                        var surname = EmailRecipient.surname;
                        var endDateTime = EmailRecipient.dateTime;

                        //email data
                        EmailRecipient recipient = new EmailRecipient(emailAddress, name, surname, endDateTime);
                        //body builder
                        BodyBuilder makeBody = new BodyBuilder();
                        string Body = makeBody.getBodyString(recipient.name, recipient.surname, recipient.endDateTime);
                        //send an email
                        EmailSender emailSender = new EmailSender();
                        emailSender.isEmailSent(recipient.emailAddress, "Promocja", Body);
                    }
            }
        }

        ClassMap<EmailRecipient> IEmailSender.EmailRecipientMap(string EmailAddress, string Name, string Surname, DateTime EndDateTime)
        {
            throw new NotImplementedException();
        }
    }
}