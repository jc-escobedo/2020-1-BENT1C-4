﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Cupo máximo")]
        [Required]
        public int CupoMaximo { get; set; }

        public List<ProfesorMateria> Profesores { get; set; }

        public List<CarreraMateria> Carreras { get; set; }
    }
}
