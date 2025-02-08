using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class PlanNutricional
{
    public int PlanNutricionalId { get; set; }

    public int UsuarioId { get; set; }

    public int CaloríasDiarias { get; set; }

    public string? Macronutrientes { get; set; }

    public DateTime? FechaCreación { get; set; }

    public DateTime? FechaActualización { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<ProductoAlimenticio> ProductoAlimenticios { get; set; } = new List<ProductoAlimenticio>();
}
