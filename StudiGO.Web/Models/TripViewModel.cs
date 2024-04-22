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

        public static List<TripViewModel> FromDto(TripsDto tripsDto)
        {
            List<TripViewModel> tripViewModels = new List<TripViewModel>();

            foreach (var trip in tripsDto.trips)
            {
                TripViewModel tripViewModel = new TripViewModel
                {
                    PlannedDuration = TimeSpan.FromMinutes(trip.PlannedDurationInMinutes).ToString("hh\\:mm"),
                    ActualDuration = TimeSpan.FromMinutes(trip.ActualDurationInMinutes).ToString("hh\\:mm"),
                    PlannedDepartureTime = trip.Legs[0].Origin.PlannedDateTime.ToString("HH:mm"),
                    PlannedArrivalTime = trip.Legs[^1].Destination.PlannedDateTime.ToString("HH:mm"),
                    Transfers = trip.Transfers,
                };
                tripViewModels.Add(tripViewModel);
            }

            return tripViewModels;
        }
    }
}
