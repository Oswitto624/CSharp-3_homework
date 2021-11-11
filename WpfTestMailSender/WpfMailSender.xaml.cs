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
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

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
            MailSendlerLogic.SendMessage(tbFrom.Text, PasswordBox.Password, tbTo.Text, tbMailSubject.Text, tbMailBody.Text);
        }

        private void btnAddNewTo_Click(object sender, RoutedEventArgs e)
        {
            tbAddNewTo.Visibility = Visibility.Visible;
            btnAddNewTo.Visibility = Visibility.Hidden;
        }
    }
}
