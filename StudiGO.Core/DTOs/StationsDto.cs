namespace StudiGO.Core.DTOs;

public class StationsDto
{
    public List<Payload> payload { get; set; }
}

public class Payload
{
    public string EVACode { get; set; }
    public string UICCode { get; set; }
    public int CdCode { get; set; }
    public string Code { get; set; }
    public Namen Namen { get; set; }
    public string StationType { get; set; }
}

public class Namen
{
    public string Lang { get; set; }
    public string Middel { get; set; }
    public string Kort { get; set; }
}
