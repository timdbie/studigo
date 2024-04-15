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
    
    public async Task<TripsDto> GetTripsAsync(string from, string to, string datetime)
    {
        var tripsDto = await _tripsRepository.GetTripsAsync(from, to, datetime);
        
        return tripsDto;
    }
}