using System.Net.Mail;

namespace IdentityCoreMVC.Models
{
    public class EmailHelper
    {
        public async Task<bool> SendMail(string email, string message)
        {
            #region Email Mesaj Ayarlari 
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("saravap672@dewareff.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Register işlemini onaylayınız";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            #endregion

            #region SMTP Ayarlari
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.sengrid.net";
            smtpClient.Port = 587; // Smtp için bu port sabittir SSL'ide vardır.
            smtpClient.Credentials = new System.Net.NetworkCredential("saravap672@dewareff.com", "123456789987654321");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            #endregion

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }
    }
}
