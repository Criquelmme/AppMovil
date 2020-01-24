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
        public async Task<T> post<T>(StringContent data)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url, data);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }


    }
}

 
