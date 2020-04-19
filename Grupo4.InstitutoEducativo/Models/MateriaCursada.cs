using System;
using System.Collections.Generic;

namespace Grupo4.InstitutoEducativo.Models
{
    public class MateriaCursada
    {
        public List<Alumno> Alumnos { get; set; }
        public Materia Materia { get; set; }
        public string Nombre { get; set; }

        public MateriaCursada()
        {
            Alumnos = new List<Alumno>();
        }
    }
}
