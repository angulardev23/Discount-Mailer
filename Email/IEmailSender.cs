namespace Email
{
    public interface IEmailSender
    {
        bool SendEmail(string toEmail, string subject, string body);
    }
}