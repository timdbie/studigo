using StudiGO.DAL.Infrastructure;
using StudiGO.Core.DTOs;
using Newtonsoft.Json;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories
{
    public class ApiRepository: IApiRepository
    {
        private static readonly HttpClientWrapper _httpClientWrapper = new();
        private static readonly string _baseUrl = "https://gateway.apiportal.ns.nl/reisinformatie-api/api";

        private readonly string _subscriptionKey;

        public ApiRepository()
        {
            _subscriptionKey = GetSubscriptionKey();
        }

        private async Task<T> GetApiResponseAsync<T>(string endpoint)
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

        private string GetSubscriptionKey()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("STUDIGO_SUBSCRIPTION_KEY");
            if (string.IsNullOrEmpty(subscriptionKey))
            {
                throw new InvalidOperationException("STUDIGO_SUBSCRIPTION_KEY is missing or empty.");
            }
            return subscriptionKey;
        }

        public async Task<StationsDto> GetStationsAsync(string query, string countryCode, int limit)
        {
            string endpoint = $"/v2/stations?q={query}&countryCodes={countryCode}&limit={limit}";
            return await GetApiResponseAsync<StationsDto>(endpoint);
        }

        public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
        {
            string endpoint = $"/v3/trips?fromStation={fromStation}&toStation={toStation}&dateTime={dateTime}";
            return await GetApiResponseAsync<TripsDto>(endpoint);
        }
        
        public async Task<SingleTripDto> GetSingleTripAsync(string context)
        {
            string endpoint = $"/v3/trips/trip?ctxRecon={context}";
            return await GetApiResponseAsync<SingleTripDto>(endpoint);
        }
    }
}
