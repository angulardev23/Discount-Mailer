using CsvHelper.Configuration;
using System;

namespace Email
{
    public class EmailRecipient
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EndDateTime { get; set; }

        public EmailRecipient(string emailAddress, string name, string surname, DateTime endDateTime)
        {
            EmailAddress = emailAddress;
            Name = name;
            Surname = surname;
            EndDateTime = endDateTime;
        }
    }


    public sealed class EmailRecipientMap : ClassMap<EmailRecipient>
    {
        public EmailRecipientMap()
        {
            AutoMap();

            //Map(m => m.EmailAddress);
            //Map(m => m.Name);
            //Map(m => m.Surname);
            //Map(m => m.EndDateTime);

        }
    }

}
