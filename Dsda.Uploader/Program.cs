using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using Dsda.DataAccess;

namespace Dsda.Uploader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();  
            string sourceDirectory = args[0];
            string copyDirectory = args[1];

            DA da = new DA();
            Logger logger = new Logger(da);
            logger.Debug(string.Format("Start uploading. Source directory: '{0}'. Copy directory '{1}'. Machine Name: {2}", sourceDirectory, copyDirectory, System.Environment.MachineName));
            dsdaUploader uploader = new dsdaUploader(logger, sourceDirectory, copyDirectory);
            uploader.ProcessMove();

            //send log to email
            try
            {
                string emailBody = logger.GetFullSessionLog(new [] {enLogLevel.Info, enLogLevel.Error}, true, true, true);
                MailMessage message = new MailMessage();
                var emails = ConfigurationManager.AppSettings["EMAIL_TO"].Split(',');
                foreach (var email in emails)
                {
                    var _email = email.Trim();
                    if (!string.IsNullOrEmpty(_email))
                        message.To.Add(new MailAddress(_email));
                }
                var subject = ConfigurationManager.AppSettings["EMAIL_SUBJECT"];
                message.Subject = subject.Replace("{DATE}", DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                message.From = new MailAddress(ConfigurationManager.AppSettings["EMAIL_FROM"]);
                //message.Body = emailBody;
                //message.IsBodyHtml = true;
                //message.Priority = MailPriority.Low;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(emailBody, null, "text/html");
                message.AlternateViews.Add(htmlView);

                SmtpSettings smtpSettings = EmailUtils.GetSmtpSettings();
                EmailUtils.SendEmail(smtpSettings, message);
            }
            catch (Exception ex)
            {
                logger.Debug("Send log by email error:", ex);
            }
        }
    }
}
