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
    public Product Product { get; set; }
}

public class Origin
{
    public string Name { get; set; }
    public DateTime PlannedDateTime { get; set; }
    public DateTime ActualDateTime { get; set; }
    public string PlannedTrack { get; set; }
    public string ActualTrack { get; set; }
}

public class Destination
{
    public string Name { get; set; }
    public DateTime PlannedDateTime { get; set; }
    public DateTime ActualDateTime { get; set; }
    public string PlannedTrack { get; set; }
    public string ActualTrack { get; set; }
}

public class Product
{
    public List<List<Note>> Notes { get; set; }
    public List<TransferMessage> TransferMessages { get; set; }
}

public class Note
{
    public string Value { get; set; }
}

public class TransferMessage
{
    public string Message { get; set; }
}
