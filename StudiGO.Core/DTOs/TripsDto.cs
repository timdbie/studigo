namespace StudiGO.Core.DTOs;

public class TripsDto
{
    public List<Trip> Trips { get; set;}
}

public class Trip
{
    public string CtxRecon { get; set; }
    public int PlannedDurationInMinutes { get; set; }
    public int ActualDurationInMinutes { get; set; }
    public int Transfers { get; set; }
    public string Status { get; set; }
    public List<TripLeg> Legs { get; set; }
}

public class TripLeg
{
    public TripEndpoint Origin { get; set; }
    public TripEndpoint Destination { get; set; }
}

public class TripEndpoint
{
    public DateTime PlannedDateTime { get; set; }
    public DateTime ActualDateTime { get; set; }
}