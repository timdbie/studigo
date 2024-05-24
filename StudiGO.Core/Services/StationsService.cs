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
    
    public async Task<StationsDto> GetFilteredStationsAsync(string query, int limit)
    {
        var stationsDto = await _stationsRepository.GetStationsAsync(query, limit);
        
        List<Station> filteredPayload = stationsDto.Payload.ToList();
        
        foreach (var payload in stationsDto.Payload)
        {
            var namen = payload.Namen;
            
            if (!namen.Lang.StartsWith(query, StringComparison.OrdinalIgnoreCase))
            {
                filteredPayload.Remove(payload);
            }
        }

        stationsDto.Payload = filteredPayload;
        
        return stationsDto;
    }
}
