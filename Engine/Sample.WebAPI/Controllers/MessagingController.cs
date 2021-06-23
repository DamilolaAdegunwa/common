using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : Controller
    {
        private readonly IMailService mailService;
        private EmailHelper _emailHelper;
        public MessagingController(IMailService mailService, IConfiguration iConfiguration)
        {
            this.mailService = mailService;
            this._emailHelper = new EmailHelper(iConfiguration);
        }
        [HttpPost("send")]
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

        [HttpPost("justsend")]
        public IActionResult SendEmail()
        {
            var emailModel =
                new EmailModel("damee1993@gmail.com",//"gscaduto@sabesp.com.br", // To destination_email@test.com
                               "Email Test", // Subject
                               "Sending Email using Asp.Net Core.", // Message
                               false // IsBodyHTML
                               );

            _emailHelper.SendEmail(emailModel);

            return Ok();//RedirectToAction("Index");
        }
    }
    
}
