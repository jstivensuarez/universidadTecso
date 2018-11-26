using AutoMapper;
using BusinessLogic.exceptions;
using BusinessLogic.Interfaces;
using DataAccess.exceptions;
using DataAccess.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.BusinessImplementation
{
    public class AlumnoService : IAlumnoService
    {
        readonly IAlumnoRepository repository;
        readonly IInscripcionRepository inscripcionRepository;
        readonly IMapper mapper;

        public AlumnoService(IAlumnoRepository repository, IInscripcionRepository inscripcionRepository, 
            IMapper mapper)
        {
            this.repository = repository;
            this.inscripcionRepository = inscripcionRepository;
            this.mapper = mapper;
        }

        public void Add(AlumnoDto entity)
        {
            try
            {
                entity.Legajo = GetLegajo(entity);
                repository.Add(mapper.Map<Alumno>(entity));
                repository.Save();
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar agregar el alumno", ex);
            }

        }

        public void Delete(AlumnoDto entity)
        {
            try
            {
                repository.Delete(mapper.Map<Alumno>(entity));
                repository.Save();
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar eliminar el alumno", ex);
            }
        }

        public void Edit(AlumnoDto entity)
        {
            try
            {
                var inscriptions = inscripcionRepository.GetIncripcionesByAlumno(entity.AlumnoId);

                foreach (var item in entity.Cursos)
                {
                    var inscriptionResult = inscriptions.Find(i => i.CursoId == item.CursoId);
                    if (inscriptionResult != null)
                    {
                        if (!item.EstaInscrita && inscriptionResult.Estado == 1)
                        {
                            inscriptionResult.Estado = 0;
                        }
                    }
                    else if (item.EstaInscrita)
                    {

                        InscripcionDto newIncription = new InscripcionDto
                        {
                            AlumnoId = entity.AlumnoId,
                            CursoId = item.CursoId,
                            Estado = 1
                        };
                        inscripcionRepository.Add(mapper.Map<Inscripcion>(newIncription));

                    }
                }

                repository.Edit(mapper.Map<Alumno>(entity));
                repository.Save();
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar editar el alumno", ex);
            }
        }

        public IQueryable<AlumnoDto> Find(Expression<Func<Alumno, bool>> predicate)
        {
            try
            {
                return mapper.Map<IQueryable<AlumnoDto>>(repository.Find(predicate));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar buscar la entidad", ex);
            }
        }

        public AlumnoDto Find(int id)
        {
            try
            {
                return mapper.Map<AlumnoDto>(repository.Find(id));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar buscar la entidad", ex);
            }
        }

        public List<AlumnoDto> GetAll()
        {
            try
            {
                var result = repository.GetAll();
                return mapper.Map<List<AlumnoDto>>(result);
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExceptionBusiness("error al intentar obtener las entidades", ex);
            }
        }

        public List<AlumnoDto> GetAllWithInclude()
        {
            try
            {
                var result = repository.GetAllWithInclude();
                return mapper.Map<List<AlumnoDto>>(result);
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExceptionBusiness("error al intentar obtener las entidades", ex);
            }
        }

        public List<AlumnoDto> GetByCourseId(int courseId)
        {
            try
            {
                var result = (from i in inscripcionRepository.GetIncripcionesByCourse(courseId)
                        join a in repository.GetAll() on i.AlumnoId equals a.AlumnoId
                        where i.Estado == 1
                        select a).ToList();
                return mapper.Map<List<AlumnoDto>>(result);
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExceptionBusiness("error al intentar obtener las entidades", ex);
            }
        }

        public string GetLegajo(AlumnoDto alumno)
        {
            return $"{alumno.Nombre.Substring(0, 1) + alumno.PrimerApellido.Substring(0, 1) + (alumno.SegundoApellido == null ? "" : alumno.SegundoApellido.Substring(0, 1)) + Guid.NewGuid().ToString().Substring(0, 5)}";
        }
    }
}
