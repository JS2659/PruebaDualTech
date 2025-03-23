namespace PruebaDualTech.Dtos.Producto
{
    public class CreateProductoDto
    {
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public long Existencia { get; set; }
    }
}
