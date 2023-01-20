using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [HttpPost]
        [Route("[action]")]
        public IActionResult ModelError(SomeModel model)
        {
            //older versions
            var a = new System.Web.Http.ModelBinding.ModelState().Errors;

            var x = ModelState.ToDictionary(
                        m => {
                            var tokens = m.Key.Split('.');
                            return tokens.Length > 0 ? tokens[tokens.Length - 1] : tokens[0];
                        },
                        m => m.Value.Errors.Select(e => e.Exception?.Message ?? e.ErrorMessage)
                    );
            return Ok(x);
        }
        public class SomeModel
        {
            [StringLength(maximumLength: 8, ErrorMessage = "error: SourceAccount too long")]
            public virtual string SourceAccount { set; get; }
            //[Range(0, 9999999999999999.99,ErrorMessage = "out of range!")]
            [Range(0, 999.99,ErrorMessage = "out of range!")]
            public virtual decimal Amount { set; get; }
            public string BatchReference { get; set; }
            public virtual string Username { get; set; }
            public virtual string Password { get; set; }
            public string BatchReference2 { get; set; }
            public virtual string Username2 { get; set; }
            public virtual string Password2 { get; set; }
        }
    }
    
}
