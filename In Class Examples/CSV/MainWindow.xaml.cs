using System;
using System.Collections.Generic;
using System.IO;
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

namespace CSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath;
        public MainWindow()
        {
            InitializeComponent();

            lstLines.Items.Clear();
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {

            filePath = txtFilePath.Text;

            if (File.Exists(filePath) == true)
            {
                btnProcess.IsEnabled = true;
                btnSelectFile.IsEnabled = false;
                txtFilePath.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Invalid file, please try again", "ERROR", MessageBoxButton.OK);
                txtFilePath.Text = "";
                txtFilePath.Text = string.Empty;
                txtFilePath.Clear();
                txtFilePath.Focus();
            }
            

        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            // DONT NEED THIS ANYMORE SINCE WE MADE filePath a class level variable
            //string filePath = txtFilePath.Text;

            var lines = File.ReadAllLines(filePath);

            //foreach (var line in lines)
            //{
            //    lstLines.Items.Add(line);
            //}
            double sum = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                var pieces = lines[i].Split(',');

                double val = 0;

                bool success = double.TryParse(pieces[2], out val);
                if (success == false)
                {
                    MessageBox.Show("ERROR ON LINE " + i);
                }
                else
                {
                    sum += val;
                }

                //sum += Convert.ToDouble(pieces[2]);
                lstLines.Items.Add(pieces[1]);
            }
            MessageBox.Show($"The total sum of Price is {sum.ToString("C2")}!");
        }


    }
}
