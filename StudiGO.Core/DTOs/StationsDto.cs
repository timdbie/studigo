namespace StudiGO.DAL.API.DTOs;

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
    public string IngangsDatum { get; set; }
    public bool HeeftFaciliteiten { get; set; }
    public bool HeeftReisassistentie { get; set; }
    public bool HeeftVertrektijden { get; set; }
    public string Land { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public int Radius { get; set; }
    public int NaderenRadius { get; set; }
    public Namen Namen { get; set; }
    public List<Sporen> Sporen { get; set; }
    public string StationType { get; set; }
}

public class Namen
{
    public string Lang { get; set; }
    public string Middel { get; set; }
    public string Kort { get; set; }
}

public class Sporen
{
    public string SpoorNummer { get; set; }
}