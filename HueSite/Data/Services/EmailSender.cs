using HueSite.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HueSite.Data.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            // Credentials
            var credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);

            // Mail message
            var mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };


            mail.To.Add(new MailAddress(email));

            // Smtp client
            var client = new SmtpClient()
            {
                Port = _emailSettings.MailPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = _emailSettings.MailServer,
                EnableSsl = true,
                Credentials = credentials
            };

            // Send it...         
            return client.SendMailAsync(mail);
        }
    }
}

