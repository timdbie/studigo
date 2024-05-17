using System.Net;
using StudiGO.DAL.Infrastructure;
using StudiGO.Core.DTOs;
using Newtonsoft.Json;
using StudiGO.Core.Interfaces;

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
            
            return response;
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
