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
        
        List<Payload> filteredPayload = stationsDto.payload.ToList();
        
        foreach (var payload in stationsDto.payload)
        {
            var namen = payload.Namen;
            
            if (!namen.Lang.StartsWith(query, StringComparison.OrdinalIgnoreCase))
            {
                filteredPayload.Remove(payload);
            }
        }

        stationsDto.payload = filteredPayload;
        
        return stationsDto;
    }
}
