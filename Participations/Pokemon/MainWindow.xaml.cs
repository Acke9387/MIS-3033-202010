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
            foreach (var item in pokemonApiResults.Results)
            {
                cboPokemon.Items.Add(item);
            }

        }
    }
}
