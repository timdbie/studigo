using StudiGO.Core.DTOs;

namespace StudiGO.Core.Interfaces
{
    public interface ISingleTripRepository
    {
        Task<SingleTripDto> GetTripAsync(string ctxRecon);
    }
}