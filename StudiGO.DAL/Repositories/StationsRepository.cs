using Newtonsoft.Json;
using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.DAL.Repositories;

public class StationsRepository : ApiRepository, IStationsRepository
{
    public async Task<StationsDto> GetStationsAsync(string query, int limit)
    {
        string endpoint = $"/v2/stations?q={query}&countryCodes=NL&limit={limit}";
        HttpResponseMessage response = await GetApiResponseAsync(endpoint);
        
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StationsDto>(jsonResponse);
    }
}