using AutoMapper;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MapperManager: Profile
    {
        public MapperManager()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Alumno, AlumnoDto>();
            CreateMap<AlumnoDto, Alumno>();

            CreateMap<Curso, CursoDto>();
            CreateMap<CursoDto, Curso>();

            CreateMap<Docente, DocenteDto>();
            CreateMap<DocenteDto, Docente>();

            CreateMap<Inscripcion, InscripcionDto>();
            CreateMap<InscripcionDto, Inscripcion>();
        }
    }
}
