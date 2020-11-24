using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace task_1_api
{
    class RequesterRandom
    {
        // Отправление GET-запроса к api
        static async Task<string> getRequest(string uri, string api)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();

            try
            {
                HttpResponseMessage response = client.GetAsync(api).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        // Получение рандомного текста сообщения
        public static string getText()
        {
            string uri = "https://baconipsum.com/";
            string api = "api/?type=all-meat&sentences=1";

            return getRequest(uri, api).Result;
        }


        // Получение рандомной иллюстрации с котом
        public static string getImage()
        {
            string uri = "https://api.thecatapi.com/";
            string api = "v1/images/search";

            return getRequest(uri, api).Result;
        }
    }
}
