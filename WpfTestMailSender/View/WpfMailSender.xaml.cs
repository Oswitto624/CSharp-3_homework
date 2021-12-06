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


        private void Email_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                System.Diagnostics.Debug.WriteLine("err");
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                if (!((BindingExpressionBase)e.Error.BindingInError).HasError)
                {
                    ((Control)sender).ToolTip = null;
                    //System.Diagnostics.Debug.WriteLine("ok");
                    //((Control)sender).ToolTip = null;
                }

            }

        }
    }
}

