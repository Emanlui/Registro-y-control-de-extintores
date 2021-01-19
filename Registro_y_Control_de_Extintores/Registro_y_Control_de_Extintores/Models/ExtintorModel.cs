using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
    public class ExtintorModel
    {
        [Required]
        public int Id_centro { get; set; }

        [Required]
        public string Centro { get; set; }

        public string Activo { get; set; }

        public string Tipo { get; set; }

        public string Ubicacion_geografica { get; set; }

        public string Ubicacion { get; set; }

        public string Agente_extintor { get; set; }

        public int Capacidad { get; set; }

        public string Ultima_prueba_hidrostatica { get; set; }

        public string Proxima_prueba_hidrostatica { get; set; }

        public string Proximo_mantenimiento { get; set; }

        public int Presion { get; set; }

        public int Rotulacion { get; set; }

        public int Acceso_a_extintor { get; set; }

        public int Condicion_extintor { get; set; }

        public int Seguro_y_marchamo { get; set; }

        public int Collarin { get; set; }

        public int Condicion_manguera { get; set; }

        public int Condicion_boquilla { get; set; }

        public int Habilitado { get; set; }

        public List<ExtintorModel> ExtintoresInfo { get; set; }
    }
}