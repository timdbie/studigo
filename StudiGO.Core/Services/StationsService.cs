using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class StationsService
{
    private readonly IStationsRepository _stationsRepository;

    public StationsService(IStationsRepository stationsRepository)
    {
        _stationsRepository = stationsRepository;
    }
    
    public async Task<StationsDto> GetStationsAsync(string query, string countryCode, int limit)
    {
        var stationsDto = await _stationsRepository.GetStationsAsync(query, countryCode, limit);

        return stationsDto;
    }
}
