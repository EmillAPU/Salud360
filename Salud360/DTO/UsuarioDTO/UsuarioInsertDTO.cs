namespace Salud360.DTO.UsuarioDTO
{
    public class UsuarioInsertDTO
    {
        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public int? Edad { get; set; }

        public string? Género { get; set; }

        public double? Altura { get; set; }

        public double? Peso { get; set; }

        public string? Objetivo { get; set; }

        public int? PlanNutricionalId { get; set; }
    }
}
