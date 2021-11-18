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

        private void fibFileInput_FileNameChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(fibFileInput.FileName);
        }

        private void LibControls_TabSwitcherControl_btnPrevClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tcTabControl.SelectedIndex) == 0) return;
            tcTabControl.SelectedIndex--;
        }

        //не понял как получать последний индекс в TabControl, поэтому рамки проверки задаются вручную
        private void LibControls_TabSwitcherControl_btnNextClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tcTabControl.SelectedIndex) == 3) return;
            tcTabControl.SelectedIndex++;
        }

        //private void btnAddNewTo_Click(object sender, RoutedEventArgs e)
        //{
        //    tbAddNewTo.Visibility = Visibility.Visible;
        //    btnAddNewTo.Visibility = Visibility.Hidden;
        //}

        //private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        //{
        //    MailForm newMail = new MailForm(tbTo.Text, tbFrom.Text, tbMailSubject.Text, tbMailBody.Text);
        //    if (!MailSendlerLogic.CheckAdress(tbFrom.Text))
        //    {
        //        MessageBox.Show("Неверный адрес отправителя!");
        //        return;
        //    }
        //    if (!MailSendlerLogic.CheckAdress(tbTo.Text))
        //    {
        //        MessageBox.Show("Неверный адрес получателя!");
        //        return;
        //    }

        //    MailSendlerLogic.SendMessage(newMail, PasswordBox.Password);
        //    SendEndWindow okWindow = new SendEndWindow();
        //    okWindow.ShowDialog();
        //}
    }
}
