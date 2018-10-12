using System;
using System.Collections.Generic;
using System.Text;
using DiscountMailer;

namespace Email
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            EmailSender wyslijWiadomosc = new EmailSender();
            await wyslijWiadomosc.SendEmail();
        }
    }
}
