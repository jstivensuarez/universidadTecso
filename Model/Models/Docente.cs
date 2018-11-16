using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    [Table("docentes")]
    public class Docente
    {
        [Key]
        [Column("id_docente")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("primer_apellido")]
        public string PrimerApellido { get; set; }

        [Column("segundo_apellido")]
        public string SegundoApellido { get; set; }
    }
}
