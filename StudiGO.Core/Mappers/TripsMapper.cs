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
                Transfers = tripResponse.Transfers,
                Status = tripResponse.Status
            };
            
            if (tripResponse.Legs.Count > 0)
            {
                trip.PlannedDepartureDateTime = DateTime.Parse(tripResponse.Legs[0].Origin.PlannedDateTime);
                trip.ActualDepartureDateTime = DateTime.Parse(tripResponse.Legs[0].Origin.ActualDateTime);
                trip.PlannedArrivalDateTime = DateTime.Parse(tripResponse.Legs[^1].Destination.PlannedDateTime);
                trip.ActualArrivalDateTime = DateTime.Parse(tripResponse.Legs[^1].Destination.ActualDateTime);
            }

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
        public string ActualDateTime { get; set; }
    }
}