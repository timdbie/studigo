using StudiGO.Core.DTOs;

namespace StudiGO.Core.Interfaces
{
    public interface ITripsRepository
    {
        Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime);
    }
}