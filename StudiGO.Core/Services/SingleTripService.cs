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
    
    public async Task<SingleTripDto> GetSingleTripAsync(string context)
    {
        var singleTripDto = await _singleTripRepository.GetSingleTripAsync(context);
        
        return singleTripDto;
    }
}