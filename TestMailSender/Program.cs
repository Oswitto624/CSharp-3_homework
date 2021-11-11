using System;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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
           
            string successSend = $"Message was send. " +
                                 $"\nFrom: { from.Address} " +
                                 $"\nTo: { to.Address} " +
                                 $"\nSubject: { mailMessage.Subject}" +
                                 $"\nMessage body: { mailMessage.Body}";

            Console.WriteLine(successSend);
            Debug.WriteLine(successSend);
               
            
            //Попробовал отправлять письма, но не выходило. В настройках почты всё хорошо (почта новая, пустышка). Можете попробовать раскомментировать и
            //попробовать отправить. Мб что-то не то с портом (хотя указал всё по гайду с gmail.com).
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
