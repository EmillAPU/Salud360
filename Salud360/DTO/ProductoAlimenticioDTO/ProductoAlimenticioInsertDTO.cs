namespace Salud360.DTO.ProductoAlimenticioDTO
{
    public class ProductoAlimenticioInsertDTO
    {
        public string Nombre { get; set; } = null!;

        public string? Categoría { get; set; }

        public int? CaloríasPorPorción { get; set; }

        public string? Macronutrientes { get; set; }

        public string? TamañoPorción { get; set; }
    }
}
