using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models {


    public class CentrosTrabajoModelo {
        
        public int id { get; set; }
        public string nombre { get; set; }

        public List<CentrosTrabajoModelo> CentrosTrabajoInfo { get; set; }

    }

}