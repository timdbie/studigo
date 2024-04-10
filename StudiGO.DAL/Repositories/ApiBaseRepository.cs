using StudiGO.DAL.Infrastructure;
using Newtonsoft.Json;

namespace StudiGO.DAL.Repositories
{
    public abstract class ApiBaseRepository
    {
        private readonly HttpClientWrapper _httpClientWrapper;
        private readonly string _baseUrl;
        private readonly string _subscriptionKey;

        public ApiBaseRepository(HttpClientWrapper httpClientWrapper, string baseUrl)
        {
            _httpClientWrapper = httpClientWrapper;
            _baseUrl = baseUrl;
            _subscriptionKey = GetSubscriptionKey();
        }

        public async Task<T> GetApiResponseAsync<T>(string endpoint)
        {
            try
            {
                var headers = new Dictionary<string, string>
                {
                    { "Ocp-Apim-Subscription-Key", _subscriptionKey }
                };

                HttpResponseMessage response = await _httpClientWrapper.GetAsync(_baseUrl + endpoint, headers).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching data from {_baseUrl}{endpoint}: {ex.Message}", ex);
            }
        }

        public Task<TResponse> GetAsync<TResponse>(string endpoint) => GetApiResponseAsync<TResponse>(endpoint);

        private string GetSubscriptionKey()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("STUDIGO_SUBSCRIPTION_KEY");
            if (string.IsNullOrEmpty(subscriptionKey))
            {
                throw new InvalidOperationException("STUDIGO_SUBSCRIPTION_KEY is missing or empty.");
            }
            return subscriptionKey;
        }
    }
}
