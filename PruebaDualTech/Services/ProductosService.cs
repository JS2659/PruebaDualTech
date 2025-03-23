using Microsoft.EntityFrameworkCore;
using PruebaDualTech.Data;
using PruebaDualTech.Dtos.Response;
using PruebaDualTech.Entities;

namespace PruebaDualTech.Services
{
    public class ProductosService
    {

        private readonly DataContext _context;

        public ProductosService(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> getAllProductosAsync()
        {
            var Productos = await _context.Productos.ToListAsync();

            ResponseDto response = new ResponseDto();
            try
            {

                response.success = true;
                response.message = "";
                response.errors = new string[0];
                response.Data = Productos;

                return response;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
        }

        public async Task<ResponseDto> GetProductoByIdAsync(long id)
        {
            var Producto = await _context.Productos.FindAsync(id);
            ResponseDto response = new ResponseDto();

            try
            {
                if (Producto is null)
                {
                    response.success = false;
                    response.message = "Producto no encontrado";
                    response.errors = new string[0];
                    response.Data = Producto;
                }
                else
                {
                    response.success = true;
                    response.message = "Producto Encontrado";
                    response.errors = new string[0];
                    response.Data = Producto;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
        }

        public async Task<ResponseDto> createProducto(Producto producto)
        {
            var response = new ResponseDto();
            try
            {
                producto.ProductoId = 0;
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                response.success = true;
                response.message = "Producto Creado Exitosamente";
                response.errors = new string[0];
                response.Data = producto;
                return response;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
        }

        public async Task<ResponseDto> updateProducto(Producto producto)
        {
            var response = new ResponseDto();
            try
            {
                var dbProducto = await _context.Productos.FindAsync(producto.ProductoId);

                if (dbProducto is null)
                {
                    response.success = false;
                    response.message = "Producto no encontrado";
                    response.errors = new string[0];
                    response.Data = dbProducto;
                    return response;
                }

                dbProducto.Nombre = producto.Nombre;
                dbProducto.Descripcion = producto.Descripcion;
                dbProducto.Precio = producto.Precio;
                dbProducto.Existencia = producto.Existencia;

                await _context.SaveChangesAsync();

                response.success = true;
                response.message = "Producto Actualizado Exitosamente";
                response.errors = new string[0];
                response.Data = dbProducto;
                return response;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
        }

    }
}
