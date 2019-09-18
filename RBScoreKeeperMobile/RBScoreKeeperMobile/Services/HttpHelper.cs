using Newtonsoft.Json;
using RBScoreKeeperMobile.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RBScoreKeeperMobile.Services
{
    public class HttpHelper
    {
        private static HttpHelper instance;
        private string baseAddress = "https://rbscorekeeper.azurewebsites.net/api/";

        public static HttpHelper Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new HttpHelper();
                }

                return instance;
            }
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            T result = default(T);

            using (HttpClientHandler ClientHandler = new HttpClientHandler())
            using (HttpClient client = new HttpClient(ClientHandler))
            {
                client.BaseAddress = new Uri(baseAddress);
                using (HttpResponseMessage ResponseMessage = await client.GetAsync(uri))
                {
                    if (ResponseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        using (HttpContent Content = ResponseMessage.Content)
                        {
                            string json = await Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<T>(json);
                        }
                    }
                }
            }

            return result;
        }

        public async Task<List<T>> GetListAsync<T>(string uri)
        {
            List<T> result = new List<T>();

            using (HttpClientHandler ClientHandler = new HttpClientHandler())
            using (HttpClient client = new HttpClient(ClientHandler))
            {
                client.BaseAddress = new Uri(baseAddress);
                using (HttpResponseMessage ResponseMessage = await client.GetAsync(uri))
                {
                    if (ResponseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        using (HttpContent Content = ResponseMessage.Content)
                        {
                            string json = await Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<T>>(json);
                        }
                    }
                }
            }

            return result;
        }

        public async Task<HttpStatusCode> PostAsync<T>(string uri, T data)
        {
            using (HttpClientHandler ClientHandler = new HttpClientHandler())
            using (HttpClient client = new HttpClient(ClientHandler))
            {
                client.BaseAddress = new Uri(baseAddress);
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage ResponseMessage = await client.PostAsync(uri, content))
                {
                    return ResponseMessage.StatusCode;
                }
            }
        }

        public async Task<HttpStatusCode> DeleteAsync(string uri)
        {
            using (HttpClientHandler ClientHandler = new HttpClientHandler())
            using (HttpClient client = new HttpClient(ClientHandler))
            {
                client.BaseAddress = new Uri(baseAddress);
                using (HttpResponseMessage ResponseMessage = await client.DeleteAsync(uri))
                {
                    return ResponseMessage.StatusCode;
                }
            }
        }
    }
}
