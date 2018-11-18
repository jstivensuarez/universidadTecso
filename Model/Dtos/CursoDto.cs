using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos
{
    public class CursoDto
    {
        public int CursoId { get; set; }

        public string Asignatura { get; set; }

        public int CupoMaximo { get; set; }

        public int DocenteId { get; set; }

        public List<InscripcionDto> Inscripciones { get; } = new List<InscripcionDto>();
    }
}
