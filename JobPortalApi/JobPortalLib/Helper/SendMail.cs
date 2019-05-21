using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace JobPortalLib.Helper
{
    public class SendMail
    {
        public string MailSend(string Email, string Password)
        {
            string result = string.Empty;
            try
            {
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFrom = "sreenivas@graylogictech.com";
                string password = "Sreenu@52";
                string emailTo = Email;
                string subject = "Forgot Password";
                string body = "Your Password is " + Password;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
                result = "Success";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }   
    }
}
