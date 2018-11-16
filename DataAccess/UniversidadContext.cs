using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UniversidadContext: DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Docente> Docentes { get; set; }

        public DbSet<Inscripcion> Inscripciones { get; set; }
        public UniversidadContext(DbContextOptions<UniversidadContext>  options): base(options){}
    }
}
