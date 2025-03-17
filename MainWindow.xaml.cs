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
using Microsoft.EntityFrameworkCore;

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MusicContext _ctx = new MusicContext();

        private static string[] adjectives = { "Red", "Big", "Oval", "Somber", "Blue", "Pink", "Humongous", "Terrifying", "Mostly Harmless" };
        private static string[] nouns = { "Sandals", "Sky", "Suns", "Boilers", "Loneliness", "Happiness", "Lobster", "Potato", "Dandelions", "Cats", "Cars", "Shoes", "Planets" };
        private static ObservableCollection<Track> tracks; 
        public MainWindow()
        {
            InitializeComponent();
            //_ctx.Artists.ToList();

            tracks = new ObservableCollection<Track>(_ctx.Tracks.Include(track => track.Artist));
            lv_tracks.ItemsSource = tracks;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();

            string prefix = ""; 
            
            switch (new Random().Next(4))
            {
                case 0: break;
                case 1: prefix = "The "; break;
                case 2: prefix = "Some "; break;
                case 3: prefix = "Several Species of "; break;
            }

            Track t = new Track($"{prefix}{adjectives[r.Next(adjectives.Length)]} {nouns[r.Next(nouns.Length)]}", new Random().Next(400),  _ctx.Artists.ToList()[r.Next(_ctx.Artists.Count())] as Artist);
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

            string prefix = ""; 

            switch (new Random().Next(4))
            {
                case 0: break;
                case 1: prefix = "The "; break;
                case 2: prefix = "Some "; break;
                case 3: prefix = "Several Species of "; break;
            }

            t.Name = $"{prefix}{adjectives[r.Next(adjectives.Length)]} {nouns[r.Next(nouns.Length)]}";
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
