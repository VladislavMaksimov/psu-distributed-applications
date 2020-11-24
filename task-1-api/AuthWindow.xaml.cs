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
using System.Windows.Shapes;
using EO.WebBrowser;
using EO.WebEngine;
using System.Diagnostics;

namespace task_1_api
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            // Переход по нужному адресу для получения токена и id пользователя
            string api = "https://oauth.vk.com/authorize?client_id=" + Config.appID + "&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=wall&response_type=token&v=5.124";
            getToken.Navigate(api);
            getToken.LoadCompleted += GetToken_LoadCompleted;
        }

        private void GetToken_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // Дешифрование токена и id из файлов
            Config.decrypt();
            // Если токен и id не хранятся в файлах, получение их с помощью авторизации Вконтакте
            if (Config.token == "" || Config.userID == "")
            {
                char[] symbols = { '=', '&' };
                string[] url = getToken.Source.ToString().Split(symbols);
                if (url[0] != "https://oauth.vk.com/authorize?client_id")
                {
                    Config.token = url[1];
                    Config.userID = url[5];
                    Config.encrypt();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
