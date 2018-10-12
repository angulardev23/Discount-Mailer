using System;
using System.Collections.Generic;
using System.Text;
using DiscountMailer;

namespace Email
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender emailSender = new EmailSender();
            emailSender.isItSended();
        }
    }
}
