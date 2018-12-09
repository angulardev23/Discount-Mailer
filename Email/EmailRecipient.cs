using CsvHelper.Configuration;
using System;

namespace Email
{
    public class EmailRecipient
    {
        public string emailAddress { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime endDateTime { get; set; }

        public EmailRecipient(string emailAddress, string name, string surname, DateTime endDateTime)
        {
            this.emailAddress = emailAddress;
            this.name = name;
            this.surname = surname;
            this.endDateTime = endDateTime;
        }
    }


    public sealed class EmailRecipientMap : ClassMap<EmailRecipient>
    {
        public EmailRecipientMap()
        {
            AutoMap();
        }
    }

}
