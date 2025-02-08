namespace Salud360.DTO.ProgresoUsuarioDTO
{
    public class ProgresoUsuarioInsertDTO
    {
        public int UsuarioId { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public double? PesoActual { get; set; }

        public string? ProgresoCalórico { get; set; }

        public string? Observaciones { get; set; }
    }
}
