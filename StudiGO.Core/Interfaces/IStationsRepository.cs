using StudiGO.Core.DTOs;

namespace StudiGO.Core.Interfaces;

public interface IStationsRepository
{
    Task<StationsDto> GetStationsAsync();
}