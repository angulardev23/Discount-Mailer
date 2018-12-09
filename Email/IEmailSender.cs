using CsvHelper.Configuration;
using System;

namespace Email
{
    public interface IEmailSender
    {
        ClassMap<EmailRecipient> EmailRecipientMap(string EmailAddress,string Name, string Surname, DateTime EndDateTime);
    }
}
