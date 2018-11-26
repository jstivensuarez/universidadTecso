using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        readonly UniversidadContext context;

        public CursoRepository(UniversidadContext context) : base(context) {
            this.context = context;
        }

        public List<Curso> GetAllwithInclude()
        {
            return context.Cursos.Include(c => c.Docente).ToList();
        }
    }
}
