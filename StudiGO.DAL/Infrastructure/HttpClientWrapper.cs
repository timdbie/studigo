using System.Net.Http;
using System.Threading.Tasks;

namespace StudiGO.DAL.Infrastructure
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUrl, IDictionary<string, string>? headers = null)
        {
            try
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                return await _httpClient.GetAsync(requestUrl);
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}