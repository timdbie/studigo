namespace StudiGO.Core.DTOs;

public class StationsDto
{
    public List<Station> Payload { get; set; }
}

public class Station
{
    public Namen Namen { get; set; }
}

public class Namen
{
    public string Lang { get; set; }
    public string Middel { get; set; }
    public string Kort { get; set; }
}
