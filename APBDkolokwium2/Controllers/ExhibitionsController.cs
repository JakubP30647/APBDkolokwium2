using apbd_kolowium2.Exceptions;
using APBDkolokwium2.Services;
using grF.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBDkolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExhibitionsController : ControllerBase
{
    private readonly IExhibitionService _service;
    
    public ExhibitionsController(IExhibitionService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostNewExhibition([FromBody] ExhibitionForPost exhibitionForPost)
    {
        try
        {
           await _service.PostExhibition(exhibitionForPost);
            
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
}