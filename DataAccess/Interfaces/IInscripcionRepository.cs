using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IInscripcionRepository: IGenericRepository<Inscripcion>
    {
        List<Inscripcion> GetIncripcionesByAlumno(int alumnoId);

        List<Inscripcion> GetIncripcionesByCourse(int courseId);
    }
}
