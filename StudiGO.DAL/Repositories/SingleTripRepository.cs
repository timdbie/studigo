using Newtonsoft.Json;
using StudiGO.Core.DTOs;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories;

public class SingleTripRepository : ApiRepository, ISingleTripRepository
{
    public async Task<SingleTripDto> GetSingleTripAsync(string context)
    {
        string endpoint = $"/v3/trips/trip?ctxRecon={context}";
        HttpResponseMessage response = await GetApiResponseAsync(endpoint);
        
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SingleTripDto>(jsonResponse);
    }
}