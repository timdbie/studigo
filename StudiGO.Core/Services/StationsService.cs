using Microsoft.Extensions.Logging;
using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class StationsService
{
    private readonly IStationsRepository _stationsRepository;
    private readonly ILogger<StationsService> _logger;

    public StationsService(IStationsRepository stationsRepository, ILogger<StationsService> logger)
    {
        _stationsRepository = stationsRepository;
        _logger = logger;
    }
    
    public async Task<StationsDto> GetFilteredStationsAsync(string query, int limit)
    {
        try
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
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "An error occured in StationsService");
            throw;
        }
    }
}
