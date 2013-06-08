using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AStwoD.Classes
{
    public class EMailManager
    {
        public const string EmailFrom = "demyan.golyshev@gmail.com";

        public static  void SendEMail(string EmailTo,string subject, string body)
        {
            using (var client = new SmtpClient("smtp.gmail.com",587))
            {
                using (var message = new MailMessage(EmailFrom,EmailTo))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;
                    client.Credentials = new NetworkCredential("demyan.golyshev@gmail.com","xxcvbnxx");
                    client.EnableSsl = true;
                    client.Send(message);
                }   
            }
        }
    }
}