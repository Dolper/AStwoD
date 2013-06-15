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
        public const string EmailFrom = "admin@aquabit.ru";

        public static  void SendEMail(string EmailTo,string subject, string body)
        {
            using (var client = new SmtpClient("smtp.yandex.ru", 25))
            {
                using (var message = new MailMessage(EmailFrom,EmailTo))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;
                    client.Credentials = new NetworkCredential("admin@aquabit.ru", "secret");
                    client.EnableSsl = true;
                    client.Send(message);
                }   
            }
        }

        public void SendRequestRepair(string city,string fio,string phone,string descriptionTrouble)
        {
            string subject = "request to repair!";
            string body = "Request for repair";
            body += "City: " + city+"\n";
            body += "Name: " + fio + "\n";
            body += "Phone:" + phone + "\n";
            body += "description trouble \n";
            body += descriptionTrouble;
            SendEMail("admin@aquabit.ru", subject, body);
        }
    }
}