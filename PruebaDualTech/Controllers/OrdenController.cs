using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaDualTech.Dtos.Orden;
using PruebaDualTech.Dtos.Response;
using PruebaDualTech.Entities;
using PruebaDualTech.Services;

namespace PruebaDualTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly OrdenService _ordenService;

        public OrdenController(OrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpPost("create")]

        public async Task<IActionResult> CreateOrden(CreateOrdenDto orden)
        {
            ResponseDto response = new ResponseDto();

            response = await _ordenService.createOrden(orden);

            if(!response.success && response.message == "Cliente no encontrado")
            {
              return  NotFound(response);
            }
            
            if(!response.success && response.message.Contains("El producto con id"))
            {
                return NotFound(response);
            } 
            if(!response.success && response.message.Contains("No hay suficientes"))
            {
               return BadRequest(response);
            }
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }         
        }
    }
}
