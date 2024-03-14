using System;
using System.Net;
using System.Net.Mail;

namespace SendEmailWithGoogleSMTP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string fromEmail = "adityajsn1299@gmail.com";

                string fromPassword = "fdmewihbwhndjfdc";
                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromEmail);
                message.Subject = "Test Subject";
                message.To.Add(new MailAddress("aditya.p@optimumfintech.co.in"));
                message.Body = "<html><body> Test Body </body></html>";
                message.IsBodyHtml = true;


                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.office365.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    smtp.UseDefaultCredentials = false;
                    // smtp.Timeout = 600000;
                }
                smtp.Send(fromEmail, "aditya.p@optimumfintech.co.in", message.Subject, message.Body);

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}
