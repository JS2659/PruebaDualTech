using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDualTech.Data;
using PruebaDualTech.Dtos.Response;
using PruebaDualTech.Entities;
using PruebaDualTech.Services;

namespace PruebaDualTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServices _clienteServices;

        public ClienteController(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           ResponseDto response = new ResponseDto();

           response = await _clienteServices.getAllClientesAsync();
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
           
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(long id)
        {
            ResponseDto response = new ResponseDto();
            response = await _clienteServices.GetClienteByIdAsync(id);
            if (!response.success && response.message == "Cliente no encontrado") {
                return NotFound(response);
            }else if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCliente(Cliente cliente)
        {
            ResponseDto response = new ResponseDto();
            response = await _clienteServices.createCliente(cliente);

            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente(Cliente cliente)
        {
            ResponseDto response = new ResponseDto();
            response = await _clienteServices.updateCliente(cliente);
            if (!response.success && response.message == "Cliente no encontrado")
            {
                return NotFound(response);
            }
            else if (response.success)
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
