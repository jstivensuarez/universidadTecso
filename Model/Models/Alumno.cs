using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    [Table("alumnos")]
    public class Alumno
    {
        [Key]
        [Column("id_alumno")]
        public int AlumnoId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("primer_apellido")]
        public string PrimerApellido { get; set; }

        [Column("segundo_apellido")]
        public string SegundoApellido { get; set; }

        [Column("legajo")]
        public string Legajo { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }


        public List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
