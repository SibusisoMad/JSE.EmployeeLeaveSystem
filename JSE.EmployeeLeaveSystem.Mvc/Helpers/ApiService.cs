using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.Mvc.Helpers
{
    public class ApiService
    {
        private static readonly HttpClient _client;

        private readonly string _baseUrl = "https://localhost:7264/api";

        static ApiService()
        {
            _client = new HttpClient();
        }

        private void SetAuthorizationHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
                string.IsNullOrWhiteSpace(token)
                ? null
                : new AuthenticationHeaderValue("Bearer", token);
        }

        private async Task EnsureSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API call failed ({response.StatusCode}): {error}");
            }
        }

        public async Task<T> GetAsync<T>(string endpoint, string token = null)
        {
            SetAuthorizationHeader(token);

            var response = await _client.GetAsync($"{_baseUrl}/{endpoint}");
            await EnsureSuccess(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> PostAsync<T>(string endpoint, object data, string token = null)
        {
            SetAuthorizationHeader(token);

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUrl}/{endpoint}", content);

            await EnsureSuccess(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> PutAsync<T>(string endpoint, object data, string token = null)
        {
            SetAuthorizationHeader(token);

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{_baseUrl}/{endpoint}", content);

            await EnsureSuccess(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> DeleteAsync<T>(string endpoint, string token = null)
        {
            SetAuthorizationHeader(token);

            var response = await _client.DeleteAsync($"{_baseUrl}/{endpoint}");

            await EnsureSuccess(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
