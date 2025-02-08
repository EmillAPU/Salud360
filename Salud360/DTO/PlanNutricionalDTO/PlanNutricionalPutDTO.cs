using Salud360.Models;

namespace Salud360.DTO.PlanNutricionalDTO
{
    public class PlanNutricionalPutDTO
    {
        public int PlanNutricionalId { get; set; }

        public int UsuarioId { get; set; }

        public int CaloríasDiarias { get; set; }

        public string? Macronutrientes { get; set; }

        public DateTime? FechaCreación { get; set; }

        public DateTime? FechaActualización { get; set; }
    }
}
