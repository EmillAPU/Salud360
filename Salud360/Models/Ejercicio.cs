using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class Ejercicio
{
    public int EjercicioId { get; set; }

    public string? Nombre { get; set; } = null!;

    public  string? Categoría { get; set; }

    public int? Duración { get; set; }

    public  string? NivelIntensidad { get; set; }

    public  int? CaloríasQuemadas { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();
}
