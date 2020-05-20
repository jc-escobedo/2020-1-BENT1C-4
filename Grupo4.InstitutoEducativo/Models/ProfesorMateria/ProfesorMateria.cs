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
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int ProfesorId { get; set; }

        public Profesor Profesor { get; set; }

        [Display(Name = "Materia")]
        [ForeignKey("Materia")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int MateriaId { get; set; }

        public Materia Materia { get; set; }
    }
}
