using System;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace HProtest_BLL.Mail
{
    public class Mail
    {
        //static bool DefaultToPersonalMail = false;

        public enum MailServerType
        {
            Personal = 1,
            Gmail = 2,
            Local = 3
        }

        public enum BodyType
        {
            Message = 0,
            Err,
            vCard,
            AcCodeLink
        }

        public static bool SendMail(string from, string to, string subject, string body, BodyType BodyType, MailServerType ServerType)
        {
            try
            {
                SmtpClient smtp;
                string BodyTemplate = "";

                switch (BodyType)
                {
                    case BodyType.Message:
                        BodyTemplate = MailBody.Message.Replace("#BodyText#", body);
                        break;
                    case BodyType.Err:
                        BodyTemplate = MailBody.Err.Replace("#BodyText#", body);
                        break;
                    case BodyType.vCard:
                        BodyTemplate = body;
                        break;
                    default:
                        BodyTemplate = MailBody.Message.Replace("#BodyText#", body);
                        break;
                }

                switch (ServerType)
                {
                    case MailServerType.Personal:
                        #region personal mail server

                        smtp = new SmtpClient();

                        MailAddress fromAdd = new MailAddress(from, "domain.Com");

                        MailAddress toAdd = new MailAddress(to);
                        MailMessage msg = new MailMessage(fromAdd, toAdd);
                        msg.BodyEncoding = Encoding.GetEncoding("utf-8");
                        msg.Subject = subject;
                        msg.IsBodyHtml = true;

                        AlternateView plainText = AlternateView.CreateAlternateViewFromString(msg.Body, null, "text/plain");
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(msg.Body, null, "text/html");
                        htmlView.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                        msg.AlternateViews.Add(plainText);
                        msg.AlternateViews.Add(htmlView);

                        #region set manual configs
                        //NetworkCredential cred = new System.Net.NetworkCredential("username", "pass");
                        //smtp.Host = "host";
                        //smtp.Credentials = cred;
                        //smtp.Port =port;
                        //msg.To.Add(to);
                        #endregion

                        smtp.EnableSsl = true;
                        smtp.Send(msg);

                        #endregion
                        break;
                    case MailServerType.Gmail:
                        #region Try Gmail Server

                        MailMessage mail = new System.Net.Mail.MailMessage();

                        mail.Subject = subject;

                        mail.From = new MailAddress(from, "Hezbollahcriticism.ir", System.Text.Encoding.GetEncoding("windows-1256"));

                        mail.IsBodyHtml = true;
                        mail.Body = BodyTemplate;

                        smtp = new SmtpClient("smtp.gmail.com");

                        smtp.UseDefaultCredentials = false;

                        smtp.EnableSsl = true;

                        NetworkCredential cred = new System.Net.NetworkCredential("protestsiteemail@gmail.com", "8512202807");
                        smtp.Credentials = cred;
                        smtp.Port = 587;

                        mail.To.Add(to);

                        smtp.Send(mail);

                        #endregion
                        break;
                    case MailServerType.Local:
                    default:
                        #region Local Server

                        MailAddress addressTo = new MailAddress(to);
                        MailAddress addressFrom = new MailAddress("");

                        MailMessage message = new MailMessage(addressFrom, addressTo);

                        message.Subject = "اطلاعات کاربری شما";
                        message.IsBodyHtml = true;
                        message.Body = BodyTemplate;
                        SmtpClient s = new SmtpClient("127.0.0.1", 25);

                        s.Send(message);
                        #endregion

                        break;
                }
                
                return true;
            }
            catch
            { return false; }
        }
    }
}
