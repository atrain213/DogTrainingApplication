using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class WebConnect
    {
        private static readonly string _endpoint = "https://localhost:44383/api/";
        private static readonly HttpClient _client = new();
        private static bool _firstrun = true;

        private static void Init()
        {
            HttpRequestHeaders reqheader = _client.DefaultRequestHeaders;
            if (reqheader.Accept == null || !reqheader.Accept.Any(m => m.MediaType == "application/json"))
            {
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            _firstrun = false;
        }
        public static async Task<List<APIDog>> DogListAsync()
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog";

            HttpResponseMessage? response;

            List<APIDog> api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        List<APIDog>? des = JsonSerializer.Deserialize<List<APIDog>>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<APIDogDetail> DogAsync(int id)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/" + id.ToString();

            HttpResponseMessage? response;

            APIDogDetail api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        APIDogDetail? des = JsonSerializer.Deserialize<APIDogDetail>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

    }
}
