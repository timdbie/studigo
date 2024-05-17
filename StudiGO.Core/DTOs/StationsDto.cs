namespace StudiGO.Core.DTOs;

public class StationsDto
{
    public List<Payload> payload { get; set; }
}

public class Payload
{
    public Namen Namen { get; set; }
}

public class Namen
{
    public string Lang { get; set; }
    public string Middel { get; set; }
    public string Kort { get; set; }
}
