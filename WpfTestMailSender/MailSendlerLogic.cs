using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WpfTestMailSender
{
    
    class MailSendlerLogic
    {
        public static void SendMessage(string from, string password, string to, string msgSubject, string msgBody)
        {
            //обработка неверного ввода адресов почты при помощи регулярного выражения
            Regex eMailAdress = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}");
            if (!eMailAdress.IsMatch(from))
            {
                MessageBox.Show("Неверный адрес отправителя!");
                return;
            }
            else if (!eMailAdress.IsMatch(to))
            {
                MessageBox.Show("Неверный адрес получателя!");
                return;
            }

            //в качестве заготовки для будущего клиента рассылки писем (далее будет наверное обработка нескольких адресов)
            MailForm email = new MailForm(from, to, msgSubject, msgBody);

            using (MailMessage mailMessage = new MailMessage(email.From, email.To))
            {                              
                mailMessage.Subject = email.MsgSubject;
                mailMessage.Body = email.MsgBody;
                mailMessage.IsBodyHtml = false;

                SmtpClient sc = new SmtpClient("smtp.gmail.com", 465)
                {
                    Credentials = new NetworkCredential(email.From, password),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                string successSend = $"Message was send. " +
                                     $"\nFrom: { email.From } " +
                                     $"\nTo: { email.To } " +
                                     $"\nSubject: { email.MsgSubject }" +
                                     $"\nMessage body: { email.MsgBody }";

                Debug.WriteLine(successSend);

                SendEndWindow okWindow = new SendEndWindow();
                okWindow.ShowDialog();
            }
        }


        /// <summary>
        /// старый метод, без класса. так же закоментирована попытка именно отправки почты, без заглушки, но возникает проблема  
        /// то ли с портом, то ли с настройкой самого аккаунта для рассылки.
        /// </summary>
        //public static void SendMessage(string from, string password, string to, string msgSubject, string msgBody)
        //{
        //    using (MailMessage mailMessage = new MailMessage(from, to))
        //    {
        //        mailMessage.Subject = msgSubject;
        //        mailMessage.Body = msgBody;
        //        mailMessage.IsBodyHtml = false;

        //        SmtpClient sc = new SmtpClient("smtp.gmail.com", 465)
        //        {
        //            Credentials = new NetworkCredential(from, password),
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false
        //        };

        //        string successSend = $"Message was send. " +
        //                             $"\nFrom: { from } " +
        //                             $"\nTo: { to } " +
        //                             $"\nSubject: { msgSubject }" +
        //                             $"\nMessage body: { msgBody}";

        //        //try
        //        //{
        //        //    sc.Send(mailMessage);
        //        //    MessageBox.Show("Ура, получилось!\n" + successSend);
        //        //    Debug.WriteLine("Ура, получилось!\n" + successSend);
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    MessageBox.Show("не выходит( \n" + ex.Message.ToString());
        //        //    Debug.WriteLine("не выходит( \n" + ex.Message.ToString());
        //        //}

        //        //MessageBox.Show(successSend);
        //        Debug.WriteLine(successSend);

        //        SendEndWindow okWindow = new SendEndWindow();
        //        okWindow.ShowDialog();
        //    }
        //}
    }
}
