using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    public interface IEmailService
    {
        int SendCsvEmails(ICollection<EmailRecipient> emailRecipients);
    }
}
