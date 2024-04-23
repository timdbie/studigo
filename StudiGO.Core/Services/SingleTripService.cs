using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class SingleTripService
{
    private readonly ISingleTripRepository _singleTripRepository;

    public SingleTripService(ISingleTripRepository singleTripRepository)
    {
        _singleTripRepository = singleTripRepository;
    }
    
    public async Task<SingleTripDto> GetTripsAsync(string ctxRecon)
    {
        var singleTripDto = await _singleTripRepository.GetTripAsync(ctxRecon);
        
        return singleTripDto;
    }
}