using MySqlConnector;

namespace Registro_y_control_de_extintores.Models
{
    class Conexion
    {
        public MySqlConnection con;

        public Conexion()
        {
            string host = "localhost";
            string db = "registro_extintores";
            string user = "root";
            string conexion_a_la_base = "server=" + host + ";userid=" + user + ";password=;database=" + db;
            con = new MySqlConnection(conexion_a_la_base);
        }
    }
}