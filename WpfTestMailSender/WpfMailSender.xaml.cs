using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            MailForm newMail = new MailForm(tbTo.Text, tbFrom.Text, tbMailSubject.Text, tbMailBody.Text);
            if (!MailSendlerLogic.CheckAdress(tbFrom.Text))
            {
                MessageBox.Show("Неверный адрес отправителя!");
                return;
            }
            if (!MailSendlerLogic.CheckAdress(tbTo.Text))
            {
                MessageBox.Show("Неверный адрес получателя!");
                return;
            }

            MailSendlerLogic.SendMessage(newMail, PasswordBox.Password);
            SendEndWindow okWindow = new SendEndWindow();
            okWindow.ShowDialog();
        }

        private void FileInputBox_FileNameChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(fibFileInput.FileName);
        }

        private void fibFileInput_FileNameChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(fibFileInput.FileName);
        }

        private void Switcher_Next()
        {
            tcTabControl.SelectedIndex++;
        }

        private void Switcher_Prev()
        {
            tcTabControl.SelectedIndex--;
        }

        //private void btnAddNewTo_Click(object sender, RoutedEventArgs e)
        //{
        //    tbAddNewTo.Visibility = Visibility.Visible;
        //    btnAddNewTo.Visibility = Visibility.Hidden;
        //}

        //private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!MailSendlerLogic.CheckAdress(tbFrom.Text))
        //    {
        //        MessageBox.Show("Неверный адрес отправителя!");
        //    }
        //    else if (!MailSendlerLogic.CheckAdress(tbTo.Text))
        //    {
        //        MessageBox.Show("Неверный адрес получателя!");
        //    }
        //    else
        //    {
        //        MailSendlerLogic.SendMessage(tbFrom.Text, PasswordBox.Password, tbTo.Text, tbMailSubject.Text, tbMailBody.Text);
        //        SendEndWindow okWindow = new SendEndWindow();
        //        okWindow.ShowDialog();
        //    }
        //}
    }
}
