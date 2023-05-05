using DataGrid_SqLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MusicContext _ctx = new MusicContext();

        private static string[] adjectives = { "Red", "Big", "Oval", "Somber", "Blue", "Pink", "Humongous", "Terrifying" };
        private static string[] nouns = { "Sandal", "Sky", "Sun", "Boiler", "Loneliness", "Happiness", "Lobster", "Potato" };
        private static ObservableCollection<Track> tracks; 
        public MainWindow()
        {
            InitializeComponent();
            _ctx.Artists.ToList();

            tracks = new ObservableCollection<Track>(_ctx.Tracks);
            lv_tracks.ItemsSource = tracks;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            Track t = new Track() { Name = $"The {adjectives[r.Next(adjectives.Length - 1)]} {nouns[r.Next(nouns.Length - 1)]}", Artist = _ctx.Artists.ToList()[r.Next(_ctx.Artists.Count())] };
            _ctx.Tracks.Add(t);
            _ctx.SaveChanges();
            tracks.Add(t);
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (lv_tracks.SelectedItem == null)
            {
                MessageBox.Show("Select a track to update...");
                return;
            }

            Random r = new Random();

            Track t = lv_tracks.SelectedItem as Track;

            t.Name = $"The {adjectives[r.Next(adjectives.Length - 1)]} {nouns[r.Next(nouns.Length - 1)]}";
            _ctx.SaveChanges();
            lv_tracks.Items.Refresh();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (lv_tracks.SelectedItem == null)
            {
                MessageBox.Show("Select a track to delete...");
                return;
            }

            Track t = lv_tracks.SelectedItem as Track;

            _ctx.Remove(t);
            _ctx.SaveChanges();
            tracks.Remove(t);
        }
    }
}
