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

        public async Task<TDto> GetApiResponseAsync<TDto>(string endpoint, Func<string, TDto> mapper)
        {
            var headers = new Dictionary<string, string>
            {
                { "Ocp-Apim-Subscription-Key", _subscriptionKey }
            };

            HttpResponseMessage response = await _httpClientWrapper.GetAsync(_baseUrl + endpoint, headers).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return mapper(json);
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