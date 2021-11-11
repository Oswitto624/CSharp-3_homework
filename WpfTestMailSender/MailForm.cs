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
        private string msgBody;

        //обрыботчик ошибки здесь почему-то не срабатывал, поэтому сделал обработку неверных адресов в классе логики через регулярное выражение
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                try
                {
                    from = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный адрес отправителя! \n"+ ex.Message.ToString());
                }
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                try
                {
                    to = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный адрес получателя! \n" + ex.Message.ToString());
                }
            }
        }

        public string MsgSubject
        {
            get
            {
                return msgSubject;
            }
            set
            {
                msgSubject = value;
            }
        }

        public string MsgBody
        {
            get
            {
                return msgBody;
            }
            set
            {
                msgBody = value;
            }
        }

        public MailForm(string from, string to, string msgSubject, string msgBody)
        {
            this.from = from;
            this.to = to;
            this.msgSubject = msgSubject;
            this.msgBody = msgBody;
        }
    }
}
