using PruebaDualTech.Dtos.DetalleOrden;

namespace PruebaDualTech.Dtos.Orden
{
    public class CreateOrdenDto
    {
        public long ClienteId { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public CreateDetalleOrdenDto[] Detalle { get; set; } = new CreateDetalleOrdenDto[0];
    }
}
