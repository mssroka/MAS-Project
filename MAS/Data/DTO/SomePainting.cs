using MAS.Data;

namespace MAS.DTO;

public class SomePainting
{
    public string Name { get; set; }
    public int DifficultyLevel { get; set; }
    public DateTime ServiceDate { get; set; }
    public string Colour { get; set; }
    public List<Element> Elements { get; set; } = new List<Element>();
}