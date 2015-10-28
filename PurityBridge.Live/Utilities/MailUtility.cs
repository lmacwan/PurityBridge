using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Xml;

namespace PurityBridge.Live
{
    public class MailUtility
    {
        public static bool SendMultipleMails(List<string> toAddresses, List<string> ccAddresses = null, string from = "", string subject = "Test Mail", string body = "This is a Test Mail.", bool isHtml = false)
        {
            try
            {
                #region Example Code
                MailMessage mail = new MailMessage();
                if (MailConfigurations.InitializeConfigurations())
                {
                    SmtpClient SmtpServer = new SmtpClient(MailConfigurations.ServerName);
                    mail.From = new MailAddress(string.IsNullOrEmpty(from) ? MailConfigurations.FromAddress : from);
                    if (toAddresses != null)
                    {
                        foreach (var toAddress in toAddresses)
                        {
                            mail.To.Add(toAddress);
                        }
                    }
                    if (ccAddresses != null)
                    {
                        foreach (var ccAddress in ccAddresses)
                        {
                            mail.CC.Add(ccAddress);
                        }
                    }
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = isHtml;

                    if (MailConfigurations.Port > 0)
                    {
                        SmtpServer.Port = MailConfigurations.Port;
                    }
                    SmtpServer.Credentials = new System.Net.NetworkCredential(MailConfigurations.UserName, MailConfigurations.Password);
                    SmtpServer.EnableSsl = MailConfigurations.EnableSsl;
                    SmtpServer.Timeout = 3000;

                    SmtpServer.Send(mail);
                    return true;
                }
                #endregion
                return false;
            }
            catch
            {
                return false;

            }
        }

        public static bool SendSingleMail(string toAddress, List<string> ccAddresses = null, string from = "", string subject = "Test Mail", string body = "This is a Test Mail.", bool isHtml = false)
        {
            var list = new List<string>();
            list.Add(toAddress);
            return SendMultipleMails(list, ccAddresses, from, subject, body, isHtml);
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

    public class MailConfigurations
    {
        private static string _configFileName = "Email.config";
        private static bool _success = false;

        public static bool InitializeConfigurations(bool forceReload = false)
        {
            XmlDocument document = new XmlDocument();
            document.Load(AppDomain.CurrentDomain.BaseDirectory + "/config/" + _configFileName);
            if (!_success || forceReload || bool.Parse(document.GetElementsByTagName("refreshAlwaysFromNowOn")[0].InnerText))
            {
                try
                {
                    ServerName = document.GetElementsByTagName("smptServer")[0].InnerText;
                    UserName = document.GetElementsByTagName("userName")[0].InnerText;
                    Password = document.GetElementsByTagName("password")[0].InnerText;
                    int port;
                    int.TryParse(document.GetElementsByTagName("port")[0].InnerText, out port);
                    Port = port;
                    FromAddress = document.GetElementsByTagName("fromAddress")[0].InnerText;
                    bool ssl = false;
                    bool.TryParse(document.GetElementsByTagName("enableSsl")[0].InnerText, out ssl);
                    EnableSsl = ssl;

                    _success = true;
                }
                catch
                {
                    _success = false;
                }
            }
            return _success;
        }

        public static string ServerName { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }

        public static int Port { get; set; }

        public static string FromAddress { get; set; }

        public static bool EnableSsl { get; set; }
    }
}