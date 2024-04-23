using StudiGO.Core.DTOs;

namespace StudiGO.Models
{
    public class TripViewModel
    {
        public string PlannedDuration { get; set; }
        public string ActualDuration { get; set; }
        public string PlannedDepartureTime { get; set; }
        public string PlannedArrivalTime { get; set; }
        public int Transfers { get; set; }

        public static TripViewModel FromDto(Trip trip)
        {
            TripViewModel tripViewModel = new TripViewModel
            {
                PlannedDuration = TimeSpan.FromMinutes(trip.PlannedDurationInMinutes).ToString("hh\\:mm"),
                ActualDuration = TimeSpan.FromMinutes(trip.ActualDurationInMinutes).ToString("hh\\:mm"),
                PlannedDepartureTime = trip.PlannedDepartureDateTime.ToString("HH:mm"),
                PlannedArrivalTime = trip.PlannedArrivalDateTime.ToString("HH:mm"),
                Transfers = trip.Transfers,
            };
                
            return tripViewModel;
        }
    }
}
