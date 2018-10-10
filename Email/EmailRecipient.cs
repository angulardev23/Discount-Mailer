using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    public class EmailRecipient
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EndDateTime { get; set; }

        EmailRecipient(string emailAddress, string name, string surname, DateTime endDateTime)
        {
            EmailAddress = emailAddress;
            Name = name;
            Surname = surname;
            EndDateTime = endDateTime;
        }
    }
}
