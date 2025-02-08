using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class ProgresoUsuario
{
    public int ProgresoUsuarioId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public double? PesoActual { get; set; }

    public string? ProgresoCalórico { get; set; }

    public string? Observaciones { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
