using apbd_kolowium2.Exceptions;
using APBDkolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDkolokwium2.Controllers;

[Route("[controller]")]
[ApiController]
public class GalleriesController : ControllerBase
{
    private readonly IGalleryService _service;
    
    public GalleriesController(IGalleryService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetGaleries(int id)
    {
        try
        {

            var a = await _service.GetGalleries(id);
            return Ok(a);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}