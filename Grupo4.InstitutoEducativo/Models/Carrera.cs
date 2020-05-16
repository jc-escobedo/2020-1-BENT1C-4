using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<Materia> Materias { get; set; }
    }
}
