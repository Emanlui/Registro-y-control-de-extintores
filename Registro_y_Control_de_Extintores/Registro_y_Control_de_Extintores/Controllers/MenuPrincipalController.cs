using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registro_y_control_de_extintores.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlConnector;
using System.Diagnostics;

namespace Registro_y_control_de_extintores.Controllers
{
    public class MenuPrincipalController : Controller
    {
        public ActionResult MostrarMenuPrincipal()
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
                    details.Capacidad = (int) reader["capacidad"];
                    details.Ultima_prueba_hidrostatica = reader["ultima_prueba_hidrostatica"].ToString();
                    details.Proxima_prueba_hidrostatica = reader["proxima_prueba_hidrostatica"].ToString();
                    details.Proximo_mantenimiento = reader["proximo_mantenimiento"].ToString();
                    details.Presion = (int)(ulong) reader["presion"];
                    details.Rotulacion = (int) reader["rotulacion"];
                    details.Acceso_a_extintor = (int)(ulong) reader["acceso_a_extintor"];
                    details.Condicion_extintor = (int)(ulong)reader["condicion_extintor"];
                    details.Seguro_y_marchamo = (int)(ulong) reader["seguro_y_marchamo"];
                    details.Collarin = (int)(ulong) reader["collarin"];
                    details.Condicion_manguera = (int)(ulong) reader["condicion_manguera"];
                    details.Condicion_boquilla = (int)(ulong) reader["condicion_boquilla"];

                    Data_Obtained.Add(details);
                } 
            }

            //copiar la lista temporal a la lista del modelo
            ViewBag.ListaExtintores = Data_Obtained;

            //despliega el menu principal del manejo de usuarios
            return View("MenuPrincipal");
        }

    }
}