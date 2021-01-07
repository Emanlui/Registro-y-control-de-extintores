using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores.Models
{
    public class CrudCentro
    {
        public int Crear_Centro(String parametro)
        {
            Conexion conexion = new Conexion();
            try
            {
                conexion.con.Open();
            }
            catch (MySqlException ex)
            {
                int errorcode = ex.Number;
                conexion.con = null;
            }
            if (conexion.con == null) return 1;
            
            else { 
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "Insert into centro_de_trabajo (nombre) VALUES(@nombre)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexion.con;

                    cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = parametro;
                    cmd.ExecuteNonQuery();
                    conexion.con.Close();
                    return 0;
                }
            }
        }

        public int Eliminar_Centro(String parametro)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();

            if (conexion.con == null) return 1;

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE centro_de_trabajo SET habilitado = 0 Where nombre=@nombre";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = parametro;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
                return 0;

            }
        }
    }
}