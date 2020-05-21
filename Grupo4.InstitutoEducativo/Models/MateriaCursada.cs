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

        [Required]
        public string Nombre { get; set; }

        [ForeignKey("Materia")]
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        [Display(Name = "Profesor")]
        [ForeignKey("Profesor")]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        public List<MateriaCursadaAlumno> Alumnos { get; set; }

        [NotMapped]
        public string qAlumnos
        {
            
        }

    }
}
