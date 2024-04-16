using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class TripsService
{
    private readonly ITripsRepository _tripsRepository;

    public TripsService(ITripsRepository tripsRepository)
    {
        _tripsRepository = tripsRepository;
    }
    
    public async Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        var tripsDto = await _tripsRepository.GetTripsAsync(fromStation, toStation, dateTime);
        
        return tripsDto;
    }
}