using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La propiedad Nombre es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de un Nombre es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de un Nombre es de 2 caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo admite sólo caracteres alfabéticos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad Descripcion es requerida")]
        [MinLength(2, ErrorMessage = "La longitud mínima de un Nombre es de 2 caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo admite sólo caracteres alfabéticos")]
        public string Descripcion { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CupoMaximo { get; set; }

        public List<ProfesorMateria> Profesores { get; set; }

        public List<CarreraMateria> Carreras { get; set; }
    }
}
