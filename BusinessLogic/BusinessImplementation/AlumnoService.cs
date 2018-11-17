using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.AccessImplementation;
using DataAccess.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessImplementation
{
    public class AlumnoService: GenericService<Alumno, AlumnoDto>, IAlumnoService 
    {
        public AlumnoService(IAlumnoRepository repository, IMapper mapper) : base(repository, mapper) {}

    }
}
