using MAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers;
[Route("api/servicemen")]
[ApiController]
public class ServicemanController : ControllerBase
{
    private readonly IServicemanService _servicemanService;

    public ServicemanController(IServicemanService servicemanService)
    {
        _servicemanService = servicemanService;
    }

    [HttpGet("{skill}")]
    public async Task<IActionResult> GetServicemenBySkill(int skill)
    {
        return Ok(await _servicemanService.GetServicemenBySkill(skill));
    }
}