using StudiGO.Core.DTOs;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories;

public class SingleTripRepository : ApiRepository, ISingleTripRepository
{
    public async Task<SingleTripDto> GetSingleTripAsync(string context)
    {
        string endpoint = $"/v3/trips/trip?ctxRecon={context}";
        return await GetApiResponseAsync<SingleTripDto>(endpoint);
    }
}