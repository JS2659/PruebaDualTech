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
        public required Orden Orden { get; set; }
        public required Producto Producto { get; set; }

    }
}