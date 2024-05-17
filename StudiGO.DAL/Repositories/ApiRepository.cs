using System.Net;
using StudiGO.DAL.Infrastructure;

namespace StudiGO.DAL.Repositories
{
    public class ApiRepository
    {
        private static readonly HttpClientWrapper _httpClientWrapper = new();
        private static readonly string _baseUrl = "https://gateway.apiportal.ns.nl/reisinformatie-api/api";

        private readonly string _subscriptionKey;

        public ApiRepository()
        {
            _subscriptionKey = GetSubscriptionKey();
        }

        public async Task<HttpResponseMessage> GetApiResponseAsync(string endpoint)
        {
            var headers = new Dictionary<string, string>
            {
                { "Ocp-Apim-Subscription-Key", _subscriptionKey }
            };

            HttpResponseMessage response = await _httpClientWrapper.GetAsync(_baseUrl + endpoint, headers).ConfigureAwait(false);
            
            // status code 200
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            //status code 400
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                string errorMessage = $"Bad request encountered at endpoint: {endpoint}";
                throw new HttpRequestException(errorMessage);
            }
            else
            {
                string errorMessage = $"Failed to retrieve data from endpoint: {endpoint}. Status code: {response.StatusCode}";
                throw new HttpRequestException(errorMessage); 
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
