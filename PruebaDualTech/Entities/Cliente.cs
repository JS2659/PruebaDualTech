namespace PruebaDualTech.Entities
{
    public class Cliente
    {
        public long ClienteId { get; set; }
        public required string Nombre { get; set; }
        public long Identidad {  get; set; }
        public ICollection<Orden> Ordenes { get; set; } = null!;
    }
}
