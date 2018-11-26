using DataAccess.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IAlumnoService: IGenericService<Alumno, AlumnoDto>
    {
        List<AlumnoDto> GetAllWithInclude();

        string GetLegajo(AlumnoDto alumno);

        List<AlumnoDto> GetByCourseId(int courseId);
    }
}
