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
using System.Windows.Shapes;

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for PokemonInfoWindow.xaml
    /// </summary>
    public partial class PokemonInfoWindow : Window
    {
        //public PokemonInfo poke;
        public AllResults sp { get; set; }

        public PokemonInfoWindow()
        {
            InitializeComponent();
        }

        public void Setup()//(AllResults selectedPokemon)
        {
            PokemonInfo poke;
            var selectedPokemon = sp;
            using (var client = new HttpClient())
            {
                string jsonResults = client.GetStringAsync(selectedPokemon.url).Result;

                poke = JsonConvert.DeserializeObject<PokemonInfo>(jsonResults);
            }



            SetImageByURL(poke.sprites.front_default);
            lblPokemonName.Content = selectedPokemon.name;
        }

        private void SetImageByURL(string urlToImage)
        {
            imgPokemon.Source = new BitmapImage(new Uri(urlToImage));
        }
    }
}
