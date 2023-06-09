namespace MAS.Data.DTO;

public class PaintingJobCreation
{
    public int DifficultyLevel { get; set; }
    public DateTime ServiceDate { get; set; }
    public string Colour { get; set; }
    public List<int> ElementsIds { get; set; } = new List<int>();
}