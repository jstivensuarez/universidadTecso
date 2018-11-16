using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos
{
    public class AlumnoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Legajo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
