using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class ProductoAlimenticio
{
    public int ProductoAlimenticioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Categoría { get; set; }

    public int? CaloríasPorPorción { get; set; }

    public string? Macronutrientes { get; set; }

    public string? TamañoPorción { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<PlanNutricional> PlanNutricionals { get; set; } = new List<PlanNutricional>();
}
