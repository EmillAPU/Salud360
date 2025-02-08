using Salud360.Models;

namespace Salud360.DTO.VerificacionUsuarioDTO
{
    public class VerificacionUsuarioGetDTO
    {
        public int VerificacionId { get; set; }

        public int UsuarioId { get; set; }

        public int CodigoVerificacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string? Estatus { get; set; }
    }
}
