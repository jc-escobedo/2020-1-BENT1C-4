using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public abstract class Usuario
    {
        private const int LEGAJO_MINIMO = 10000;
        private const int LEGAJO_MAXIMO = 99999;

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
        [Range(LEGAJO_MINIMO, LEGAJO_MAXIMO, ErrorMessage = "El legajo debe ser un entero entre 10000 y 99999")]
        public int Legajo { get; set; }

        [NotMapped]
        [Display(Name = "Nombre y apellido")]
        public string NombreApellido
        {
            get
            {
                return $"{Nombre} {Apellido}";
            }

        }
    }
}
