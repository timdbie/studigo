using StudiGO.Core.DTOs;

namespace StudiGO.Models
{
    public class TripViewModel
    {
        public string Context { get; set; }
        public string Ref { get; set; }
        public string PlannedDuration { get; set; }
        public string ActualDuration { get; set; }
        public string PlannedDepartureTime { get; set; }
        public string PlannedArrivalTime { get; set; }
        public int Transfers { get; set; }

        public static TripViewModel FromDto(Trip trip)
        {
            TripViewModel tripViewModel = new TripViewModel
            {
                Context = trip.CtxRecon,
                PlannedDuration = TimeSpan.FromMinutes(trip.PlannedDurationInMinutes).ToString("hh\\:mm"),
                ActualDuration = TimeSpan.FromMinutes(trip.ActualDurationInMinutes).ToString("hh\\:mm"),
                PlannedDepartureTime = trip.Legs[0].Origin.PlannedDateTime.ToString("HH:mm"),
                PlannedArrivalTime = trip.Legs[^1].Destination.PlannedDateTime.ToString("HH:mm"),
                Transfers = trip.Transfers,
            };
                
            return tripViewModel;
        }
    }
}
