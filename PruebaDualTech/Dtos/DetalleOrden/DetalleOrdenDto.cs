using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDualTech.Dtos.DetalleOrden
{
    public class DetalleOrdenDto
    {
        public long DetalleOrdenId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public required long ProductoId { get; set; }
    }
}
