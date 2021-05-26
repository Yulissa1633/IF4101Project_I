using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Domain;

namespace IF4101_ProjectI.Models.Mails
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
