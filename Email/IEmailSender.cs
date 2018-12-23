namespace Email
{
    public interface IEmailSender
    {
        bool SendEmail(EmailRecipient emailRecipient, string subject, string body);
    }
}