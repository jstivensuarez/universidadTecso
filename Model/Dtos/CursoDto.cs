using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos
{
    public class CursoDto
    {
        public int Id { get; set; }

        public string Asignatura { get; set; }

        public int CupoMaximo { get; set; }

        public int IdDocente { get; set; }
    }
}
