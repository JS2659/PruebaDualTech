namespace PruebaDualTech.Dtos.DetalleOrden
{
    public class CreateDetalleOrdenDto
    {
        public decimal Cantidad { get; set; }
        public required long ProductoId { get; set; }
    }
}
