using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace App3over.RestClient
{
    public class RestClient<T>
    {
        private const string ApiUrl = "http://localhost:5000/api/AspNetUsers/";
        public async Task<List<T>> GetAsync()
        {
            var HttpClient = new HttpClient();
            var json = await HttpClient.GetStringAsync(ApiUrl);
            var AspNetUsers = JsonConvert.DeserializeObject<List<T>>(json);
            return AspNetUsers;
        }
        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();
            var jason = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(jason);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(ApiUrl, httpContent);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteAsync(int Id, T t)
        {
            var HttpClient = new HttpClient();
            var response = await HttpClient.DeleteAsync(ApiUrl + Id);
            return response.IsSuccessStatusCode;

        }

    }
}