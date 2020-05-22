using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo4.InstitutoEducativo.Models
{
    public class CarreraMateria
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Carrera")]
        [ForeignKey("Carrera")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }

        [Display(Name = "Materia")]
        [ForeignKey("Materia")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int MateriaId { get; set; }

        public Materia Materia { get; set; }
    }
}
