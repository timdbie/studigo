using Microsoft.Extensions.Logging;
using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class TripsService
{
    private readonly ITripsRepository _tripsRepository;
    private readonly ILogger<TripsService> _logger;

    public TripsService(ITripsRepository tripsRepository, ILogger<TripsService> logger)
    {
        _tripsRepository = tripsRepository;
        _logger = logger;
    }
    
    public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        try
        {
            var tripsDto = await _tripsRepository.GetTripsAsync(fromStation, toStation, dateTime);

            return tripsDto;
        }         
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "An error occured in TripsService");
            throw;
        }
    }
}