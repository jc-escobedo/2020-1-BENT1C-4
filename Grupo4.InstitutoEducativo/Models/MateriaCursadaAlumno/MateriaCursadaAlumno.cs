using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo4.InstitutoEducativo.Models
{
    public class MateriaCursadaAlumno
    {
        public int Id { get; set; }

        [ForeignKey("MateriaCursada")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int MateriaCursadaId { get; set; }

        public MateriaCursada MateriaCursada { get; set; }

        [ForeignKey("Alumno")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int AlumnoId { get; set; }

        public Alumno Alumno { get; set; }
    }
}
