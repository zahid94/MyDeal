using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service.Messaging
{
    public class EmailSending
    {
        public void Email(string Email, string UserName, string MailSubject, string MailBody)
        {
            MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), Email);
            mail.Subject = MailSubject;
            mail.Body = "Dear Client " + UserName + MailBody;
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Send(mail);
        }
    }
}
