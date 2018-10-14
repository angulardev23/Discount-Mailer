using CSV;
using Email;
using Email;
using Startup;
using System;
using System.Collections.Generic;

namespace Email
{
    class Program
    {
        static void Main(string[] args)
        {   //read and create settings file
            Settings settings = new Settings();
            //read CSV file
            IEnumerable<EmailRecipient> emailRecipientsIEnumerable = CSVUserReader.ReadCSV(settings.CSVFile);       
            //create body
            EmailRecipient recipient = new EmailRecipient("klocu321@interia.pl", "Marcin", "Kloc", DateTime.Today);
            string Email = recipient.EmailAddress;
            string Name = recipient.Name;
            string Surname = recipient.Surname;
            DateTime EndDate = recipient.EndDateTime;
            BodyBuilder makeBody = new BodyBuilder();
            string Body = makeBody.text(Name, Surname, EndDate);
            //send an email
            EmailSender emailSender = new EmailSender();
            emailSender.isItSended(Email, "Promocja", Body);
        }
    }
}
