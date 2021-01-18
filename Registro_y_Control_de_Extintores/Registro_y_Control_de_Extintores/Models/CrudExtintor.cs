using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;


namespace Registro_y_control_de_extintores.Models
{
    class CrudExtintor
    {
        //Crear extintor
        public ExtintorModel extintor { set; get; }

        public void Crear_Extintor()
        {

            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Insert into extintor (id_centro, activo, tipo, ubicacion_geografica, ubicacion, agente_extintor, " +
                                                        "capacidad, ultima_prueba_hidrostatica, proxima_prueba_hidrostatica, " +
                                                        "proximo_mantenimiento, presion, rotulacion, acceso_a_extintor, condicion_extintor, " +
                                                        "seguro_y_marchamo, collarin, condicion_manguera, condicion_boquilla) " +
                                                        "VALUES " +
                                                        "(@id_centro, @activo, @tipo, @ubicacion_geografica, @ubicacion, @agente_extintor, " +
                                                        "@capacidad, @ultima_prueba_hidrostatica, @proxima_prueba_hidrostatica, " +
                                                        "@proximo_mantenimiento, @presion, @rotulacion, @acceso_a_extintor, @condicion_extintor, " +
                                                        "@seguro_y_marchamo, @collarin, @condicion_manguera, @condicion_boquilla) ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@id_centro", MySqlDbType.Int32).Value = extintor.Id_centro;
                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = extintor.Activo;
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = extintor.Tipo;
                cmd.Parameters.Add("@ubicacion_geografica", MySqlDbType.VarChar).Value = extintor.Ubicacion_geografica;
                cmd.Parameters.Add("@ubicacion", MySqlDbType.VarChar).Value = extintor.Ubicacion;
                cmd.Parameters.Add("@agente_extintor", MySqlDbType.VarChar).Value = extintor.Agente_extintor;
                cmd.Parameters.Add("@capacidad", MySqlDbType.Int32).Value = extintor.Capacidad;
                cmd.Parameters.Add("@ultima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Ultima_prueba_hidrostatica;
                cmd.Parameters.Add("@proxima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Proxima_prueba_hidrostatica;
                cmd.Parameters.Add("@proximo_mantenimiento", MySqlDbType.Date).Value = extintor.Proximo_mantenimiento;
                cmd.Parameters.Add("@presion", MySqlDbType.Int32).Value = extintor.Presion;
                cmd.Parameters.Add("@rotulacion", MySqlDbType.Int32).Value = extintor.Rotulacion;
                cmd.Parameters.Add("@acceso_a_extintor", MySqlDbType.Int32).Value = extintor.Acceso_a_extintor;
                cmd.Parameters.Add("@condicion_extintor", MySqlDbType.Int32).Value = extintor.Condicion_extintor;
                cmd.Parameters.Add("@seguro_y_marchamo", MySqlDbType.Int32).Value = extintor.Seguro_y_marchamo;
                cmd.Parameters.Add("@collarin", MySqlDbType.Int32).Value = extintor.Collarin;
                cmd.Parameters.Add("@condicion_manguera", MySqlDbType.Int32).Value = extintor.Condicion_manguera;
                cmd.Parameters.Add("@condicion_boquilla", MySqlDbType.Int32).Value = extintor.Condicion_boquilla;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        public void Eliminar_Extintor()
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Delete from extintor Where activo=@activo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = extintor.Activo;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        public List<ExtintorModel> Obtener_Datos_Extintores()
        {
            //Conexion a la base
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql para buscar los extintores en la base de datos
            string Query_Data = "SELECT * FROM extintor";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

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
                    var details = new ExtintorModel();

                    //datos del extintor que se agregan a la lista del modelo para ser impresos en el menuPrincipal
                    details.Id_centro = (int)reader["id_centro"];

                    details.Activo = reader["activo"].ToString();
                    details.Tipo = reader["tipo"].ToString();
                    details.Ubicacion_geografica = reader["ubicacion_geografica"].ToString();
                    details.Ubicacion = reader["ubicacion"].ToString();
                    details.Agente_extintor = reader["agente_extintor"].ToString();
                    details.Capacidad = (int)reader["capacidad"];
                    string[] date = reader["ultima_prueba_hidrostatica"].ToString().Split(" ");
                    details.Ultima_prueba_hidrostatica = date[0];
                    date = reader["proxima_prueba_hidrostatica"].ToString().Split(" ");
                    details.Proxima_prueba_hidrostatica = date[0];
                    date = reader["proximo_mantenimiento"].ToString().Split(" ");
                    details.Proximo_mantenimiento = date[0];
                    details.Presion = (int)(ulong)reader["presion"];
                    details.Rotulacion = (int)reader["rotulacion"];
                    details.Acceso_a_extintor = (int)(ulong)reader["acceso_a_extintor"];
                    details.Condicion_extintor = (int)(ulong)reader["condicion_extintor"];
                    details.Seguro_y_marchamo = (int)(ulong)reader["seguro_y_marchamo"];
                    details.Collarin = (int)(ulong)reader["collarin"];
                    details.Condicion_manguera = (int)(ulong)reader["condicion_manguera"];
                    details.Condicion_boquilla = (int)(ulong)reader["condicion_boquilla"];

                    Data_Obtained.Add(details);
                }
            }

            return Data_Obtained;

        }
    }
}