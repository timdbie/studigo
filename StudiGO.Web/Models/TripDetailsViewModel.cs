using StudiGO.Core.DTOs;

namespace StudiGO.Models
{
    public class TripDetailsViewModel
    {
        public List<Leg> Legs { get; set; }
        
        public class Leg
        {
            public Endpoint Origin { get; set; }
            public Endpoint Destination { get; set; }
            public List<string>? TransferMessages { get; set; }
            public List<string> Notes { get; set; }
        }

        public class Endpoint
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public int Delay { get; set; }
            public string Track { get; set; }
        }

        public static TripDetailsViewModel FromDto(SingleTripDto trip)
        {

            TripDetailsViewModel tripDetailsViewModel = new TripDetailsViewModel
            {
                Legs = new List<Leg>()
            };

            foreach (var leg in trip.Legs)
            {
                Leg newLeg = new Leg
                {
                    Origin = new Endpoint
                    {
                        Name = leg.Origin.Name,
                        Time = leg.Origin.PlannedDateTime.ToString("HH:mm"),
                        Delay = leg.Origin.ActualDateTime.Subtract(leg.Origin.PlannedDateTime).Minutes,
                        Track = leg.Origin.PlannedTrack
                    },
                    Destination = new Endpoint
                    {
                        Name = leg.Destination.Name,
                        Time = leg.Destination.PlannedDateTime.ToString("HH:mm"),
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
                
                if (leg.Product.Notes != null)
                {
                    newLeg.Notes = new List<string>();
                    foreach (var noteList in leg.Product.Notes)
                    {
                        foreach (var note in noteList)
                        {
                            newLeg.Notes.Add(note.Value);
                        }
                    }
                }

                tripDetailsViewModel.Legs.Add(newLeg);
            }

            return tripDetailsViewModel;
        }
    }
}