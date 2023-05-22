using System;
using System.Collections.Generic;

namespace sistema_cft.Models;

public partial class EstudianteAsignatura
{
    public int EstudianteId { get; set; }

    public int AsignaturaId { get; set; }

    public int Id { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public virtual Asignatura Asignatura { get; set; } = null!;

    public virtual Estudiante Estudiante { get; set; } = null!;
}
