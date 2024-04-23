using StudiGO.Core.DTOs;
using Newtonsoft.Json;

namespace StudiGO.Core.Mappers;

public class TripsMapper
{
    public static TripsDto MapFromJson(string json)
    {
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);

        var tripsDto = new TripsDto
        {
            Trips = new List<Trip>()
        };

        foreach (var tripResponse in apiResponse.Trips)
        {
            var trip = new Trip
            {
                PlannedDurationInMinutes = tripResponse.PlannedDurationInMinutes,
                ActualDurationInMinutes = tripResponse.ActualDurationInMinutes,
                PlannedDepartureDateTime = DateTime.Parse(tripResponse.Legs.First().Origin.PlannedDateTime),
                PlannedArrivalDateTime = DateTime.Parse(tripResponse.Legs.Last().Destination.PlannedDateTime),
                Transfers = tripResponse.Transfers,
                Status = tripResponse.Status
            };

            tripsDto.Trips.Add(trip);
        }

        return tripsDto;
    }

    private class ApiResponse
    {
        public List<TripResponse> Trips { get; set; }
    }

    private class TripResponse
    {
        public int PlannedDurationInMinutes { get; set; }
        public int ActualDurationInMinutes { get; set; }
        public int Transfers { get; set; }
        public string Status { get; set; }
        public List<LegResponse> Legs { get; set; }
    }

    private class LegResponse
    {
        public LocationResponse Origin { get; set; }
        public LocationResponse Destination { get; set; }
    }

    private class LocationResponse
    {
        public string PlannedDateTime { get; set; }
    }
}