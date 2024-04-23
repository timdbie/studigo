using StudiGO.Core.DTOs;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories;

public class SingleTripRepository : ApiBaseRepository, ISingleTripRepository
{
    public async Task<SingleTripDto> GetTripAsync(string ctxRecon)
    {
        string endpoint = $"/reisinformatie-api/api/v3/trips/trip?ctxRecon={ctxRecon}";
        return await GetApiResponseAsync<SingleTripDto>(endpoint);
    }
}