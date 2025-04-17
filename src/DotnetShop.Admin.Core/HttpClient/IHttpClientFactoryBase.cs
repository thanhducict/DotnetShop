namespace DotnetShop.Admin.Core.HttpClient
{
    public interface IHttpClientFactoryBase
    {
        public Task<T> GetAsync<T>(string clientName, string requestUri);
        public Task<T> PostAsync<T>(string clientName, string requestUri, object content);
        public Task<T> PutAsync<T>(string clientName, string requestUri, object content);
        public Task<T> DeleteAsync<T>(string clientName, string requestUri);
        public void SetAuthorizationHeader(string clientName, string token);
    }
}
