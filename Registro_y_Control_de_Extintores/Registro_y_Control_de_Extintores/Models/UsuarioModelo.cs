using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
    class usuario
    {
        public int Id { get; set; }

        public int id_centro { get; set; }

        public int cedula { get; set; }

        public string correo { get; set; }

        public string clave { get; set; }

        public int administrador { get; set; }

        public usuario()
        {
        }

        public usuario(int id, int id_centro, int cedula, string correo, string clave, int administrador) {
            this.Id = id;
            this.id_centro = id_centro;
            this.cedula = cedula;
            this.correo = correo;
            this.clave = clave;
            this.administrador = administrador;
        }

    }
}