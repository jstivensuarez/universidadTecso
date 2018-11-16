using DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class AlumnoRepository : GenericRepository<Alumno>, IAlumnoRepository
    {
        public AlumnoRepository(UniversidadContext context) :base(context){}
    }
}
