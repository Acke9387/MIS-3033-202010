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
        public PokemonInfo poke;
        private bool showFront = false;
        public AllResults sp { get; set; }

        public PokemonInfoWindow()
        {
            InitializeComponent();
        }

        public void Setup()//(AllResults selectedPokemon)
        {
            var selectedPokemon = sp;
            using (var client = new HttpClient())
            {
                string jsonResults = client.GetStringAsync(selectedPokemon.url).Result;

                poke = JsonConvert.DeserializeObject<PokemonInfo>(jsonResults);
            }


            showFront = false;
            btnFlip.IsEnabled = true;
            SetImageByURL(poke.sprites.front_default);
            lblPokemonName.Content = selectedPokemon.name.ToUpper() ;
            this.Title = $"{selectedPokemon.name} Info";
        }

        private void SetImageByURL(string urlToImage)
        {
            imgPokemon.Source = new BitmapImage(new Uri(urlToImage));
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
