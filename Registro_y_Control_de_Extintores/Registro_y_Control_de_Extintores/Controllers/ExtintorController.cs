using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Registro_y_control_de_extintores.Models;

namespace Registro_y_control_de_extintores.Controllers
{
    public class ExtintorController : Controller
    {
        CrudExtintor crud = new CrudExtintor();
        ExtintorModel ExtintorModel = new ExtintorModel();

        public string Index()
        {
            return "Este es el index de la pagina.";
        }

        public IActionResult Eliminar()
        {
            return View();
        }

        public IActionResult Crear()
        {
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql
            string Query_Data = "SELECT * FROM centro_de_trabajo";
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

            ViewBag.ListaCentros = Data_Obtained;

            //cerrar la conexion con la base
            mainconn.con.Close();

            return View();
        }

        [HttpPost]
        public IActionResult CrearRequest(int id_centro, 
                                            string activo, 
                                            string tipo,
                                            string ubicacion_geografica,
                                            string ubicacion,
                                            string agente_extintor,
                                            int capacidad,
                                            string ultima_prueba_hidrostatica,
                                            string proxima_prueba_hidrostatica,
                                            string proximo_mantenimiento,
                                            int presion,
                                            int rotulacion,
                                            int acceso_a_extintor,
                                            int condicion_extintor,
                                            int seguro_y_marchamo,
                                            int collarin,
                                            int condicion_manguera,
                                            int condicion_boquilla)
        {

            if (!String.IsNullOrEmpty(activo))
            {
                //TODO: Save the data in database  

                ExtintorModel.Id_centro = id_centro;
                ExtintorModel.Activo = activo;
                ExtintorModel.Tipo = tipo;
                ExtintorModel.Ubicacion_geografica = ubicacion_geografica;
                ExtintorModel.Ubicacion = ubicacion;
                ExtintorModel.Agente_extintor = agente_extintor;
                ExtintorModel.Capacidad = capacidad;
                ExtintorModel.Ultima_prueba_hidrostatica = ultima_prueba_hidrostatica;
                ExtintorModel.Proxima_prueba_hidrostatica = proxima_prueba_hidrostatica;
                ExtintorModel.Proximo_mantenimiento = proximo_mantenimiento;
                ExtintorModel.Presion = presion;
                ExtintorModel.Rotulacion = rotulacion;
                ExtintorModel.Acceso_a_extintor = acceso_a_extintor;
                ExtintorModel.Condicion_extintor = condicion_extintor;
                ExtintorModel.Seguro_y_marchamo = seguro_y_marchamo;
                ExtintorModel.Collarin = collarin;
                ExtintorModel.Condicion_manguera = condicion_manguera;
                ExtintorModel.Condicion_boquilla = condicion_boquilla;
                crud.extintor = ExtintorModel;
                crud.Crear_Extintor();
                return RedirectToAction("index", "Home");
            }


            else
                return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public IActionResult EliminarRequest(string activo)
        {
            if (!String.IsNullOrEmpty(activo))
            {
                //TODO: Save the data in database  
                ExtintorModel.Activo = activo;
                crud.extintor = ExtintorModel;
                crud.Eliminar_Extintor();
                return RedirectToAction("index", "Home");
            }
            else
                return RedirectToAction("index", "Home");
        }

    }
}