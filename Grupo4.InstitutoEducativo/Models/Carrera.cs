using System;
using System.Collections.Generic;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Carrera
    {
        public List<Materia> Materias { get; set; }

        public Carrera()
        {
            Materias = new List<Materia>();
        }
    }
}
