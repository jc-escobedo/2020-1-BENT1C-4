using System;
using System.Collections.Generic;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Profesor
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public List<Materia> MateriasAplicables { get; set; }

        public Profesor()
        {
            MateriasAplicables = new List<Materia>();
        }
    }
}
