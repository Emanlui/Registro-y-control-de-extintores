using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
    class CrudCentro
    {
        //Crear Usuario
        public CentroDeTrabajoModel centro { set; get; }

        public void Crear_Centro()
        {

            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Insert into centro_de_trabajo (nombre) VALUES(@nombre)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = centro.Nombre;
                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        public void Eliminar_Centro()
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE centro_de_trabajo SET habilitado = 0 WHERE nombre = @nombre";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = centro.Nombre;

                cmd.ExecuteNonQuery();
                conexion.con.Close();

            }
        }
    }
}
