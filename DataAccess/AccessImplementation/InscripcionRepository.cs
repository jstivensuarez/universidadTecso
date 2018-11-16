using DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class InscripcionRepository : GenericRepository<Inscripcion>, IInscripcionRepository
    {
        public InscripcionRepository(UniversidadContext context) : base(context) { }
    }
}
