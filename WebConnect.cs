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
        private static readonly string _endpoint = "https://dogapi.azurewebsites.net/api/";
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

        public static async Task<APIPicture> GetPicture(int id)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/picture/" + id.ToString();

            HttpResponseMessage? response;

            APIPicture api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        APIPicture? des = JsonSerializer.Deserialize<APIPicture>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<List<APIDogDetail>> DogbyTrainerAsync(int id)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/trainer/" + id.ToString();

            HttpResponseMessage? response;

            List<APIDogDetail> api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        List<APIDogDetail>? des = JsonSerializer.Deserialize<List<APIDogDetail>>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<int> LastDogforTrainerAsync(int id)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/trainer/lastdog/" + id.ToString();

            HttpResponseMessage? response;

            int api = 0;
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        api = JsonSerializer.Deserialize<int>(msg);
                    }
                }
            }
            return api;
        }

        public static async Task<List<APIDogDetail>> DogbyOwnerAsync(int id)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/owner/" + id.ToString();

            HttpResponseMessage? response;

            List<APIDogDetail> api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        List<APIDogDetail>? des = JsonSerializer.Deserialize<List<APIDogDetail>>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<List<APIDogBreeds>> BreedListAsync()
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/breeds";

            HttpResponseMessage? response;

            List<APIDogBreeds> api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        List<APIDogBreeds>? des = JsonSerializer.Deserialize<List<APIDogBreeds>>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<List<APITrick>> TricksAsync()
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/trick";

            HttpResponseMessage? response;

            List<APITrick> api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        List<APITrick>? des = JsonSerializer.Deserialize<List<APITrick>>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<List<APITrick>> TricksByDogAsync(int id)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/dogtrick/"+ id.ToString();

            HttpResponseMessage? response;

            List<APITrick> api = new();
            response = await _client.GetAsync(url);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        List<APITrick>? des = JsonSerializer.Deserialize<List<APITrick>>(msg);
                        if (des != null)
                        {
                            api = des;
                        }
                    }
                }
            }
            return api;
        }

        public static async Task<int> SaveDog(DTODog dto)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/dog";

            HttpResponseMessage? response;

            string body = dto.JsonText();
            HttpContent? content = null;
            if (body != null)
            {
                content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            int retval = 0;
            response = await _client.PostAsync(url, content);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        retval = JsonSerializer.Deserialize<int>(msg);
                    }
                }
            }
            return retval;
        }

        public static async Task<int> SavePicture(DTOPicture dto)
        {
            if (_firstrun) { Init(); }
            string url = _endpoint + "Dog/picture";

            HttpResponseMessage? response;

            string body = dto.JsonText();
            HttpContent? content = null;
            if (body != null)
            {
                content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            int retval = 0;
            response = await _client.PostAsync(url, content);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string? msg = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        retval = JsonSerializer.Deserialize<int>(msg);
                    }
                }
            }
            return retval;
        }

    }
}
