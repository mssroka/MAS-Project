namespace MAS.Data.DTO;

public class ReplacementJobCreation
{
    public int DifficultyLevel { get; set; }
    public DateTime ServiceDate { get; set; }
    public List<int> PartsIds { get; set; } = new List<int>();
}