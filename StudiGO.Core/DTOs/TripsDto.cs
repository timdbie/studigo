namespace StudiGO.Core.DTOs;

public class TripsDto
{
    public List<Trip> trips { get; set;}
}

public class Trip
{
    public int PlannedDurationInMinutes { get; set; }
    public int ActualDurationInMinutes { get; set; }
    public int Transfers { get; set; }
    public string Status { get; set; }
    public List<Leg> Legs { get; set; }
}

public class Leg
{
    public Origin Origin { get; set; }
    public Destination Destination { get; set; }
}

public class Origin
{
    public DateTime PlannedDateTime { get; set; }
    public DateTime ActualDateTime { get; set; }
}

public class Destination
{
    public DateTime PlannedDateTime { get; set; }
    public DateTime ActualDateTime { get; set; }
}
