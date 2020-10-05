using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Net.Http;
using Newtonsoft.Json;


namespace Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PokemonInfo poke;

        private bool showFront = true;

        public MainWindow()
        {
            InitializeComponent();

            PokemonAPI pokemonApiResults;

            string apiURL = @"https://pokeapi.co/api/v2/pokemon/?offset=0&limit=1100";

            using (var client = new HttpClient())
            {
                string jsonResults = client.GetStringAsync(apiURL).Result;

                pokemonApiResults = JsonConvert.DeserializeObject<PokemonAPI>(jsonResults);

            }

            // do more stuff
            // e.g. add results to a listbox/combobox
            foreach (var item in pokemonApiResults.results)
            {
                cboPokemon.Items.Add(item);
            }

        }

        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPokemon = (AllResults)cboPokemon.SelectedItem;

            using (var client = new HttpClient())
            {
                string jsonResults = client.GetStringAsync(selectedPokemon.url).Result;

                poke = JsonConvert.DeserializeObject<PokemonInfo>(jsonResults);
            }

            

            SetImageByURL(poke.sprites.front_default);
            showFront = false;
            btnFlip.IsEnabled = true;
        }

        private void SetImageByURL(string urlToImage)
        {
            imgPokemon.Source = new BitmapImage (new Uri(urlToImage));
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            if (showFront)
            {
                SetImageByURL(poke.sprites.front_default);

            }
            else
            {
                SetImageByURL(poke.sprites.back_default);
            }
            showFront = !showFront;
        }
    }
}
