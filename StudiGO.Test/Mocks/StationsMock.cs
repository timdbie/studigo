using StudiGO.Core.DTOs;

namespace StudiGO.Test.Mocks;

public class StationsMock
{
    public static StationsDto GetStations(string query, int limit)
    {
        var stations = GenerateStations(["Amsterdam, Rotterdam, Utrecht, Eindhoven, Sittard, Maastricht, Heerlen"]);

        var filteredStations = stations
            .Where(s => s.Namen.Lang.StartsWith(query, StringComparison.OrdinalIgnoreCase))
            .Take(limit)
            .ToList();
        
        return new StationsDto()
        {
            payload = filteredStations
        };
    }

    private static List<Payload> GenerateStations(string[] stations)
    {
        List<Payload> generatedStations = new();
        
        foreach (string name in stations)
        {
            Namen namen = new() { Lang = name };
            
            Payload payload = new() { Namen = namen };
            
            generatedStations.Add(payload);
        }
        return generatedStations;
    }

}