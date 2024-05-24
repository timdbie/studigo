using Microsoft.Extensions.Logging;
using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class SingleTripService
{
    private readonly ISingleTripRepository _singleTripRepository;
    private readonly ILogger<SingleTripService> _logger;

    public SingleTripService(ISingleTripRepository singleTripRepository, ILogger<SingleTripService> logger)
    {
        _singleTripRepository = singleTripRepository;
        _logger = logger;
    }
    
    public async Task<SingleTripDto> GetSingleTripAsync(string context)
    {
        try
        {
            return await _singleTripRepository.GetSingleTripAsync(context);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "An error occured in SingleTripService");
            throw;
        }
    }
}