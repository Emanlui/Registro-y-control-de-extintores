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
using MySqlConnector;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Registro_y_control_de_extintores.Controllers
{
    public class MenuUsuarioController : Controller
    { 
        public ActionResult MenuPrincipalUsuarios()
        {
            //despliega el menu principal del manejo de usuarios
            return View("MenuUsuario");
        }

        public ActionResult CrearUsuarioMenu(CentrosTrabajoModelo ctm)
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
            List<CentrosTrabajoModelo> Data_Obtained = new List<CentrosTrabajoModelo>();

            if (!reader.HasRows) {
                //error
            }

            DataTable dt = new DataTable();
            //obtener los datos del sql y guardarlos en la lista temporal
            while (reader.Read()) {
                var details = new CentrosTrabajoModelo();
                details.id = (int)reader["id"];
                details.nombre = reader["nombre"].ToString();
                Data_Obtained.Add(details);
            }

            //copiar la lista temporal a la lista del modelo
            ctm.CentrosTrabajoInfo = Data_Obtained;
            ViewBag.ListaCentros = ctm.CentrosTrabajoInfo;

            //cerrar la conexion con la base
            mainconn.con.Close();
           
            //despliega el menu para crear usuarios
            return View("CrearUsuario", ctm);
        }

        public ActionResult ModificarUsuarioMenu()
        {
            //despliega el menu para modificar usuarios
            return View("ModificarUsuario");
        }

        public ActionResult EliminarUsuarioMenu()
        {
            //despliega el menu para eliminar usuarios
            return View("EliminarUsuario");
        }

        public ActionResult RegistrarUsuarioNuevo(int CedulaUsuario, string clave, string email, Boolean administrador, string CentroTrabajoSeleccionado)
        {
            
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql para buscar el centro de trabajo en la base de datos
            string Query_Data = "SELECT * FROM centro_de_trabajo WHERE id = " +"'" +CentroTrabajoSeleccionado + "'";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //abrir la conexion y realizar la consulta
            mainconn.con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            Console.WriteLine("Valores obtenidos: " + reader["id"].ToString()+" "+reader["nombre"].ToString() + "\n");


            //procesar datos de la consulta
            CentrosTrabajoModelo CentroTrabajo = new CentrosTrabajoModelo();
            if (!reader.HasRows)
            {
                //error-no existe el centro de trabajo
            }
            else
            {
                CentroTrabajo.id = (int)reader["id"];
                CentroTrabajo.nombre = reader["nombre"].ToString(); 
            }

            //cerrar la conexion con la base
            mainconn.con.Close();

            /*
                Una vez obtenido el centro de trabajo, completamos
                los datos restantes para insertar el usuario en la
                base de datos
             */

            //configuracion de mysql
            cmd = null;
            reader = null;

            //convertir el booleano a 1 o 0 para la base de datos
            int IntAdministrador = administrador ? 1 : 0;

            //creacion de consulta mysql//creacion de consulta mysql
            Query_Data = "INSERT INTO usuario (id_centro, cedula, correo, password, administrador) VALUES ("+ CentroTrabajo.id+", " + CedulaUsuario + ", '" +email + "', '" + clave + "', " + IntAdministrador + ")";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //ejecucion de la consulta y obtencion de datos
            mainconn.con.Open();
            cmd.ExecuteNonQuery();

            //cerrar la conexion con la base
            mainconn.con.Close();

            //espacio para logica de registrar usuario nuevo
            return View("MenuUsuario");
        }

        public ActionResult ModificarUsuarioExistente()
        {
            //espacio para logica de modificar usuario existente
            return View("MenuUsuario");
        }

        public ActionResult EliminarUsuarioExistente()
        {
            //espacio para logica de eliminar usuario existente
            return View("MenuUsuario");
        }
    }

}