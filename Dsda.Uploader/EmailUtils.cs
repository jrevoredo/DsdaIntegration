using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Dsda.Uploader
{
    public static class EmailUtils
    {
        public static void SendEmail(SmtpSettings settings, MailMessage message)
        {
            var smtp = new SmtpClient();
            smtp.Host = settings.Smtp;
            smtp.Port = settings.SmtpPort;
            smtp.EnableSsl = settings.UseSsl;

            if (!string.IsNullOrWhiteSpace(settings.Login) && !string.IsNullOrWhiteSpace(settings.Password))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(settings.Login, settings.Password);
            }

            smtp.Send(message);
        }

        public static SmtpSettings GetSmtpSettings()
        {
            var smtpSettings = new SmtpSettings();

            smtpSettings.Smtp = ConfigurationManager.AppSettings["EMAIL_SMTP"];
            
            int port;
            Int32.TryParse(ConfigurationManager.AppSettings["EMAIL_SMTP_PORT"], out port);
            
            smtpSettings.SmtpPort = port;
            smtpSettings.Login = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["EMAIL_SMTP_LOGIN"]) ? ConfigurationManager.AppSettings["EMAIL_SMTP_LOGIN"] : "";
            smtpSettings.Password = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["EMAIL_SMTP_PASSWORD"]) ? ConfigurationManager.AppSettings["EMAIL_SMTP_PASSWORD"] : "";

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EMAIL_SMTP_USE_SSL"]))
            {
                string ssl = ConfigurationManager.AppSettings["EMAIL_SMTP_USE_SSL"].ToLower();
                if (ssl == "true" || ssl == "1" || ssl == "yes") smtpSettings.UseSsl = true;
            }

            return smtpSettings;
        }
    }

    public class SmtpSettings
    {
        public string Smtp { get; set; }
        public int SmtpPort { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public bool UseSsl { get; set; }
    }
}