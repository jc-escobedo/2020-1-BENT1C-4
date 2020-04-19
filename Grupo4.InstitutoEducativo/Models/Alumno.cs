using System;
using System.Collections.Generic;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public Carrera Carrera { get; set; }
        public List<MateriaCursada> MateriasCursadas { get; set; }
        
        public Alumno(string Nombre, string Apellido, Carrera Carrera)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Carrera = Carrera;
            MateriasCursadas = new List<MateriaCursada>();
        }
    }
}
