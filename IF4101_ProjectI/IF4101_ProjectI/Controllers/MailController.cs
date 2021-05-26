using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Domain;
using IF4101_ProjectI.Models.Mails;
using Microsoft.AspNetCore.Mvc;

namespace IF4101_ProjectI.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
