using System.ComponentModel.DataAnnotations;

namespace Salud360.DTO.EjercicioDTO
{
    public class EjercicioPutDTO
    {
        public int EjercicioId { get; set; }

        public string Nombre { get; set; } = null!;

        public required string Categoría { get; set; }

        public int Duración { get; set; }

        public required string NivelIntensidad { get; set; }

        public required int CaloríasQuemadas { get; set; }
    }
}
