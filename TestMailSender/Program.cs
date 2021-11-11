using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.IO;

namespace TestMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAddress from = new MailAddress("mailfromcsharp32021@gmail.com", "Helloworld C#");
            MailAddress to = new MailAddress("mailfromcsharp32021@gmail.com");

            MailMessage mailMessage = new MailMessage(from, to)
            {
                Subject = "Привет из С#!",
                Body = "Текст создан при помощи C#",
                IsBodyHtml = false
            };

            SmtpClient sc = new SmtpClient("smtp.gmail.com", 465)
            {
                Credentials = new NetworkCredential("mailfromcsharp32021@gmail.com", "slon2021"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };



            //try
            //{
            //    sc.Send(mailMessage);
            //    Console.WriteLine("Ура, получилос!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("не выходит( \n" + ex.ToString());
            //}

            Console.ReadLine();
        }
    }
}
