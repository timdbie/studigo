namespace StudiGO.Core.DTOs;

public class TripsDto
{
    public List<Trip> trips { get; set;}
}

public class Trip
{
    public int plannedDurationInMinutes { get; set; }
    public int actualDurationInMinutes { get; set; }
    public int transfers { get; set; }
    public string status { get; set; }
    public List<Leg> legs { get; set; }
}

public class Leg
{
    public Origin origin { get; set; }
    public Destination destination { get; set; }
}

public class Origin
{
    public DateTime plannedDateTime { get; set; }
    public DateTime actualDateTime { get; set; }
}

public class Destination
{
    public DateTime plannedDateTime { get; set; }
    public DateTime actualDateTime { get; set; }
}
