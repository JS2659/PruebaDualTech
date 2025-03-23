using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDualTech.Dtos.Producto
{
    public class ProductoDto
    {
        public long ProductoId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public long Existencia { get; set; }
    }
}
