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

namespace WPF_textFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name;
        string lname;
        string fileName = @"C:\Users\Public\nameLast.txt";
        string text;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            name = FirstNameBox.Text;
            lname = LastNameBox.Text;

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(name + " " + lname);
                }

            }
            //catch if there is a problem writing to a textfile
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            text = System.IO.File.ReadAllText(@"C:\Users\Public\nameLast.txt");
            MessageBox.Show($"This text is from the textfile: {text}");
        }
    }
}
