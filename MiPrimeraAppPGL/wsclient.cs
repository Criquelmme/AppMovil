using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiPrimeraAppPGL
{
    class wsclient : MainPage
    {
        public string url { get; set; }

        public async Task<T> Get<T>()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> Post<T>(string usr, string pass)
        {
            HttpClient client = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("usuario", usr),
                new KeyValuePair<string, string>("pass", pass)
                 }
            );

            var response =client.PostAsync(url, content).Result;

            string result = response.Content.ReadAsStringAsync().Result;
         
            return JsonConvert.DeserializeObject<T>(result);
        }


    }
}

 
