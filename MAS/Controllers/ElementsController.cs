using MAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers;
[Route("api/elements")]
[ApiController]
public class ElementsController : ControllerBase
{
    private readonly IElementService _elementService;

    public ElementsController(IElementService elementService)
    {
        _elementService = elementService;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetElements()
    {
        return Ok(await _elementService.GetElements());
    }

    [HttpGet("{IdElement}")]
    public async Task<IActionResult> GetElement(int idElement)
    {
        return Ok(await _elementService.GetElement(idElement));
    }
}