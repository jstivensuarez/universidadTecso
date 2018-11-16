using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos
{
    public class InscripcionDto
    {
        public int Id { get; set; }

        public int IdAlumno { get; set; }

        public int IdCurso { get; set; }

        public DateTime FechaInscripcion { get; set; }

        public int Estado { get; set; }
    }
}
