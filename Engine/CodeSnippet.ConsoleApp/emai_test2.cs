using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace CodeSnippet.ConsoleApp
{
    public class emai_test2
    {
        public static void Main()
        {
            //Main2();
        }
        public static void Main1()
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("damilolar_moyo@outlook.com"));

            //email.To.Add(MailboxAddress.Parse("adegunwad@accessbankplc.com"));
            //email.To.Add(MailboxAddress.Parse("damee1993@gmail.com"));
            email.To.Add(MailboxAddress.Parse("damilola_093425@yahoo.com"));

            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

            // send email
            using var smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("damilolar_moyo@outlook.com", "Damilola#123");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        //"Smtp": {
        //  //"Host": "smtp.gmail.com",
        //  "Host": "smtp.mail.yahoo.com",
        //  //"Port": "587",
        //  "Port": "465",
        //  "EnableSSl": "true",
        //  "DeliveryMethod": "0",
        //  "UseDefaultCredentials": "false",
        //  "Server": "smtp.gmail.com",
        //  //"Password": "ekihireapp1",
        //  //"UserName": "contact@ekihire.com"
        //  "Password": "Damilola@123",
        //  "UserName": "damee1993@gmail.com"
        //},
        //public static void Main2()
        //{
        //    // create email message
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse("damilola_093425@yahoo.com"));

        //    //email.To.Add(MailboxAddress.Parse("adegunwad@accessbankplc.com"));
        //    //email.To.Add(MailboxAddress.Parse("damee1993@gmail.com"));
        //    email.To.Add(MailboxAddress.Parse("damee1993@gmail.com"));

        //    email.Subject = "Test Email Subject";
        //    email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

        //    // send email
        //    using var smtp = new SmtpClient();
        //    //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        //    smtp.Connect("smtp.mail.yahoo.com", 465, SecureSocketOptions.StartTls);
        //    smtp.Authenticate("damilola_093425@yahoo.com", "Damilola#123");
        //    smtp.Send(email);
        //    smtp.Disconnect(true);
        //}
    }
}
