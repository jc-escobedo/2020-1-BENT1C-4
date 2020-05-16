using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo4.InstitutoEducativo.Models
{
    public class MateriaCursadaAlumno
    {
        public int Id { get; set; }

        [ForeignKey("MateriaCursada")]
        public int MateriaCursadaId { get; set; }
        public MateriaCursada MateriaCursada { get; set; }

        [ForeignKey("Alumno")]
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
    }
}
