using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class DocenteRepository : GenericRepository<Docente>, IDocenteRepository
    {
        public DocenteRepository(UniversidadContext context) : base(context) { }
    }
}
