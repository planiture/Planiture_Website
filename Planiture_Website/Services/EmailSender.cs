using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Planiture_Website.Models.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;

namespace Planiture_Website.Services
{
    public class EmailSender : IMailSender
    {
        public MessageSenderOptions Options { get; } //set only via Secret Manager

        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string ToEmail, string subject, string message)
        {
            var apiKey = _configuration["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kavonmorris41@gmail.com", "Testing");
            var to = new EmailAddress(ToEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }

        
    }
}
