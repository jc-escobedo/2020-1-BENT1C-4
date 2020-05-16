using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public class ProfesorMateria
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Profesor")]
        [ForeignKey("Profesor")]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        [Display(Name = "Materia")]
        [ForeignKey("Materia")]
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}
