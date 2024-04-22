namespace StudiGO.Models;

public class TripViewModel
{
    public string PlannedDuration { get; set; }
    public string ActualDuration { get; set; }
    public string PlannedDepartureTime { get; set; }
    public string PlannedArrivalTime { get; set; }
    public int Transfers { get; set; }
}