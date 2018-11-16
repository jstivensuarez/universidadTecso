using DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(UniversidadContext context) : base(context) { }

    }
}
