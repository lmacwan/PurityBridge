using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PurityBridge.Live
{
    public class MailUtility
    {
        public static bool SendPlainTextMail(Mail content)
        {
            if (Validate(content))
            {
                return SendMail(content.From, content.To, content.Cc, content.Subject, content.Content);
            }
            return false;
        }

        private static bool SendMail(string from, List<string> toAddresses, List<string> ccAddresses, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("secure.emailsrvr.com");

                mail.From = new MailAddress("enquiry@pacifico.co.uk");
                foreach (var toAddress in toAddresses)
                {
                    mail.To.Add(toAddress);
                }
                foreach (var toAddress in ccAddresses)
                {
                    mail.To.Add(toAddress);
                }
                mail.Subject = "Test Mail";
                mail.Body = body;


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sandy@pacifico.co.uk", "Christian95");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool Validate(Mail content)
        {
            var result = true;
            if (content == null)
            {
                result = false;
            }
            else if (string.IsNullOrEmpty(content.Content))
            {
                result = false;
            }
            else if (content.To == null || !(content.To.Any()))
            {
                result = false;
            }
            else if (string.IsNullOrEmpty(content.From))
            {
                result = false;
            }
            return result;
        }
    }

    public class Mail
    {
        public string Content { get; set; }
        public List<String> To { get; set; }

        public List<String> Cc { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }
    }
}