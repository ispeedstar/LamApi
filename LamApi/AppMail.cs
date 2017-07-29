using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;


namespace LamApi
{
    class AppMail
    {
        public static bool Send(string toMail, string mailSubject, string mailBody, string fromMail)
        {
            bool result = false;
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "ServerName";
                smtpClient.Port = 1234;
                MailMessage mailMessage = new MailMessage();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                mailMessage.SubjectEncoding = encoding;
                mailMessage.BodyEncoding = encoding;
                mailMessage.From = new MailAddress(fromMail);
                mailMessage.To.Add(toMail);
                mailMessage.Subject = mailSubject;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = mailBody;
                
                smtpClient.Send(mailMessage);
                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to send mail " + ex.Message);
            }
            return (result);
        } // end Send
    } // end class AppMail
}
