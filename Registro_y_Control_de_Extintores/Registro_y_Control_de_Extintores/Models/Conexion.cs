<<<<<<< HEAD
﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
=======
﻿using MySqlConnector;
using System;
using System.Collections.Generic;
>>>>>>> 3-iteracin1-semana1gestin_de_usuarios
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
<<<<<<< HEAD
    class Conexion
    {
        public MySqlConnection con;
        public CentroDeTrabajoModel centro { set; get; }
=======
    public class Conexion
    {
        public MySqlConnection con;
>>>>>>> 3-iteracin1-semana1gestin_de_usuarios

        public Conexion()
        {
            string host = "localhost";
            string db = "registro_y_control_de_extintores";
            string user = "root";
<<<<<<< HEAD
            string conexion_a_la_base = "server="+host+";userid="+user+";password=;database="+ db;
            con = new MySqlConnection(conexion_a_la_base);


        }
    }

   
=======
            string conexion_a_la_base = "server=" + host + ";userid=" + user + ";password=;database=" + db;
            con = new MySqlConnection(conexion_a_la_base);
        }
    }
>>>>>>> 3-iteracin1-semana1gestin_de_usuarios
}
