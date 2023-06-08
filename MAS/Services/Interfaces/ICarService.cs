using MAS.DTO;

namespace MAS.Services.Interfaces;

public interface ICarService
{
    Task<SomeCar> GetCar(int IdCar);
    Task<IEnumerable<SomeCar>> GetCars();
}