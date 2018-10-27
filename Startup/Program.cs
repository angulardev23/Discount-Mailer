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
           
            var send = new EmailSender
            .sending();
        }
    }
}
