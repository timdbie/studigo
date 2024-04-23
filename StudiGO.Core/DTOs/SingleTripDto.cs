namespace StudiGO.Core.DTOs;

public class SingleTripDto
{
    public List<SingleTripLeg> Legs { get; set; } 
}

public class SingleTripLeg
{
    public SingleTripEndPoint Origin { get; set; }
    public SingleTripEndPoint Destination { get; set; }
    public Product Product { get; set; }
    public List<TransferMessage> TransferMessages { get; set; }
}

public class SingleTripEndPoint
{
    public string Name { get; set; }
    public DateTime PlannedDateTime { get; set; }
    public DateTime ActualDateTime { get; set; }
    public string PlannedTrack { get; set; }
    public string ActualTrack { get; set; }
}

public class Product
{
    public List<List<string>> Notes { get; set; }
}

public class TransferMessage
{
    public string Message { get; set; }
}