using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos
{
    public class InscripcionDto
    {
        public int InscripcionId { get; set; }

        public int AlumnoId { get; set; }

        public int CursoId { get; set; }

        public DateTime FechaInscripcion { get; set; }

        public int Estado { get; set; }

        public CursoDto Alumno { get; set; }

        public CursoDto Curso { get; set; }
    }
}
