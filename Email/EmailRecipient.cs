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
}
