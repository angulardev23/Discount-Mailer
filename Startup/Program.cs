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
            //create body
            BodyBuilder makeBody = new BodyBuilder();
            string Body = makeBody.text(recipient.Name, recipient.Surname, recipient.EndDateTime);
            //send an email
            EmailSender emailSender = new EmailSender();
            emailSender.isItSended(recipient.EmailAddress, "Promocja", Body);
        }
    }
}
