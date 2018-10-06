using DiscountMailer;
using System;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {   //read and create settings file
            Settings settings = new Settings();
            //read CSV file
            CSVUserReader.ReadCSV(settings.CSVFile);
            //start sending
            EmailSender emailSender = new EmailSender();
            emailSender.Sending();
        }
    }
}
