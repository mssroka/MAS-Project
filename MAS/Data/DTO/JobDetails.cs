using MAS.Data;
using MAS.DTO;

namespace MAS.Data.DTO;

public class JobDetails
{
    public int IdJob { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Cost { get; set; }
    public string Status { get; set; } = null!;
    public string? Note { get; set; }
    public string? Diagnose { get; set; }
    public int IdCar { get; set; }
    public int IdPerson { get; set; }
    public string Plates { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<SomeOverview> Overviews { get; set; } = new List<SomeOverview>();
    public List<SomePainting> Paintings { get; set; } = new List<SomePainting>();
    public List<SomeReplacement> Replacements { get; set; } = new List<SomeReplacement>();
}