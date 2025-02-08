using System;
using System.Collections.Generic;

namespace Salud360.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int? Edad { get; set; }

    public string? Género { get; set; }

    public double? Altura { get; set; }

    public double? Peso { get; set; }

    public string? Objetivo { get; set; }

    public int? PlanNutricionalId { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual PlanNutricional? PlanNutricional { get; set; }

    public virtual ICollection<PlanNutricional> PlanNutricionals { get; set; } = new List<PlanNutricional>();

    public virtual ICollection<ProgresoUsuario> ProgresoUsuarios { get; set; } = new List<ProgresoUsuario>();

    public virtual ICollection<VerificacionUsuario> VerificacionUsuarios { get; set; } = new List<VerificacionUsuario>();
}
