using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaDualTech.Dtos.Response;
using PruebaDualTech.Entities;
using PruebaDualTech.Services;

namespace PruebaDualTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductosService _productosService;

        public ProductoController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseDto response = new ResponseDto();

            response = await _productosService.getAllProductosAsync();
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
            response = await _productosService.GetProductoByIdAsync(id);
            if (!response.success && response.message == "Producto no encontrado")
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateProducto(Producto producto)
        {
            ResponseDto response = new ResponseDto();
            response = await _productosService.createProducto(producto);

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
        public async Task<IActionResult> UpdateProducto(Producto producto)
        {
            ResponseDto response = new ResponseDto();
            response = await _productosService.updateProducto(producto);
            if (!response.success && response.message == "Producto no encontrado")
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
