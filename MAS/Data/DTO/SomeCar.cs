namespace MAS.DTO;

public class SomeCar
{
    public int IdCar { get; set; }
    public string Plates { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int IdPerson { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}