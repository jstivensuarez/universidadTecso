using DataAccess.exceptions;
using DataAccess.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class InscripcionRepository : GenericRepository<Inscripcion>, IInscripcionRepository
    {
        UniversidadContext context;

        public InscripcionRepository(UniversidadContext context) : base(context)
        {
            this.context = context;
        }

        public List<Inscripcion> GetIncripcionesByAlumno(int alumnoId)
        {
            try
            {
                List<Inscripcion> query = _context.Set<Inscripcion>().
                        Where(i => i.AlumnoId == alumnoId ).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al obetener las entidades", ex);
            }
        }

        public List<Inscripcion> GetIncripcionesByCourse(int courseId)
        {
            try
            {
                List<Inscripcion> query = _context.Set<Inscripcion>().
                        Where(i => i.CursoId == courseId).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al obetener las entidades", ex);
            }
        }
    }
}
