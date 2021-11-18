using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;



namespace WpfTestMailSender.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AccessCommand
        {
            get
            {
                return new DelegateCommand(Execute);
            }
        }

        public ICommand SendMessage
        {
            get
            {
                return new DelegateCommand(ExecuteSend);
            }
        }

        string _login;
        string _password;
        
        private void Execute(object obj)
        {
            if(MailSendlerLogic.CheckAccess(_login, _password))
            {
                System.Diagnostics.Debug.WriteLine("Access true");
                System.Windows.Controls.TabControl tabControl = (obj as System.Windows.Controls.TabControl);
                foreach (var el in tabControl.Items)
                    (el as System.Windows.Controls.TabItem).IsEnabled = true;
                var curEl = tabControl.SelectedItem as System.Windows.Controls.TabItem;
                (curEl as System.Windows.Controls.TabItem).IsEnabled = false;
                tabControl.SelectedIndex++;
            }
            else System.Diagnostics.Debug.WriteLine("Invalid login and/or password");
        }

        public string Login 
        { 
            get { return _login; } 
            set 
            {
                if (_login != value)
                {
                    _login = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("admin1"));
                    System.Diagnostics.Debug.WriteLine("Login was changed: " + _login);
                }
            } 
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("admin1"));
                    System.Diagnostics.Debug.WriteLine("Password was changed: " + _login);
                }
            }
        }

        string _mfFrom;
        string _mfTo;
        string _mfMsgSubj;
        string _mfMsgBody;

        public string mfFrom
        {
            get { return _mfFrom; }
            set
            {
                if (_mfFrom != value)
                {
                    _mfFrom = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("_mfFrom"));
                    System.Diagnostics.Debug.WriteLine("Field 'From' was changed: " + _mfFrom);
                }
            }
        }

        public string mfTo
        {
            get { return _mfTo; }
            set
            {
                if (_mfTo != value)
                {
                    _mfTo = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("_mfTo"));
                    System.Diagnostics.Debug.WriteLine("Field 'To' was changed: " + _mfTo);
                }
            }
        }

        public string mfMsgSubj
        {
            get { return _mfMsgSubj; }
            set
            {
                if (_mfMsgSubj != value)
                {
                    _mfMsgSubj = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("_mfMsgSubj"));
                    System.Diagnostics.Debug.WriteLine("Field 'Subj' was changed: " + _mfMsgSubj);
                }
            }
        }

        public string mfMsgBody
        {
            get { return _mfMsgBody; }
            set
            {
                if (_mfMsgBody != value)
                {
                    _mfMsgBody = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("_mfMsgBody"));
                    System.Diagnostics.Debug.WriteLine("Field 'Body' was changed: " + _mfMsgBody);
                }
            }
        }

        private void ExecuteSend(object obj)
        {
            MailForm newMail = new MailForm(_mfFrom, _mfTo, _mfMsgSubj, _mfMsgBody);
            if (!MailSendlerLogic.CheckAdress(_mfFrom))
            {
                System.Diagnostics.Debug.WriteLine("Неверный адрес отправителя!");
                return;
            }
            if (!MailSendlerLogic.CheckAdress(_mfTo))
            {
                System.Diagnostics.Debug.WriteLine("Неверный адрес получателя!");
                return;
            }

            MailSendlerLogic.SendMessage(newMail, _password);
            SendEndWindow okWindow = new SendEndWindow();
            okWindow.ShowDialog();
            System.Diagnostics.Debug.WriteLine("Success");
        }


    }
}
