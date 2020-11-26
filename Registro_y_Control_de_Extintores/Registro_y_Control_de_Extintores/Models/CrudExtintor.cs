using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
    }
}