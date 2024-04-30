using StudiGO.Core.DTOs;

namespace StudiGO.Models
{
    public class TripViewModel
    {
        public string Ref { get; set; }
        public string Context { get; set; }
        public string PlannedDuration { get; set; }
        public string ActualDuration { get; set; }
        public bool DurationLongerThanPlanned { get; set; }
        public string DepartureTime { get; set; }
        public double DepartureDelay { get; set; }
        public string ArrivalTime { get; set; }
        public double ArrivalDelay { get; set; }
        public int Transfers { get; set; }

        public static TripViewModel FromDto(Trip trip)
        {
            TripViewModel tripViewModel = new TripViewModel
            {
                Context = Uri.EscapeDataString(trip.CtxRecon),
                PlannedDuration = TimeSpan.FromMinutes(trip.PlannedDurationInMinutes).ToString("h\\:mm"),
                ActualDuration = TimeSpan.FromMinutes(trip.ActualDurationInMinutes).ToString("h\\:mm"),
                DurationLongerThanPlanned = trip.ActualDurationInMinutes > trip.PlannedDurationInMinutes,
                DepartureTime = trip.Legs[0].Origin.PlannedDateTime.ToString("HH:mm"),
                DepartureDelay = trip.Legs[0].Origin.ActualDateTime == DateTime.MinValue ? 0 : (trip.Legs[0].Origin.ActualDateTime - trip.Legs[0].Origin.PlannedDateTime).TotalMinutes,
                ArrivalTime = trip.Legs[^1].Destination.PlannedDateTime.ToString("HH:mm"),
                ArrivalDelay = trip.Legs[^1].Destination.ActualDateTime == DateTime.MinValue ? 0 : (trip.Legs[^1].Destination.ActualDateTime - trip.Legs[^1].Destination.PlannedDateTime).TotalMinutes,
                Transfers = trip.Transfers,
            };
                
            return tripViewModel;
        }
    }
}
