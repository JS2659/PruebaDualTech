using System.ComponentModel.DataAnnotations.Schema;
namespace PruebaDualTech.Entities
{
    public class Orden()
    {
        
        public long OrdenId { get; set; }
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal Impuesto { get; set; }
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal Subtotal { get; set; }
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal Total { get; set; }
        public required long ClienteId { get; set; }
        public ICollection<DetalleOrden> DetallesOrden { get; set; } 
    }
}
