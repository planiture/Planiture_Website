using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planiture_Website.Services
{
    public interface IMailSender
    {
        Task SendEmailAsync(string ToEmail, string subject, string message);
    }
}
