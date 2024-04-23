using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class TripsService
{
    private readonly IApiRepository _apiRepository;

    public TripsService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }
    
    public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        var tripsDto = await _apiRepository.GetTripsAsync(fromStation, toStation, dateTime);
        
        return tripsDto;
    }
}