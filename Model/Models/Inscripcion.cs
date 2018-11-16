using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    [Table("inscripciones")]
    public class Inscripcion
    {
        [Key]
        [Column("id_inscripcion")]
        public int Id { get; set; }

        [Column("id_alumno")]
        public int IdAlumno { get; set; }

        [Column("id_curso")]
        public int IdCurso { get; set; }

        [Column("fecha_inscripcion")]
        public DateTime FechaInscripcion { get; set; }

        [Column("estado")]
        public int Estado { get; set; }

        public Alumno Alumno { get; set; }

        public Curso Curso { get; set; }
    }
}
