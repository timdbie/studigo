using StudiGO.Core.DTOs;
namespace StudiGO.Web.Models;

public class StationsViewModel
{
    public List<Station> Stations { get; set; }
        
    public class Station
    {
        public Names Names { get; set; }
    }

    public class Names
    {
        public string Short { get; set; }
        public string Medium { get; set; }
        public string Long { get; set; }
    }

    public static StationsViewModel FromDto(StationsDto stationsDto)
    {
        StationsViewModel stationsViewModel = new StationsViewModel
        {
            Stations = new List<Station>()
        };

        foreach (var station in stationsDto.payload)
        {
            Station newStation = new Station()
            {
                Names = new Names
                {
                    Short = station.Namen.Kort,
                    Medium = station.Namen.Middel,
                    Long = station.Namen.Lang
                }
            };
            stationsViewModel.Stations.Add(newStation);
        }

        return stationsViewModel;
    }

}