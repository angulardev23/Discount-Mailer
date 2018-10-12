using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DiscountMailer
{
    public class EmailSender
    {
        /*private SmtpClientWrapper _smtpClient;
        private MvcMailMessage _mailMessage;
        private DirectoryInfo _mailDirectory;

        //public void Sending(string customerEmail, string text)
        public void Sending()
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            string customerEmail = "klocu321@interia.pl";
            string text = "Witaj mój drogi";

            _mailDirectory = Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Mails"));
            smtpClient.PickupDirectoryLocation = _mailDirectory.FullName;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("randomowyemail", "randomoweHaslo");
            _smtpClient = new SmtpClientWrapper { InnerSmtpClient = smtpClient };
            _mailMessage = new MvcMailMessage { From = new MailAddress("randomowymvcemail@gmail.com") };
            _mailMessage.To.Add(customerEmail);
            _mailMessage.Subject = "Discount!";
            _mailMessage.Body = text;

            _mailMessage.Send(_smtpClient);
            
            
            public void Sending(){
            var email = new Email
            .From("randomowymvcemail@gmail.com")
            .To("klocu321@interia.pl", "klocu")
            .Subject("hows it going bob")
            .Body("yo dawg, sup?");

            await email.SendAsync();
            }
          */

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
    }
  
    }