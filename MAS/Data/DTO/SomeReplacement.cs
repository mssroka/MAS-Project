using MAS.Data;

namespace MAS.DTO;

public class SomeReplacement
{
    public string Name { get; set; }
    public int DifficultyLevel { get; set; }
    public DateTime ServiceDate { get; set; }
    public List<Part> Parts { get; set; } = new List<Part>();
}