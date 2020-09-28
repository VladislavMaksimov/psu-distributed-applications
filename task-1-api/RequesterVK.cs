using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace task_1_api
{
    class RequesterVK
    {
        static string token = "565aa3f38f4e6e04ada92989ba8a1a29b17065336c6353d025bd1b393d4c675ed69ff15db4b10013f0daa";
        static string uri = "https://api.vk.com/";

        static async void getToken()
        {

        }

        static async void createPost(string postText)
        { 
            string api = "method/wall.post?message=" + postText + "&access_token=" + token + "&v=5.124";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                await client.GetAsync(api);
            }
            catch
            {

            }
        }
    }
}
