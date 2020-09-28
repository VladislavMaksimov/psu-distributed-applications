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
using System.Text.Json;

namespace task_1_api
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AuthWindow auth = new AuthWindow();
            auth.ShowDialog();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void generateRandom_Click(object sender, RoutedEventArgs e)
        {
            JsonDocument postText = JsonDocument.Parse(RequesterRandom.getText());
            JsonDocument postImage = JsonDocument.Parse(RequesterRandom.getImage());

            string uriImage = postImage.RootElement[0].GetProperty("url").ToString();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uriImage, UriKind.Absolute);
            bitmap.EndInit();

            cat.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            cat.Source = bitmap;
            messageText.Text = postText.RootElement[0].ToString();
        }
    }
}
