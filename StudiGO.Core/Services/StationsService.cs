using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class StationsService
{
    private readonly IApiRepository _apiRepository;

    public StationsService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }
    
    public async Task<StationsDto> GetFilteredStationsAsync(string query, string countryCode, int limit)
    {
        var stationsDto = await _apiRepository.GetStationsAsync(query, countryCode, limit);
        
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
