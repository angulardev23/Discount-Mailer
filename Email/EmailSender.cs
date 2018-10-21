using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Email
{
    public class EmailSender
    {
        public bool SendOptions(string toEmail, string subject, string body)
        {
            try
            {
                string senderEmail = "randomowymvcemail@gmail.com";
                string senderPassword = "randomoweHaslo";
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, body);
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in send e-mail {ex}");
                return false;
            }
        }

        public void isItSended()
        {
            bool result = false;

            result = SendOptions("klocu321@interia.pl", "Powitanie", "Czesc sprawdzam poprawnosc wysylania eMaili");
            Console.WriteLine(result);
        }

        public void isItSended(string toEmail, string subject, string body)
        {
            bool result = false;

            result = SendOptions(toEmail, subject, body);
            Console.WriteLine(result);
        }

        public void sending()
        {
        //email data
        EmailRecipient recipient = new EmailRecipient("klocu321@interia.pl", "Marcin", "Kloc", DateTime.Today);
        //body builder
        BodyBuilder makeBody = new BodyBuilder();
        string Body = makeBody.text(recipient.Name, recipient.Surname, recipient.EndDateTime);
        //send an email
        EmailSender emailSender = new EmailSender();
        emailSender.isItSended(recipient.EmailAddress, "Promocja", Body);
        }


        /*
        public void Sending(){
        var email = new Email
        .From("randomowymvcemail@gmail.com")
        .To("klocu321@interia.pl", "klocu")
        .Subject("hows it going bob")
        .Body("yo dawg, sup?");

        await email.SendAsync();
        }
        ------------------------------------------------------------------
        public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddFluentEmail("randomowymvcemail@gmail.com")
            .AddRazorRenderer()
            .AddSmtpSender("smtp.gmail.com", 587);
    }

    public async Task<IActionResult> SendEmail([FromServices]IFluentEmail email)
    {
        await email
            .To("klocu321@interia.pl")
            .Subject("test email subject")
            .Body("This is the email body")
            .SendAsync();

        return View();
    }

    private IActionResult View()
    {
        throw new NotImplementedException();
    }

*/

    }
}