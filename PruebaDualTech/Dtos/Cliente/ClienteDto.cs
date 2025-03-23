namespace PruebaDualTech.Dtos.Cliente
{
    public class ClienteDto
    {
        public long ClienteId { get; set; }
        public required string Nombre { get; set; }
        public long Identidad { get; set; }
    }
}
