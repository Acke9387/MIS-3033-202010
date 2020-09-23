using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string webService = @"https://rickandmortyapi.com/api/character/";

            //HttpClient client = new HttpClient();
            Characters characters;
            using (var client = new HttpClient())
            {
                var results = client.GetStringAsync(webService).Result;

                characters = JsonConvert.DeserializeObject<Characters>(results);
            }

            foreach (var character in characters.results)
            {
                cboCharacters.Items.Add(character);
            }
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var character = (Character)cboCharacters.SelectedItem;
            var uri = new Uri(character.image);
            var img = new BitmapImage(uri);
            imgCharacter.Source = img;
            //imgCharacter.Source = new BitmapImage(new Uri(character.image));
            lblName.Content = $"{character.name} is {character.status}";
        }
    }
}
