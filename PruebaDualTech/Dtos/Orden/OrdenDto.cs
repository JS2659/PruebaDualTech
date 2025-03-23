using PruebaDualTech.Dtos.DetalleOrden;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDualTech.Dtos.Orden
{
    public class OrdenDto
    {
        public long OrdenId { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public long ClienteId { get; set; }
        public List<DetalleOrdenDto> Detalle {  get; set; } = new List<DetalleOrdenDto>();

    }
}
