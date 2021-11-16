using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class MoveControl : UserControl
    {
        public MoveControl()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent ClickNextEvent = EventManager.RegisterRoutedEvent("PressNextBtn", RoutingStrategy.Bubble, 
                                                                                            typeof(RoutedEventHandler), typeof(MoveControl));

        public event RoutedEventHandler PressNextBtn
        {
            add
            {
                this.AddHandler(ClickNextEvent, value);
            }
            remove
            {
                this.RemoveHandler(ClickNextEvent, value);
            }
        }

        private void OnBtnNextPush(object sender, )
        {

        }


        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
