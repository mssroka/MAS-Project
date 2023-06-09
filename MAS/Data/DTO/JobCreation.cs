namespace MAS.Data.DTO;

public class JobCreation
{
    public int idCar { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public string Note { get; set; }
    public int idServiceman { get; set; }
    public int finalCost { get; set; }
    public OverviewJobCreation? OverviewJobCreation { get; set; }
    public PaintingJobCreation? PaintingJobCreation { get; set; }
    public ReplacementJobCreation? ReplacementJobCreation { get; set; }
}