using MAS.DTO;
using MAS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MAS.Services.Repositories;

public class CarService : ICarService
{
    private readonly MasContext _dbContext;
    
    public CarService(MasContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<SomeCar> GetCar(int IdCar)
    {
        return await _dbContext.Cars.Where(car => car.IdCar.Equals(IdCar))
            .Select(car => new SomeCar()
            {
                Plates = car.Plates,
                Brand = car.Brand,
                Model = car.Model
            }).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<SomeCar>> GetCars()
    {
        return await _dbContext.Cars
            .Select(car => new SomeCar()
            {
                IdCar = car.IdCar,
                Plates = car.Plates,
                Brand = car.Brand,
                Model = car.Model,
                IdPerson = car.IdPerson,
                FirstName = car.IdPersonNavigation.IdPersonNavigation.FirstName,
                LastName = car.IdPersonNavigation.IdPersonNavigation.LastName
            }).ToListAsync();
    }
}