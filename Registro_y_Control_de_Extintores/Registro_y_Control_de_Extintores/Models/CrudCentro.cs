using MySqlConnector;
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

        public List<CentroDeTrabajoModel> ObtenerDatosDeCentros() {

            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql
            string Query_Data = "SELECT * FROM centro_de_trabajo where habilitado = 1";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //ejecucion de la consulta y obtencion de datos
            mainconn.con.Open();
            reader = cmd.ExecuteReader();
            List<CentroDeTrabajoModel> Data_Obtained = new List<CentroDeTrabajoModel>();

            if (!reader.HasRows)
            {
                //error
            }

            DataTable dt = new DataTable();
            //obtener los datos del sql y guardarlos en la lista temporal
            while (reader.Read())
            {
                var details = new CentroDeTrabajoModel();
                details.Id = (int)reader["id"];
                details.Nombre = reader["nombre"].ToString();
                Data_Obtained.Add(details);
            }

            //cerrar la conexion con la base
            mainconn.con.Close();

            return Data_Obtained;
        }
    }
}
