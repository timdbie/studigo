using StudiGO.Core.DTOs;

namespace StudiGO.Models
{
    public class TripDetailsViewModel
    {
        public List<Leg> Legs { get; set; }
        
        public class Leg
        {
            public Origin Origin { get; set; }
            public Destination Destination { get; set; }
            public List<string> TransferMessages { get; set; }
        }

        public class Origin
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public int Delay { get; set; }
            public string Track { get; set; }
        }

        public class Destination
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public int Delay { get; set; }
            public string Track { get; set; }
        }

        public static TripDetailsViewModel FromDto(TripsDto tripsDto, int tripId)
        {
            var trip = tripsDto.trips[tripId];

            TripDetailsViewModel tripDetailsViewModel = new TripDetailsViewModel
            {
                Legs = new List<Leg>()
            };

            foreach (var leg in trip.Legs)
            {
                Leg newLeg = new Leg
                {
                    Origin = new Origin
                    {
                        Name = leg.Origin.Name,
                        Time = leg.Origin.PlannedDateTime.ToString("yyyy-MM-dd HH:mm"),
                        Delay = leg.Origin.ActualDateTime.Subtract(leg.Origin.PlannedDateTime).Minutes,
                        Track = leg.Origin.PlannedTrack
                    },
                    Destination = new Destination
                    {
                        Name = leg.Destination.Name,
                        Time = leg.Destination.PlannedDateTime.ToString("yyyy-MM-dd HH:mm"),
                        Delay = leg.Destination.ActualDateTime.Subtract(leg.Destination.PlannedDateTime).Minutes,
                        Track = leg.Destination.PlannedTrack
                    }
                };
                
                if (leg.TransferMessages != null)
                {
                    newLeg.TransferMessages = new List<string>();
                    foreach (var transferMessage in leg.TransferMessages)
                    {
                        newLeg.TransferMessages.Add(transferMessage.Message);
                    }
                }

                tripDetailsViewModel.Legs.Add(newLeg);
            }

            return tripDetailsViewModel;
        }
    }
}
