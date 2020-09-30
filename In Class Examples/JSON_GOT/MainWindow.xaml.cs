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

namespace JSON_GOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerateQuote_Click(object sender, RoutedEventArgs e)
        {
            string gotApiUrl = @"https://got-quotes.herokuapp.com/quotes";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(gotApiUrl).Result;

                var gotQuote = JsonConvert.DeserializeObject<GOTQuoteAPI>(json);
                lblQuote.Content = $"{gotQuote.quote} \n\n\t- {gotQuote.character}";
            }
        }
    }
}
