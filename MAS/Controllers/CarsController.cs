using MAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;
    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _carService.GetCars();
        return Ok(cars);
    }

    [HttpGet("{IdCar}")]
    public async Task<IActionResult> GetCar(int IdCar)
    {
        return Ok(await _carService.GetCar(IdCar));
    }
}