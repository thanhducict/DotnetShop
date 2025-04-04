using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace DotnetShop.WebApp.Services
{
    public class HttpClientFactoryBase(IHttpClientFactory httpClientFactory) : IHttpClientFactoryBase
    {
        private readonly JsonSerializerOptions serializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<T> GetAsync<T>(string clientName, string requestUri)
        {
            var client = httpClientFactory.CreateClient(clientName);
            var response = await client.GetAsync(requestUri);
            return await HandleResponse<T>(response);
        }

        public async Task<T> PostAsync<T>(string clientName, string requestUri, object content)
        {
            var client = httpClientFactory.CreateClient(clientName);
            var jsonString = JsonSerializer.Serialize(content);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUri, httpContent);
            return await HandleResponse<T>(response);
        }

        public async Task<T> PutAsync<T>(string clientName, string requestUri, object content)
        {
            var client = httpClientFactory.CreateClient(clientName);
            var jsonString = JsonSerializer.Serialize(content);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUri, httpContent);
            return await HandleResponse<T>(response);
        }

        public async Task<T> DeleteAsync<T>(string clientName, string requestUri)
        {
            var client = httpClientFactory.CreateClient(clientName);
            var response = await client.DeleteAsync(requestUri);
            return await HandleResponse<T>(response);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(jsonString, serializerOptions);

            return result;
        }

        public void SetAuthorizationHeader(string clientName, string token)
        {
            var client = httpClientFactory.CreateClient(clientName);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
