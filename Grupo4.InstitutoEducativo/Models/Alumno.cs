using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Alumno : Usuario
    {
        [ForeignKey("Carrera")]
        [Display(Name = "Carrera")]
        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }

        public List<MateriaCursadaAlumno> MateriasCursadas { get; set; }

    }
}
