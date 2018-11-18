using BusinessLogic.Interfaces;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversidadTecso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        readonly IAlumnoService alumnoService;

        public AlumnosController(IAlumnoService alumnoService)
        {
            this.alumnoService = alumnoService;
        }
        // GET: api/Estudiantes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(alumnoService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(alumnoService.Find(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Estudiantes
        [HttpPost]
        public IActionResult Post(AlumnoDto alumno)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                alumnoService.Add(alumno);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlumnoDto alumno)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var entity = alumnoService.Find(id);
                if (entity == null)
                {
                    return NotFound();
                }
                alumnoService.Edit(alumno);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entity = alumnoService.Find(id) ;
                if (entity == null)
                {
                    return NotFound();
                }
                alumnoService.Delete(entity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
