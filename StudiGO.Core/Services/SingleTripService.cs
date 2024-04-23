using StudiGO.Core.Interfaces;
using StudiGO.Core.DTOs;

namespace StudiGO.Core.Services;

public class SingleTripService
{
    private readonly IApiRepository _apiRepository;

    public SingleTripService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }
    
    public async Task<SingleTripDto> GetSingleTripAsync(string ctxRecon)
    {
        var singleTripDto = await _apiRepository.GetSingleTripAsync(ctxRecon);
        
        return singleTripDto;
    }
}