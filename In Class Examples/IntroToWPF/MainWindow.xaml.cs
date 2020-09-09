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

namespace IntroToWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtAge.Text = string.Empty;
            txtName.Clear();
        }

        private void btnGo_MouseEnter(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("You have entered the button", "ENTERED");
            btnGo.Background = new SolidColorBrush(Colors.Red);
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            string name, age;
            name = txtName.Text;
            age = txtAge.Text;

            int ageAsNumber = Convert.ToInt32(age);

            txtName.Clear();
            txtAge.Text = string.Empty;

            //DateTime birthdate = Convert.ToDateTime({DATE_AS_A_STRING_HERE});
            //var howOldTheyAre = DateTime.Now - birthdate;
            //int old = Convert.ToInt32(howOldTheyAre.TotalDays / 365);

            //btnGo.Background = new SolidColorBrush(Colors.Red);

            MessageBox.Show($"Welcome {name} who is {age}");

        }
    }
}
