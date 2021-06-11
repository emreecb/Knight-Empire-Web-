using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Master.Models
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string messages)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Atilganpazarlama.com", "tamirciciragi93@gmail.com"));
            message.To.Add(new MailboxAddress("customer", email));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = messages
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("tamirciciragi93@gmail.com", "yazici1967");
                client.Send(message);
                client.Disconnect(true);
            }
            return Task.FromResult(0);

        }
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}

