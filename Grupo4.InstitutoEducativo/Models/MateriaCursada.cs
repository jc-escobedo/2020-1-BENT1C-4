using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public class MateriaCursada
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La propiedad Nombre es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de un Nombre es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de un Nombre es de 2 caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo admite sólo caracteres alfabéticos")]
        public string Nombre { get; set; }

        [ForeignKey("Materia")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int MateriaId { get; set; }

        public Materia Materia { get; set; }

        [Display(Name = "Profesor")]
        [ForeignKey("Profesor")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int ProfesorId { get; set; }

        public Profesor Profesor { get; set; }

        public List<MateriaCursadaAlumno> Alumnos { get; set; }

        //[NotMapped]
        //public string qAlumnos
        //{
            
        //}

    }
}
