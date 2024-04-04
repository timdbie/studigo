using StudiGO.DAL.DTOs;
using Newtonsoft.Json;
using StudiGO.DAL.Infrastructure;

namespace StudiGO.DAL.Services;

public class ApiService
{
    private readonly HttpClientWrapper _httpClientWrapper;
    private readonly string _baseUrl;

    public ApiService(HttpClientWrapper httpClientWrapper, string baseUrl)
    {
        _httpClientWrapper = httpClientWrapper;
        _baseUrl = baseUrl;
    }
    
    public async Task<StationsDto[]> GetStationsAsync(string query, string countryCode, int limit)
    {
        string endpoint = $"/reisinformatie-api/api/v2/stations?q={query}&countryCodes={countryCode}&limit={limit}";
        return await GetApiResponseAsync<StationsDto[]>(endpoint);
    }
    
    private async Task<T> GetApiResponseAsync<T>(string endpoint)
    {
        try
        {
            HttpResponseMessage response = await _httpClientWrapper.GetAsync(_baseUrl + endpoint);
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