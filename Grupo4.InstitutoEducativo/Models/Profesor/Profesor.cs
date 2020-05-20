using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La propiedad Nombre es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de un Nombre es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de un Nombre es de 2 caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo admite sólo caracteres alfabéticos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad Apellido es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de un Apellido es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de un Apellido es de 2 caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo admite sólo caracteres alfabéticos")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La propiedad Legajo es requerida")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "El número de legajo deben ser 5 numeros")]
        public int Legajo { get; set; }

        public List<ProfesorMateria> MateriasAplicables { get; set; }

        [NotMapped]
        public string NombreApellido
        {
            get {
                return $"{Nombre} {Apellido}";
            }
            
        }
    }
}
