using StudiGO.DAL.Infrastructure;
using Newtonsoft.Json;

namespace StudiGO.DAL.Repositories
{
    public abstract class ApiBaseRepository
    {
        private static readonly HttpClientWrapper _httpClientWrapper = new();
        private static readonly string _baseUrl = "https://gateway.apiportal.ns.nl";

        private readonly string _subscriptionKey;

        public ApiBaseRepository()
        {
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
                // Move this to avoid generics!!!
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching data from {_baseUrl}{endpoint}: {ex.Message}", ex);
            }
        }

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