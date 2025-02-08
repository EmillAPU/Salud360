namespace Salud360.DTO.FavoritoDTO
{
    public class FavoritoInsertDTO
    {

        public int UsuarioId { get; set; }

        public int? EjercicioId { get; set; }

        public int? ProductoAlimenticioId { get; set; }

        public DateTime? FechaAgregado { get; set; }
    }
}
