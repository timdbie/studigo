using StudiGO.Core.DTOs;

namespace StudiGO.Core.Interfaces
{
    public interface IApiRepository
    {
        Task<StationsDto> GetStationsAsync(string query, int limit);
        Task<TripsDto> GetTripsAsync(string fromStation, string toStation, string dateTime);
        Task<SingleTripDto> GetSingleTripAsync(string context);
    }
}