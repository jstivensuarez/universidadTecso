using AutoMapper;
using BusinessLogic.exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.util;
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
    public class CursoService : ICursoService
    {
        readonly ICursoRepository repository;
        IInscripcionRepository inscripcionRepository;
        readonly IMapper mapper;

        public CursoService(ICursoRepository repository, IInscripcionRepository inscripcionRepository, IMapper mapper)
        {
            this.repository = repository;
            this.inscripcionRepository = inscripcionRepository;
            this.mapper = mapper;
        }

        public void Add(CursoDto entity)
        {
            try
            {
                repository.Add(mapper.Map<Curso>(entity));
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

        public void Delete(CursoDto entity)
        {
            try
            {
                repository.Delete(mapper.Map<Curso>(entity));
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

        public void Edit(CursoDto entity)
        {
            try
            {
                repository.Edit(mapper.Map<Curso>(entity));
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

        public IQueryable<CursoDto> Find(Expression<Func<Curso, bool>> predicate)
        {
            try
            {
                return mapper.Map<IQueryable<CursoDto>>(repository.Find(predicate));
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

        public CursoDto Find(int id)
        {
            try
            {
                return mapper.Map<CursoDto>(repository.Find(id));
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

        public List<CursoDto> GetAll()
        {
            try
            {
                var courses = repository.GetAll();
                return mapper.Map<List<CursoDto>>(courses);
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

        public List<CursoDto> GetAllWithInclude()
        {
            try
            {
                var courses = repository.GetAllwithInclude();
                return mapper.Map<List<CursoDto>>(courses);
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

        public List<CursoDto> GetAllEnabledCursosByAlumno(int alumnoId)
        {
            try
            {
                var courses = repository.GetAll();
                var coursesDto = mapper.Map<List<CursoDto>>(courses);
                var inscriptions = inscripcionRepository.GetIncripcionesByAlumno(alumnoId)
                    .Where(i => i.Estado != (int)Estados.NoRegular && i.Estado != (int)Estados.Regular);
                foreach (var item in inscriptions)
                {
                    if (item.Estado == (int)Estados.Inscripto)
                        coursesDto.Find(c => c.CursoId == item.CursoId).EstaInscrita = true;
                }
                return coursesDto;
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

        public List<CursoDto> GetAllCursosByAlumno(int alumnoId)
        {
            try
            {
                var courses = mapper.Map<List<CursoDto>>(repository.GetAllwithInclude());
                var coursesDto = new List<CursoDto>();
                var inscriptions = inscripcionRepository.GetIncripcionesByAlumno(alumnoId);
                var inscriptionsCompleted = inscriptions.Where(i => i.Estado != (int)Estados.Inscripto
                && i.Estado != (int)Estados.Regular).ToList();
                foreach (var item in courses)
                {
                    var inscription = inscriptions.FirstOrDefault(i => i.CursoId == item.CursoId);
                    if (inscription == null)
                    {
                        var courseDto = mapper.Map<CursoDto>(item);
                        coursesDto.Add(courseDto);
                    }
                }
                foreach (var item in inscriptionsCompleted)
                {      
                    if (coursesDto.Find(c => c.CursoId == item.CursoId) == null)
                    {
                        var courseDto = courses.Find(i => i.CursoId == item.CursoId);
                        courseDto.Estado = item.Estado;
                        coursesDto.Add(courseDto);
                    }
                }
                return coursesDto.OrderBy(c => c.Estado).ToList();
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
    }
}
