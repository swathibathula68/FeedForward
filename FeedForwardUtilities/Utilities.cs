using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardUtilities
{
    public sealed class Utilities
    {
        private static Utilities obj = null;
        public static Utilities GetInstance()
        {
            if (obj == null)
            {
                obj = new Utilities();
            }

            return obj;
        }

        public static void SendEmail(string from, string to, string sub, string msg)
        {

            MailMessage message = new MailMessage(from, to);   // From address has to be GMAIL only             
            message.Subject = sub;
            message.Body = msg;
            message.IsBodyHtml = true;


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";           // This is free SMTP given by gmail
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("bathuswathi1234@gmail.com", "kswdeqorayicbxfc");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;

            smtp.Port = 587;                        // 587 is for free account

            smtp.Send(message);

        }
       

        public void LogErrorMessage(string msg)
        {
            
        }


    }
}
