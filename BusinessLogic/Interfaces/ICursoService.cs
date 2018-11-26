using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ICursoService : IGenericService<Curso, CursoDto>
    {
        List<CursoDto> GetAllEnabledCursosByAlumno(int alumnoId);

        List<CursoDto> GetAllCursosByAlumno(int alumnoId);

        List<CursoDto> GetAllWithInclude();
    }
}
