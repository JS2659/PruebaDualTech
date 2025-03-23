using PruebaDualTech.Dtos.DetalleOrden;

namespace PruebaDualTech.Dtos.Orden
{
    public class CreateOrdenDto
    {
        public decimal Impuesto { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public long ClienteId { get; set; }
        public DetalleOrdenDto[] Detalle { get; set; } = new DetalleOrdenDto[0];
    }
}
