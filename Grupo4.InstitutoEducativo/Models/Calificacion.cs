using System;
namespace Grupo4.InstitutoEducativo.Models
{
    public class Calificacion
    {
        public TipoCalificacion TipoCalificacion { get; set; }
        public string Relativa { get; set; }
        public float Absoluta { get; set; }
        public Calificacion()
        {
        }
    }
}
