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
using TracksDB;
using System.Data.Entity;



namespace TracksDBUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        TracksDB.Model1Container _dbContainer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _dbContainer.TracksSet.Add(new TracksDB.Tracks
            {
                AuthorName = ArtistNameTxt.Text,
                TrackName = TrackNameTxt.Text
            });
            _dbContainer.SaveChanges();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if(vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    int id = (row.Item as Tracks).Id;

                    Tracks track = _dbContainer.TracksSet.Where(o => o.Id == id).FirstOrDefault();

                    _dbContainer.TracksSet.Remove(track);
                    _dbContainer.SaveChanges();
                    tbStatus.Text = id + "was removed";
                    break;
                }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dbContainer = new TracksDB.Model1Container();
            _dbContainer.TracksSet.Load();
            dgGrid.ItemsSource = _dbContainer.TracksSet.Local;
        }
    }
}
