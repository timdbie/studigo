using StudiGO.Core.DTOs;
using Newtonsoft.Json;

namespace StudiGO.Core.Mappers;

public class StationsMapper
{
    public static StationsDto MapFromJson(string json)
    {
        return JsonConvert.DeserializeObject<StationsDto>(json);
    }
}