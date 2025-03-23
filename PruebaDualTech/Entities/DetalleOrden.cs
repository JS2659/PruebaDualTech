using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDualTech.Entities
{
    public class DetalleOrden
    {
        public long DetalleOrdenId { get; set; }
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal Cantidad { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal Impuesto { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal Total { get; set; }

        public required long OrdenId { get; set; }
        public required long ProductoId { get; set; }

    }
}