using MAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers;
[Route("api/parts")]
[ApiController]
public class PartsController : ControllerBase
{
    private readonly IPartService _partService;

    public PartsController(IPartService partService)
    {
        _partService = partService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetParts()
    {
        return Ok(await _partService.GetParts());
    }

    [HttpGet]
    [Route("{IdPart}")]
    public async Task<IActionResult> GetPart(int IdPart)
    {
        return Ok(await _partService.GetPart(IdPart));
    }
}