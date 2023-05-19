//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Mail;
//using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
namespace RetryApp.Services
{
	public class EmailSender
	{
		public void SendEMail(string to, string message, string subject)
		{
			try
			{
				// create email message
				var email = new MimeMessage();
				//email.From.Add(MailboxAddress.Parse(_smtpsettings.From));
				email.From.Add(MailboxAddress.Parse("damilolar_moyo@outlook.com"));

				//email.To.Add(MailboxAddress.Parse("adegunwad@accessbankplc.com"));
				//email.To.Add(MailboxAddress.Parse("damee1993@gmail.com"));
				//email.To.Add(MailboxAddress.Parse("damilola_093425@yahoo.com"));
				email.To.Add(MailboxAddress.Parse(to));

				//email.Subject = "Test Email Subject";
				email.Subject = subject;
				//email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };
				email.Body = new TextPart(TextFormat.Html) { Text = message };

				// send email
				using var smtp = new SmtpClient();
				//smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
				//smtp.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
				//smtp.Authenticate("damilolar_moyo@outlook.com", "Damilola#123");
				//smtp.Connect(_smtpsettings.Host, _smtpsettings.Port, SecureSocketOptions.StartTls);
				smtp.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
				smtp.Authenticate("damilolar_moyo@outlook.com", "BetterWorld_369");
				smtp.Send(email);
				smtp.Disconnect(true);
			}
			catch (Exception ex)
			{

			}
		}

		public void SendEMail2(string to, string message, string subject)
		{
			try
			{
				// create email message
				var email = new MimeMessage();
				email.From.Add(MailboxAddress.Parse("damilolar_moyo@outlook.com"));
				email.To.Add(MailboxAddress.Parse(to));
				email.Subject = subject;
				email.Body = new TextPart(TextFormat.Html) { Text = message };
				using var smtp = new SmtpClient();
				smtp.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
				smtp.Authenticate("damilolar_moyo@outlook.com", "BetterWorld_369");
				smtp.Send(email);
				smtp.Disconnect(true);
			}
			catch (Exception ex)
			{

			}
		}

		//public async Task SendMail()
		//{
		//	try
		//	{
		//		var smtpClient = new SmtpClient("smtp.example.com")
		//		{
		//			Port = 587,
		//			Credentials = new NetworkCredential("damee1993@gmail.com", "BetterWorld_369"),
		//			EnableSsl = true,
		//		};
		//		smtpClient.Send("damee1993@gmail.com", "dammy.adegunwa@gmail.com", "subject", "body");
		//		_ = "done";
		//	}
		//	catch (Exception)
		//	{
		//		_ = new Exception();
		//	}


		//}
	}
}
