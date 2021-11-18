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
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
        }

        public static readonly DependencyProperty PrevTextProperty = DependencyProperty.Register("PrevText", typeof(string), typeof(MoveControl), new PropertyMetadata("prev"));
        public static readonly DependencyProperty NextTextProperty = DependencyProperty.Register("NextText", typeof(string), typeof(MoveControl), new PropertyMetadata("next"));

        public string PrevText
        {
            get
            {
                return (string)GetValue(PrevTextProperty);
            }
            set
            {
                SetValue(PrevTextProperty, value);
            }
        }

        public string NextText
        {
            get
            {
                return (string)GetValue(NextTextProperty);
            }
            set
            {
                SetValue(NextTextProperty, value);
            }
        }

        public static readonly RoutedEvent btnPrevClickEvent = EventManager.RegisterRoutedEvent("btnPrevClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MoveControl));

        public static readonly RoutedEvent btnNextClickEvent = EventManager.RegisterRoutedEvent("btnNextClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MoveControl));

        public event RoutedEventHandler btnPrevClick
        {
            add { AddHandler(btnPrevClickEvent, value); }
            remove { RemoveHandler(btnPrevClickEvent, value); }
        }

        public event RoutedEventHandler btnNextClick
        {
            add { AddHandler(btnNextClickEvent, value); }
            remove { RemoveHandler(btnNextClickEvent, value); }
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btnPrevClickEvent);
            RaiseEvent(args);
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btnNextClickEvent);
            RaiseEvent(args);
        }


    }
}
