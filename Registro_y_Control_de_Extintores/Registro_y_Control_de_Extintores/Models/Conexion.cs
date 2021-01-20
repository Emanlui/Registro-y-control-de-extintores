using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Registro_y_control_de_extintores.Models
{
    class Conexion
    {
        public MySqlConnection con;
        public CentroDeTrabajoModel centro { set; get; }
        public ExtintorModel extintor { set; get; }

        public Conexion()
        {
            string host = "sql5.freemysqlhosting.net";
            string db = "sql5388133";
            string user = "sql5388133";
            string conexion_a_la_base = "server=" + host + ";userid=" + user + ";password=WZN4QIfz4X;database=" + db;

            con = new MySqlConnection(conexion_a_la_base);
        }
    }
}