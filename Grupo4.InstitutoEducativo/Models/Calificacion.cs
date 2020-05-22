using System;
using System.ComponentModel.DataAnnotations;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Calificacion
    {
        public TipoCalificacion TipoCalificacion { get; set; }

        [RegularExpression("Insuficiente|Suficiente|Bueno|Excelente|Sobresaliente", ErrorMessage = "La calificacion relativa debe ser Insuficiente,Suficiente,Bueno,Excelente o Sobresaliente")]
        public string Relativa { get; set; }

        [Required(ErrorMessage = "La propiedad Absoluta es requerida")]
        [RegularExpression("[1-10]", ErrorMessage = "El número de Absoluta deben estar entre los valores 1-10")]
        public float Absoluta { get; set; }

        public Calificacion()
        {
        }
    }
}
