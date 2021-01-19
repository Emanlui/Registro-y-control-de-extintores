using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        public List<string> Obtener_Centros_Extintores(List<ExtintorModel> lista_Extintores)
        {
            List<string> centros_obtenidos = new List<string>();

            //Conexion a la base
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            string centros_ids = "";
            bool first = true;
            //creacion de consulta mysql para buscar los extintores en la base de datos
            foreach (ExtintorModel extintor in lista_Extintores)
            {
                if (first)
                {
                    centros_ids = extintor.Id_centro.ToString();
                    first = false;
                }
                else
                {
                    centros_ids += "," + extintor.Id_centro.ToString();
                }
            }

            string Query_Data = "SELECT * FROM centro_de_trabajo WHERE id IN (" + centros_ids+")";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;
            Debug.WriteLine("QUERY: "+Query_Data);
            //abrir la conexion y realizar la consulta
            mainconn.con.Open();
            reader = cmd.ExecuteReader();

            //lista donde guardaremos los datos de los extintores
            List<ExtintorModel> Data_Obtained = new List<ExtintorModel>();

            if (!reader.HasRows)
            {
                //No hay datos
            }
            else
            {
                //obtener los datos del sql y guardarlos en la lista temporal
                while (reader.Read())
                {
                    //se agrega el nombre a los centros encontrados
                    centros_obtenidos.Add(reader["Nombre"].ToString());                                  
                }
            }
            mainconn.con.Close();
            return centros_obtenidos;
        }

        public string Obtener_Centro_Extintor(int id_extintor)
        {
            List<string> centros_obtenidos = new List<string>();

            //Conexion a la base
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            

            string Query_Data = "SELECT * FROM centro_de_trabajo WHERE id ="+ id_extintor.ToString();
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;
            Debug.WriteLine("QUERY: " + Query_Data);
            //abrir la conexion y realizar la consulta
            mainconn.con.Open();
            reader = cmd.ExecuteReader();

            string centro_obtenido = "";

            //lista donde guardaremos los datos de los extintores
            List<ExtintorModel> Data_Obtained = new List<ExtintorModel>();

            if (!reader.HasRows)
            {
                //No hay datos
            }
            else
            {
                reader.Read();
                centro_obtenido = reader["nombre"].ToString();
            }
            mainconn.con.Close();
            return centro_obtenido;
        }
    }
}
