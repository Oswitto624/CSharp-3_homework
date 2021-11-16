using System;
using System.Windows;

namespace WpfTestMailSender
{

    //класс создал для будущей работы с массовой рассылкой
    public class MailForm
    {
        private string from = "defaultSender@gmail.com";
        private string to = "defaultRecipient@gmail.com";
        private string msgSubject = "Default Subject";
        private string msgBody = "Default Subject";

        public string From
        {
            get => from;
            set => from = value;
        }

        public string To
        {
            get => to;
            set => to = value;
        }

        public string MsgSubject
        {
            get => msgSubject;
            set => msgSubject = value;
        }

        public string MsgBody
        {
            get => msgBody;
            set => msgBody = value;
        }

        public MailForm(string from, string to, string msgSubject, string msgBody)
        {
            From = from;
            To = to;
            MsgSubject = msgSubject;
            MsgBody = msgBody;
        }

    }
}
