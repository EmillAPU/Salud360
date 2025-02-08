namespace Salud360.DTO.FavoritoDTO
{
    public class FavoritoGetDTO
    {
        public int FavoritosId { get; set; }

        public int UsuarioId { get; set; }

        public int? EjercicioId { get; set; }

        public int? ProductoAlimenticioId { get; set; }

        public DateTime? FechaAgregado { get; set; }
    }
}
