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
using System.Diagnostics;

namespace task_1_api
{
    public partial class MainWindow : Window
    {
        string uriImage = "";

        public MainWindow()
        {
            InitializeComponent();
            AuthWindow auth = new AuthWindow();
            auth.ShowDialog();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string postString = messageText.Text + "\n\n%23dist_apps";
            RequesterVK.createPost(postString, uriImage);
        }

        private void generateRandom_Click(object sender, RoutedEventArgs e)
        {
            JsonDocument postText = JsonDocument.Parse(RequesterRandom.getText());
            JsonDocument postImage = JsonDocument.Parse(RequesterRandom.getImage());

            uriImage = postImage.RootElement[0].GetProperty("url").ToString();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uriImage, UriKind.Absolute);
            bitmap.EndInit();

            cat.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            cat.Source = bitmap;
            messageText.Text = postText.RootElement[0].ToString();
        }

        private void tab_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (postsTab.IsSelected)
            {
                JsonDocument posts = JsonDocument.Parse(RequesterVK.getPosts().Result);
                var items = posts.RootElement.GetProperty("response").GetProperty("items");

                for (int i = 0; i < items.GetArrayLength(); i++)
                {
                    string postText = items[i].GetProperty("text").ToString();

                    if (!postText.Contains("#dist_apps"))
                        continue;

                    string finalText = "";
                    foreach (string substr in postText.Split(new[] { "#dist_apps" }, StringSplitOptions.None))
                        finalText += substr;

                    TextBox textBox = new TextBox();
                    textBox.Name = "post" + items[i].GetProperty("id").ToString();
                    textBox.Width = 400;
                    textBox.Height = 100;
                    textBox.VerticalAlignment = VerticalAlignment.Top;
                    textBox.Margin = new Thickness(0, i * 200, 0, 0);
                    textBox.Text = finalText;
                    textBox.TextWrapping = TextWrapping.Wrap;
                    postsGrid.Children.Add(textBox);
                }
            }
            else
            {
                postsGrid.Children.Clear();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Process.Start("cmd.exe", "/C RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255");
        }
    }
}
