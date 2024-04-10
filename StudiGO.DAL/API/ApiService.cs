using StudiGO.DAL.API.DTOs;
using StudiGO.DAL.Infrastructure;
using Newtonsoft.Json;

namespace StudiGO.DAL.API;

public class ApiService
{
    private readonly HttpClientWrapper _httpClientWrapper;
    private readonly string _baseUrl;
    private readonly string _subscriptionKey;

    public ApiService(HttpClientWrapper httpClientWrapper, string baseUrl, string subscriptionKey)
    {
        _httpClientWrapper = httpClientWrapper;
        _baseUrl = baseUrl;
        _subscriptionKey = subscriptionKey;
    }
    
    public async Task<StationsDto> GetStationsAsync(string query, string countryCode, int limit)
    {
        string endpoint = $"/reisinformatie-api/api/v2/stations?q={query}&countryCodes={countryCode}&limit={limit}";
        return await GetApiResponseAsync<StationsDto>(endpoint);
    }
    
    private async Task<T> GetApiResponseAsync<T>(string endpoint)
    {
        try
        {
            var headers = new Dictionary<string, string>
            {
                { "Ocp-Apim-Subscription-Key", _subscriptionKey }
            };
            
            HttpResponseMessage response = await _httpClientWrapper.GetAsync(_baseUrl + endpoint, headers);
            response.EnsureSuccessStatusCode();
                
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        catch (HttpRequestException ex)
        {
            throw ex;
        }
    }
}