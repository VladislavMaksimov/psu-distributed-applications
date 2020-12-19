using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace client1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string host = "localhost";
        static string port = "8080";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            string surname = Generate_Surname.Text;
            string name = Generate_Name.Text;
            string second_name = Generate_Second_Name.Text;
            bool gender;

            if (Generate_Male.IsChecked == true)
                gender = true;
            else if (Generate_Male.IsChecked == false)
                gender = false;
            else return;

            if (surname == "" || name == "" || second_name == "")
                return;

            string api = "http://" + host + ':' + port + "/random/" + gender;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
            request.Method = "GET";
            request.Headers["Access-Control-Allow-Origin"] = "*";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //const api = 'http://' + host + ':' + port + '/random/' + gender;
            //fetch(api, {
            //method: 'get',
            //headers:
            //            {
            //                'Access-Control-Allow-Origin': '*'
            //    }
            //        })
            //.then(response => response.json())
            //.then(json => renderPerson(new Person(json['name'], json['surname'], json['second_name'])))

                //var person = new global::Person;
                //person.Name = 
        }

        private void Add_Surname_Click(object sender, RoutedEventArgs e)
        {
            var surname = new global::Unit();

            surname.Name = Add_Surname.Text;

            if (Add_Surname_Male.IsChecked == true)
                surname.Gender = true;
            else if (Add_Surname_Male.IsChecked == false)
                surname.Gender = false;
            else return;

            if (surname.Name == "")
                return;

            string api = "http://" + host + ':' + port + "/new/surname";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
            request.Method = "POST";
            request.ContentType = "application/protobuf";

            using (var stream = request.GetRequestStream())
            {
                surname.WriteTo(stream);
            }
            request.GetResponse();
        }

        private void Add_Name_Click(object sender, RoutedEventArgs e)
        {
            var name = new global::Unit();

            name.Name = Add_Name.Text;

            if (Add_Name_Male.IsChecked == true)
                name.Gender = true;
            else if (Add_Name_Male.IsChecked == false)
                name.Gender = false;
            else return;

            if (name.Name == "")
                return;

            string api = "http://" + host + ':' + port + "/new/name";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
            request.Method = "POST";
            request.ContentType = "application/protobuf";

            using (var stream = request.GetRequestStream())
            {
                name.WriteTo(stream);
            }
            request.GetResponse();
        }

        private void Add_Second_Name_Click(object sender, RoutedEventArgs e)
        {
            var second_name = new global::Unit();

            second_name.Name = Add_Second_Name.Text;

            if (Add_Second_Name_Male.IsChecked == true)
                second_name.Gender = true;
            else if (Add_Second_Name_Male.IsChecked == false)
                second_name.Gender = false;
            else return;

            if (second_name.Name == "")
                return;

            string api = "http://" + host + ':' + port + "/new/second_name";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
            request.Method = "POST";
            request.ContentType = "application/protobuf";

            using (var stream = request.GetRequestStream())
            {
                second_name.WriteTo(stream);
            }
            request.GetResponse();
        }
    }
}
