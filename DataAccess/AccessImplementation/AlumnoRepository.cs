using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class AlumnoRepository : GenericRepository<Alumno>, IAlumnoRepository
    {
        readonly UniversidadContext context;

        public AlumnoRepository(UniversidadContext context) :base(context)
        {
            this.context = context;
        }

        public  List<Alumno> GetAllWithInclude()
        {
            return context.Alumnos.Include(a => a.Inscripciones).ToList();
        }
    }
}
