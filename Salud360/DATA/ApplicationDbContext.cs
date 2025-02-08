using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Salud360.Models;

namespace Salud360.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<PlanNutricional> PlanesNutricionales { get; set; }

    public virtual DbSet<ProductoAlimenticio> ProductosAlimenticios { get; set; }

    public virtual DbSet<ProgresoUsuario> ProgresosUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VerificacionUsuario> VerificacionesUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.EjercicioId).HasName("PK__Ejercici__812226A1077BEBC6");

            entity.ToTable("Ejercicio");

            entity.Property(e => e.EjercicioId).HasColumnName("EjercicioID");
            entity.Property(e => e.CaloríasQuemadas).HasColumnName("Calorías_Quemadas");
            entity.Property(e => e.Categoría)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NivelIntensidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nivel_Intensidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.FavoritosId).HasName("PK__Favorito__2AF78056F60B72F4");

            entity.Property(e => e.FavoritosId).HasColumnName("FavoritosID");
            entity.Property(e => e.EjercicioId).HasColumnName("EjercicioID");
            entity.Property(e => e.FechaAgregado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Agregado");
            entity.Property(e => e.ProductoAlimenticioId).HasColumnName("ProductoAlimenticioID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Ejercicio).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.EjercicioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Favoritos__Ejerc__68487DD7");

            entity.HasOne(d => d.ProductoAlimenticio).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ProductoAlimenticioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Favoritos__Produ__693CA210");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Favoritos__Usuar__6754599E");
        });

        modelBuilder.Entity<PlanNutricional>(entity =>
        {
            entity.HasKey(e => e.PlanNutricionalId).HasName("PK__Plan_Nut__21C37954ABB5EE94");

            entity.ToTable("Plan_Nutricional");

            entity.Property(e => e.PlanNutricionalId).HasColumnName("PlanNutricionalID");
            entity.Property(e => e.CaloríasDiarias).HasColumnName("Calorías_Diarias");
            entity.Property(e => e.FechaActualización)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Actualización");
            entity.Property(e => e.FechaCreación)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creación");
            entity.Property(e => e.Macronutrientes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.PlanNutricionals)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Plan_Nutr__Usuar__5AEE82B9");

            entity.HasMany(d => d.ProductoAlimenticios).WithMany(p => p.PlanNutricionals)
                .UsingEntity<Dictionary<string, object>>(
                    "PlanProducto",
                    r => r.HasOne<ProductoAlimenticio>().WithMany()
                        .HasForeignKey("ProductoAlimenticioId")
                        .HasConstraintName("FK__Plan_Prod__Produ__619B8048"),
                    l => l.HasOne<PlanNutricional>().WithMany()
                        .HasForeignKey("PlanNutricionalId")
                        .HasConstraintName("FK__Plan_Prod__PlanN__60A75C0F"),
                    j =>
                    {
                        j.HasKey("PlanNutricionalId", "ProductoAlimenticioId").HasName("PK__Plan_Pro__4B2D4E86A00BCF3A");
                        j.ToTable("Plan_Producto");
                        j.IndexerProperty<int>("PlanNutricionalId").HasColumnName("PlanNutricionalID");
                        j.IndexerProperty<int>("ProductoAlimenticioId").HasColumnName("ProductoAlimenticioID");
                    });
        });

        modelBuilder.Entity<ProductoAlimenticio>(entity =>
        {
            entity.HasKey(e => e.ProductoAlimenticioId).HasName("PK__Producto__AEE37D2713B14679");

            entity.ToTable("Producto_Alimenticio");

            entity.Property(e => e.ProductoAlimenticioId).HasColumnName("ProductoAlimenticioID");
            entity.Property(e => e.CaloríasPorPorción).HasColumnName("Calorías_Por_Porción");
            entity.Property(e => e.Categoría)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Macronutrientes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TamañoPorción)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tamaño_Porción");
        });

        modelBuilder.Entity<ProgresoUsuario>(entity =>
        {
            entity.HasKey(e => e.ProgresoUsuarioId).HasName("PK__Progreso__B04513A8BC3A20BB");

            entity.ToTable("Progreso_Usuario");

            entity.Property(e => e.ProgresoUsuarioId).HasColumnName("ProgresoUsuarioID");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.PesoActual).HasColumnName("Peso_Actual");
            entity.Property(e => e.ProgresoCalórico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Progreso_Calórico");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ProgresoUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Progreso___Usuar__6D0D32F4");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798207F0A7C");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19757F8377").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Género)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Objetivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PlanNutricionalId).HasColumnName("PlanNutricionalID");

            entity.HasOne(d => d.PlanNutricional).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PlanNutricionalId)
                .HasConstraintName("FK__Usuario__PlanNut__5BE2A6F2");
        });

        modelBuilder.Entity<VerificacionUsuario>(entity =>
        {
            entity.HasKey(e => e.VerificacionId).HasName("PK__Verifica__2D6FA77B4DC6C649");

            entity.ToTable("Verificacion_Usuario");

            entity.Property(e => e.VerificacionId).HasColumnName("VerificacionID");
            entity.Property(e => e.CodigoVerificacion).HasColumnName("Codigo_Verificacion");
            entity.Property(e => e.Estatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.VerificacionUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Verificac__Usuar__70DDC3D8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
