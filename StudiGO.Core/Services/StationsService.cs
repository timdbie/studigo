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

    public async Task<StationsDto> GetFilteredStationsAsync(string query)
    {
        var stations = await GetAllStationsAsync();

        List<Payload> filteredPayload = stations.Payload.ToList();

        foreach (var payload in stations.Payload)
        {
            var namen = payload.Namen;

            if (!namen.Lang.StartsWith(query, StringComparison.OrdinalIgnoreCase))
            {
                filteredPayload.Remove(payload);
            }
        }

        stations.Payload = filteredPayload;

        return stations;
    }
    
    private async Task<StationsDto> GetAllStationsAsync()
    {
        try
        {
            return await _stationsRepository.GetStationsAsync();;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "An error occured in StationsService");
            throw;
        }
    }
}
