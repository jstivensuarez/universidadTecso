using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;

namespace UniversidadTecso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CursosController : ControllerBase
    {
        readonly ICursoService cursoService;

        public CursosController(ICursoService cursoService)
        {
            this.cursoService = cursoService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(cursoService.GetAllWithInclude());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        [Route("[action]/{alumnoId}")]
        public IActionResult GetEnabled(int alumnoId)
        {
            try
            {
                 return Ok(cursoService.GetAllEnabledCursosByAlumno(alumnoId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("[action]/{alumnoId}")]
        public IActionResult GetCopletedWithNotStarted(int alumnoId)
        {
            try
            {
                return Ok(cursoService.GetAllCursosByAlumno(alumnoId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
