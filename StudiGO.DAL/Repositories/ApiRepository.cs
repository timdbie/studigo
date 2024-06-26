using System.Net;
using StudiGO.DAL.Infrastructure;

namespace StudiGO.DAL.Repositories
{
    public class ApiRepository
    {
        private readonly HttpClientWrapper _httpClientWrapper = new();
        private readonly string _baseUrl = "https://gateway.apiportal.ns.nl/reisinformatie-api/api";

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

            HttpResponseMessage response =
                await _httpClientWrapper.GetAsync(_baseUrl + endpoint, headers).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            
            string errorMessage;

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    errorMessage = $"Bad request encountered at endpoint: {endpoint}";
                    throw new HttpRequestException(errorMessage);

                case HttpStatusCode.Unauthorized:
                    errorMessage = "Unauthorized. Check your API subscription key.";
                    throw new HttpRequestException(errorMessage);

                case HttpStatusCode.NotFound:
                    errorMessage = $"The resource at endpoint {endpoint} was not found.";
                    throw new HttpRequestException(errorMessage);

                default:
                    errorMessage = $"Failed to retrieve data from endpoint: {endpoint}. Status code: {response.StatusCode}";
                    throw new HttpRequestException(errorMessage);
            }
        }

        private string GetSubscriptionKey()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("STUDIGO_SUBSCRIPTION_KEY");
            if (string.IsNullOrEmpty(subscriptionKey))
            {
                // TODO: Catch!!
                throw new InvalidOperationException("STUDIGO_SUBSCRIPTION_KEY is missing or empty.");
            }
            return subscriptionKey;
        }
    }
}
