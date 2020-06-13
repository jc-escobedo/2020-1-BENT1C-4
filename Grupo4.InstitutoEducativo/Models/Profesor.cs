using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo4.InstitutoEducativo.Models
{
    public class Profesor : Usuario
    {
        [Display(Name = "Materias aplicables")]
        public List<ProfesorMateria> MateriasAplicables { get; set; }

    }
}
