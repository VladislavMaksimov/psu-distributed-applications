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
        static string uri = "https://api.vk.com/";

        static public async void createPost(string postText)
        { 
            string api = "method/wall.post?message=" + postText + "&access_token=" + Config.token + "&v=5.124";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                var content = new FormUrlEncodedContent(new Dictionary<string, string>());
                await client.PostAsync(api, content);
            }
            catch
            {

            }
        }

        static public async Task<string> getPosts()
        {
            string api = "method/wall.get?" + "access_token=" + Config.token + "&v=5.124";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                HttpResponseMessage response = client.GetAsync(api).Result;
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch
            {
                
            }
        }

        static public async void deletePost(string id)
        {
            string api = "method/wall.delete?post_id=" + id + "&access_token=" + Config.token + "&v=5.124";
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

        static public async void updatePost(string id, string message)
        {
            string api = "method/wall.edit?post_id=" + id + "&message=" + message + "&access_token=" + Config.token + "&v=5.124";
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
