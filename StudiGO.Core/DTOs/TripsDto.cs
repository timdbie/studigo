namespace StudiGO.Core.DTOs;

public class TripsDto
{
    public List<Trip> Trips { get; set;}
}

public class Trip
{
    public int PlannedDurationInMinutes { get; set; }
    public int ActualDurationInMinutes { get; set; }
    public DateTime PlannedDepartureDateTime { get; set; }
    public DateTime PlannedArrivalDateTime { get; set; }
    public int Transfers { get; set; }
    public string Status { get; set; }
}


