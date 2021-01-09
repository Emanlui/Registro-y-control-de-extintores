using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
    public class CentroDeTrabajoModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre{ get; set; }
    }
}
