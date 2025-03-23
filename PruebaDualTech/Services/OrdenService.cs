using Azure;
using PruebaDualTech.Data;
using PruebaDualTech.Dtos.DetalleOrden;
using PruebaDualTech.Dtos.Orden;
using PruebaDualTech.Dtos.Response;
using PruebaDualTech.Entities;

namespace PruebaDualTech.Services
{
    public class OrdenService
    {
        private readonly DataContext _context;

        public OrdenService(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> createOrden(CreateOrdenDto orden)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                
                Orden OrdenCompleta = new Orden
                {
                    OrdenId = 0,
                    ClienteId = 0,
                    Impuesto = 0,
                    Subtotal = 0,
                    Total = 0,
                    DetallesOrden = new List<DetalleOrden> { }
                };

                var cliente = await _context.Clientes.FindAsync(orden.ClienteId);


                if (cliente is null)
                {
                    response.success = false;
                    response.message = "Cliente no encontrado";
                    response.errors = new string[0];
                    response.Data = null;

                    return response;
                }

                OrdenCompleta.ClienteId = cliente.ClienteId;

                _context.Ordenes.Add(OrdenCompleta);
                await _context.SaveChangesAsync();


                foreach (CreateDetalleOrdenDto detalle in orden.Detalle)
                {

                    var producto = await _context.Productos.FindAsync(detalle.ProductoId);

                    if (producto is null)
                    {
                        response.success = false;
                        response.message = string.Format("El producto con id {0} no existe en la base de datos", detalle.ProductoId);
                        response.errors = new string[0];
                        response.Data = null;

                        return response;
                    }

                    if (producto.Existencia < detalle.Cantidad)
                    {
                        response.success = false;
                        response.message = string.Format("No hay suficientes existencias del producto {0}", producto.Nombre);
                        response.errors = new string[0];
                        response.Data = null;

                        return response;
                    }

                    DetalleOrden detalleCompleto = new DetalleOrden
                    {
                        OrdenId = OrdenCompleta.OrdenId,
                        DetalleOrdenId = 0,
                        ProductoId = producto.ProductoId,
                    };

                    detalleCompleto.Impuesto = (producto.Precio * detalle.Cantidad) * 0.15m;
                    detalleCompleto.Subtotal = producto.Precio * detalle.Cantidad;
                    detalleCompleto.Total = detalleCompleto.Impuesto + detalleCompleto.Subtotal;
                    detalleCompleto.Cantidad = detalle.Cantidad;

                    OrdenCompleta.Impuesto += detalleCompleto.Impuesto;
                    OrdenCompleta.Subtotal += detalleCompleto.Subtotal;
                    OrdenCompleta.Total += detalleCompleto.Total;


                    OrdenCompleta.DetallesOrden.Add(detalleCompleto);

                }

                _context.Ordenes.Update(OrdenCompleta);
                await _context.SaveChangesAsync();

                response.success = true;
                response.message = "Orden Guardada Con Exito";
                response.errors = new string[0];
                response.Data = OrdenCompleta;

                return response;
            }catch(Exception ex) 
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
            
        }
    }
}
