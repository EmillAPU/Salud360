using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class VerificacionUsuario
{
    public int VerificacionId { get; set; }

    public int UsuarioId { get; set; }

    public int CodigoVerificacion { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public string? Estatus { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
