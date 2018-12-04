using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Email
{
    public class EmailSender : EmailRecipient
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

        public void sending(ICollection<EmailRecipient> EmailRecipient)
        {
            string EmailAddress; // -> zmienne z małych liter
            string Name;
            string Surname;
            DateTime EndDateTime;

            foreach(object listOfSendingInformation in EmailRecipient)
            {
                if (item == null) continue;
                foreach(EmailRecipient property in EmailRecipient.GetType().GetProperties())
                    {
                        EmailAddress = EmailRecipient.EmailAdress;
                        Name = EmailRecipient.Name;
                        Surname = EmailRecipient.Surname;
                        EndDateTime = EmailRecipient.DateTime; // -> tu mają być var i niżej też

                        //email data
                        EmailRecipient recipient = new EmailRecipient(EmailAddress, Name, Surname, EndDateTime);
                        //body builder
                        BodyBuilder makeBody = new BodyBuilder();
                        string Body = makeBody.getBodyString(recipient.Name, recipient.Surname, recipient.EndDateTime);
                        //send an email
                        EmailSender emailSender = new EmailSender();
                        emailSender.isEmailSent(recipient.EmailAddress, "Promocja", Body);
                    }
            }
        }

    }
}