using System.Net.Mail;

namespace TestMail       // DENEME YAPILDI SMTP KULLANILAMIYOR.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendEmail("uskudarweb@yandex.com", "Deneme 123");


            Console.WriteLine("deneme");
        }

        public static async Task<bool> SendEmail(string email, string message)
        {



            #region Mail Mesaj Ayarlari

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("uskudarweb@yandex.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "REGİSTER İSLEMİNİ ONAYLAYİN";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            #endregion


            #region SMTP Ayarlari

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.yandex.com";
            smtpClient.Port = 587;


            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential("uskudarweb@yandex.com", "1q2w3E*");

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