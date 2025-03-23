using Microsoft.EntityFrameworkCore;
using PruebaDualTech.Data;
using PruebaDualTech.Dtos.Response;
using PruebaDualTech.Entities;

namespace PruebaDualTech.Services
{
    public class ClienteServices
    {
        private readonly DataContext _context;

        public ClienteServices(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> getAllClientesAsync()
        {
            var Clientes =  await _context.Clientes.ToListAsync();

            ResponseDto response = new ResponseDto();
            try
            {

                response.success = true;
                response.message = "";
                response.errors = new string[0];
                response.Data = Clientes;

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

        public async Task<ResponseDto> GetClienteByIdAsync(long id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);
            ResponseDto response = new ResponseDto();

            try
            {
                if(Cliente is null)
                {
                    response.success = false;
                    response.message = "Cliente no encontrado";
                    response.errors = new string[0];
                    response.Data = Cliente;
                }
                else
                {
                    response.success = true;
                    response.message = "Cliente Encontrado";
                    response.errors = new string[0];
                    response.Data = Cliente;
                }
                return response;
            }
            catch(Exception ex)
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
        }

        public async Task<ResponseDto> createCliente(Cliente cliente)
        {
            var response = new ResponseDto();
            try
            {
                cliente.ClienteId = 0;
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                response.success = true;
                response.message = "Cliente Creado Exitosamente";
                response.errors = new string[0];
                response.Data = cliente;
                return response;
            }catch(Exception ex)
            {
                response.success = false;
                response.message = "ha ocurrido un error";
                response.errors = new string[] { ex.Message };
                return response;
            }
        }

        public async Task<ResponseDto> updateCliente(Cliente cliente)
        {
            var response = new ResponseDto();
            try
            {
                var dbCliente = await _context.Clientes.FindAsync(cliente.ClienteId);
                
                if(dbCliente is null)
                {
                    response.success = false;
                    response.message = "Cliente no encontrado";
                    response.errors = new string[0];
                    response.Data = dbCliente;
                    return response;
                }

                dbCliente.Nombre = cliente.Nombre;
                dbCliente.Identidad = cliente.Identidad;
                

                await _context.SaveChangesAsync();

                response.success = true;
                response.message = "Cliente Actualizado Exitosamente";
                response.errors = new string[0];
                response.Data = dbCliente;
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
