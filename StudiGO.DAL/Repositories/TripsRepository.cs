using Newtonsoft.Json;
using StudiGO.Core.DTOs;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories;

public class TripsRepository : ApiRepository, ITripsRepository
{
    public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        string endpoint = $"/v3/trips?fromStation={fromStation}&toStation={toStation}&dateTime={dateTime}";
        HttpResponseMessage response = await GetApiResponseAsync(endpoint);
        
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TripsDto>(jsonResponse);
    }
}