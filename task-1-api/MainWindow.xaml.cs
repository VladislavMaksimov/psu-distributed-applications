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
using System.Text.RegularExpressions;

namespace task_1_api
{
    public partial class MainWindow : Window
    {
        string uriImage = "";

        public MainWindow()
        {
            // При инициализации компонента, вызываем окно авторизации и аутентификации
            InitializeComponent();
            AuthWindow auth = new AuthWindow();
            auth.ShowDialog();

            // Если невозможно отправлять запросы, приложение закрывается
            if (Config.token == "" || Config.userID == "")
                this.Close();

            // Добавление иллюстрации с котом
            JsonDocument postImage = JsonDocument.Parse(RequesterRandom.getImage());
            uriImage = postImage.RootElement[0].GetProperty("url").ToString();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uriImage, UriKind.Absolute);
            bitmap.EndInit();

            cat.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            cat.Source = bitmap;
        }

        // Отправка поста
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"[#&]");
            if (regex.Matches(messageText.Text).Count > 0)
            {
                MessageBox.Show("Недопустимые символы: # и &");
                return;
            }

            string postString = messageText.Text + "\n\n%23dist_apps";
            RequesterVK.createPost(postString);

            MessageBox.Show("Пост опубликован!");
        }

        // Генерация случайного поста
        private void generateRandom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JsonDocument postText = JsonDocument.Parse(RequesterRandom.getText());
                messageText.Text = postText.RootElement[0].ToString();
            }
            catch
            {

            }
        }

        // Получение постов
        private void getPosts()
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

                string id = items[i].GetProperty("id").ToString();

                TextBox textBox = new TextBox();
                textBox.Name = "post" + id;
                textBox.Width = 400;
                textBox.Height = 100;
                textBox.VerticalAlignment = VerticalAlignment.Top;
                textBox.Margin = new Thickness(0, 50 + i * 200, 0, 0);
                textBox.Text = finalText;
                textBox.TextWrapping = TextWrapping.Wrap;
                postsGrid.Children.Add(textBox);

                Button updateButton = new Button();
                updateButton.Content = "Сохранить";
                updateButton.VerticalAlignment = VerticalAlignment.Top;
                updateButton.Width = 150;
                updateButton.Height = 50;
                updateButton.Margin = new Thickness(0, 170 + i * 200, 250, 0);
                updateButton.Tag = id;
                updateButton.Click += updateButton_Click;
                postsGrid.Children.Add(updateButton);

                Button deleteButton = new Button();
                deleteButton.Content = "Удалить";
                deleteButton.VerticalAlignment = VerticalAlignment.Top;
                deleteButton.Width = 150;
                deleteButton.Height = 50;
                deleteButton.Margin = new Thickness(250, 170 + i * 200, 0, 0);
                deleteButton.Tag = id;
                deleteButton.Click += deleteButton_Click;
                postsGrid.Children.Add(deleteButton);
            }
        }

        // Удаление выбранного поста
        private void deleteButton_Click (object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            RequesterVK.deletePost(button.Tag.ToString());
            postsGrid.Children.Clear();
            getPosts();
        }
        
        // Редактирование выбранного поста
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBox textBox = (TextBox)LogicalTreeHelper.FindLogicalNode(postsGrid, "post" + button.Tag.ToString());
            Regex regex = new Regex(@"[#&]");
            if (regex.Matches(textBox.Text).Count > 0)
            {
                MessageBox.Show("Недопустимые символы: # и &");
                return;
            }
            string temp = RequesterVK.updatePost(button.Tag.ToString(), textBox.Text + "\n\n%23dist_apps").Result;
            postsGrid.Children.Clear();
            getPosts();
        }

        private void tab_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (postsTab.IsSelected)
            {
                getPosts();
            }
            else
            {
                postsGrid.Children.Clear();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/C RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255");
        }
    }
}
