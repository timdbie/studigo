using Newtonsoft.Json;
using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.DAL.Repositories;

public class StationsRepository : ApiRepository, IStationsRepository
{
    public async Task<StationsDto> GetStationsAsync()
    {
        string endpoint = $"/v2/stations?";
        HttpResponseMessage response = await GetApiResponseAsync(endpoint);
        
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StationsDto>(jsonResponse);
    }
}