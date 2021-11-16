using Microsoft.Win32;
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
using System.Windows.Markup;

namespace LibControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    
    [ContentProperty("FileName")]
    public partial class FileInputBox : UserControl
    {
        public FileInputBox()
        {
            InitializeComponent();
            tbTextBox.TextChanged += new TextChangedEventHandler(OnTextChanged);
        }

        public event RoutedEventHandler FileNameChanged
        {
            add
            {
                this.AddHandler(FileNameChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(FileNameChangedEvent, value);
            }
        }

        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), 
                                                                                                            typeof(FileInputBox));
        public static readonly RoutedEvent FileNameChangedEvent = EventManager.RegisterRoutedEvent("FileNameChanged", 
                                                        RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileInputBox));

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(FileNameChangedEvent);
            RaiseEvent(args);
        }

        private void btnBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == true)
                this.FileName = d.FileName;
        }

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
                throw new InvalidOperationException("You can't change content!");
        }

    }
}