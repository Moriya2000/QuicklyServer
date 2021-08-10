using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class SendEmailBL
    {
        public static void SendMail(string mailAddressTo,string subject,string message,List<string> list)
        {
            try
            {
                for(int i=0;i<list.Count;i++)
                {
                    message += "כתובת מלאה:" + list[i];
                    //message += list[i];
                }
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("q254374@gmail.com");
                mail.To.Add(mailAddressTo);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("q254374@gmail.com", "211723671");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            } catch(Exception e)
            {

            }
           
        }
    }
}
