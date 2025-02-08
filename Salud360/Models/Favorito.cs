using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class Favorito
{
    public int FavoritosId { get; set; }

    public int UsuarioId { get; set; }

    public int? EjercicioId { get; set; }

    public int? ProductoAlimenticioId { get; set; }

    public DateTime? FechaAgregado { get; set; }

    public virtual Ejercicio? Ejercicio { get; set; }

    public virtual ProductoAlimenticio? ProductoAlimenticio { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
