using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AStwoD.Classes
{
    public class EMailManager
    {
        public const string EmailFrom = "admin@aquabit.ru";

        public static  void SendEMail(string EmailTo,string subject, string body)
        {
            using (var client = new SmtpClient("smtp.yandex.ru",587))
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

        public void SendRequestCoupon(string firstName,string lastName,string middleName,string email,string phone)
        {
            string subject = "Купон на скидку!";
            string body = "Купон на скидку!"+'\n';
            body += "Здравствуйте, " + lastName + " " + firstName + '\n';
            body += "Вы получаете купон на скидку 10%" + '\n';
            SendEMail(email,subject,body);
        }

        public void SendRequestRepair(string fio,string phone,string descriptionTrouble)
        {
            string subject = "Заявка на ремонт!";
            StringBuilder body=new StringBuilder();
            body.AppendLine("Заявка на ремонт!");
            body.AppendLine("ФИО: " + fio);
            body.AppendLine("Телефон:" + phone);
            body.AppendLine("Описание проблемы: ");
            body.AppendLine(descriptionTrouble);
            SendEMail("admin@aquabit.ru", subject, body.ToString());
        }
    }
}