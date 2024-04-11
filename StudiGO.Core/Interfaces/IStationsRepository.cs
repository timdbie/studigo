using StudiGO.Core.DTOs;

namespace StudiGO.Core.Interfaces
{
    public interface IStationsRepository
    {
        Task<StationsDto> GetStationsAsync(string query, string countryCode, int limit);
    }
}