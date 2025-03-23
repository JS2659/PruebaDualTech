using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDualTech.Entities
{
    public class Producto
    {
        public long ProductoId {  get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion {  get; set; } 
        
        [Column(TypeName ="decimal(10,4)")]
        public decimal Precio { get; set; }
        public long Existencia {  get; set; }
    }
}
