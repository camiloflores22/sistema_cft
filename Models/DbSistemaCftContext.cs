using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sistema_cft.Models;

public partial class DbSistemaCftContext : DbContext
{
    public DbSistemaCftContext()
    {
    }

    public DbSistemaCftContext(DbContextOptions<DbSistemaCftContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudianteAsignatura> EstudianteAsignaturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignatura");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiante");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad)
                .HasColumnType("int(11)")
                .HasColumnName("edad");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Rut)
                .HasMaxLength(100)
                .HasColumnName("rut");
        });

        modelBuilder.Entity<EstudianteAsignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiante_asignatura");

            entity.HasIndex(e => e.AsignaturaId, "fk_estudiante_has_asignatura_asignatura1_idx");

            entity.HasIndex(e => e.EstudianteId, "fk_estudiante_has_asignatura_estudiante_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AsignaturaId)
                .HasColumnType("int(11)")
                .HasColumnName("asignatura_id");
            entity.Property(e => e.EstudianteId)
                .HasColumnType("int(11)")
                .HasColumnName("estudiante_id");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

            entity.HasOne(d => d.Asignatura).WithMany(p => p.EstudianteAsignaturas)
                .HasForeignKey(d => d.AsignaturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiante_has_asignatura_asignatura1");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.EstudianteAsignaturas)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiante_has_asignatura_estudiante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
