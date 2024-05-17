using StudiGO.Core.DTOs;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories;

public class TripsRepository : ApiRepository, ITripsRepository
{
    public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        string endpoint = $"/v3/trips?fromStation={fromStation}&toStation={toStation}&dateTime={dateTime}";
        return await GetApiResponseAsync<TripsDto>(endpoint);
    }
}