using Email;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DiscountMailer
{
    public class EmailSender
    {
        public bool SendEmail(string toEmail, string subject, string body)
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
                return false;
            }
        }

        public void isItSended()
        {
            bool result = false;

            result = SendEmail("klocu321@interia.pl", "Powitanie", "Czesc sprawdzam poprawnosc wysylania eMaili");
            Console.WriteLine(result);
        }

        public void isItSended(string toEmail, string subject, string body)
        {
            bool result = false;

            result = SendEmail(toEmail, subject, body);
            Console.WriteLine(result);
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