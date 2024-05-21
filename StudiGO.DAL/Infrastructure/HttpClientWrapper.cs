namespace StudiGO.DAL.Infrastructure
{
    public class HttpClientWrapper : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUrl, Dictionary<string, string>? headers = null)
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

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}