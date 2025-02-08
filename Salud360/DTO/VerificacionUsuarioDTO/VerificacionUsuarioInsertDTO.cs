namespace Salud360.DTO.VerificacionUsuarioDTO
{
    public class VerificacionUsuarioInsertDTO
    {
        public int UsuarioId { get; set; }

        public int CodigoVerificacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string? Estatus { get; set; }
    }
}
