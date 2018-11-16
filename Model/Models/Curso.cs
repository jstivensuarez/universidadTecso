using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    [Table("cursos")]
    public class Curso
    {
        [Key]
        [Column("id_curso")]
        public int Id { get; set; }

        [Column("asignatura")]
        public string Asignatura { get; set; }

        [Column("cupo_maximo")]
        public int CupoMaximo { get; set; }

        [Column("id_docente")]
        public int IdDocente { get; set; }


        public List<Inscripcion> Inscripciones { get; set; }
    }
}
