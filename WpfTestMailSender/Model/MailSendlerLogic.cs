using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.IO;
using WpfTestMailSender.Model;

namespace WpfTestMailSender
{
    class MailSendlerLogic
    {
        
        public static bool CheckAccess(string login, string password)
        {
            Security sc = new Security();
            AuthData authData = new AuthData();
            AuthData.GetDataAuth("Database.txt", authData);
            //Debug.WriteLine(authData.ToString());
            
            if (sc.Decrypt(authData._trueLog, authData._trueLog.Length) == login && sc.Decrypt(authData._truePass, authData._truePass.Length) == password) return true;
            return false;
        }

        public static bool CheckAdress(string adress)
        {
            bool chk = false;
            Regex eMailAdress = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}");

            if (adress == null) return chk;
            else if (eMailAdress.IsMatch(adress))
            {
                chk = true;
            }
            return chk;
        }

        public static void SendMessage(MailForm email, string password)
        {
            using MailMessage mailMessage = new MailMessage(email.From, email.To)
            {
                Subject = email.MsgSubject,
                Body = email.MsgBody,
                IsBodyHtml = false
            };

            SmtpClient sc = new SmtpClient("smtp.gmail.com", 465)
            {
                Credentials = new NetworkCredential(email.From, password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            Debug.WriteLine($"Message was sent. \nFrom: { email.From } \nTo: { email.To } \nSubject: { email.MsgSubject }\nMessage body: { email.MsgBody }");
        }
          
        



    }
}