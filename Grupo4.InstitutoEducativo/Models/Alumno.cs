using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La propiedad Apellido es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de un Apellido es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de un Apellido es de 2 caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo admite sólo caracteres alfabéticos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad Legajo es requerida")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "El número de legajo deben ser 5 numeros")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La propiedad Apellido es requerida")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "El número de legajo deben ser 5 numeros")]
        public int Legajo { get; set; }

      
        [ForeignKey("Carrera")]
        [Display(Name = "Carrera")]
        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }

        public List<MateriaCursadaAlumno> MateriasCursadas { get; set; }

        [NotMapped]
        public string NombreApellidoLegajo
        {
            get
            {
                return $"{Nombre} {Apellido} ({Legajo.ToString()})";
            }

        }

    }
}
