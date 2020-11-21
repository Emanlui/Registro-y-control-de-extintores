using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
    class Conexion
    {
        public MySqlConnection con;
        public CentroDeTrabajoModel centro { set; get; }

        public Conexion()
        {
            string host = "localhost";
            string db = "registro_y_control_de_extintores";
            string user = "root";
            string conexion_a_la_base = "server="+host+";userid="+user+";password=;database="+ db;
            con = new MySqlConnection(conexion_a_la_base);


        }
    }

    class CrudUsuario : Conexion
    {
        //Crear Usuario

        public void Crear_Centro()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Insert into centro_de_trabajo (nombre) VALUES(@nombre)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = centro.Nombre;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void Eliminar_Centro()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Delete from centro_de_trabajo Where nombre=@nombre";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = centro.Nombre;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
