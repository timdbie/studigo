using StudiGO.Core.DTOs;

namespace StudiGO.DAL.Repositories;

public class StationsRepository : ApiBaseRepository
{
    public async Task<StationsDto> GetStationsAsync(string query, string countryCode, int limit)
    {
        string endpoint = $"/reisinformatie-api/api/v2/stations?q={query}&countryCodes={countryCode}&limit={limit}";
        return await GetAsync<StationsDto>(endpoint);
    }
}