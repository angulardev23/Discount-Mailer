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
            var settings = new Settings();
            //read CSV file
            //var emailRecipientsIEnumerable = CSVService.ReadCSV(settings.CSVFile);  
            
            //var send = new EmailSender
            //.sending(emailRecipientsIEnumerable);
        }
    }
}
