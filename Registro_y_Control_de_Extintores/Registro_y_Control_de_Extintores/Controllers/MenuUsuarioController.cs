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


namespace Registro_y_control_de_extintores.Controllers
{
    public class MenuUsuarioController : Controller
    { 
        public ActionResult MenuPrincipalUsuarios()
        {
            //despliega el menu principal del manejo de usuarios
            return View("MenuUsuario");
        }

        public ActionResult CrearUsuarioMenu(CentroDeTrabajoModel ctm)
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

            if (!reader.HasRows) {
                //error
            }

            DataTable dt = new DataTable();
            //obtener los datos del sql y guardarlos en la lista temporal
            while (reader.Read()) {
                var details = new CentroDeTrabajoModel();
                details.Id = (int)reader["id"];
                details.Nombre = reader["nombre"].ToString();
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

        public ActionResult ModificarUsuarioMenu(CentroDeTrabajoModel ctm)
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

            //copiar la lista temporal a la lista del modelo
            ctm.CentrosTrabajoInfo = Data_Obtained;
            ViewBag.ListaCentros = ctm.CentrosTrabajoInfo;

            //cerrar la conexion con la base
            mainconn.con.Close();
            return View("ModificarUsuario", ctm);
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

            //procesar datos de la consulta
            CentroDeTrabajoModel CentroTrabajo = new CentroDeTrabajoModel();
            if (!reader.HasRows)
            {
                //error-no existe el centro de trabajo
            }
            else
            {
                CentroTrabajo.Id = (int)reader["id"];
                CentroTrabajo.Nombre = reader["nombre"].ToString(); 
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
            Query_Data = "INSERT INTO usuario (id_centro, cedula, correo, password, administrador) VALUES ("+ CentroTrabajo.Id+", " + CedulaUsuario + ", '" +email + "', '" + clave + "', " + IntAdministrador + ")";
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

        public ActionResult ModificarUsuarioExistente(int CedulaUsuario, string NuevaClave, String NuevoCentroTrabajo)
        {
            //Conexion a la base
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql para buscar el centro de trabajo en la base de datos
            string Query_Data = "SELECT * FROM centro_de_trabajo WHERE id = " + "'" + NuevoCentroTrabajo + "'";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //abrir la conexion y realizar la consulta
            mainconn.con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            //procesar datos de la consulta
            CentroDeTrabajoModel CentroTrabajo = new CentroDeTrabajoModel();
            if (!reader.HasRows)
            {
                //error-no existe el centro de trabajo
            }
            else
            {
                CentroTrabajo.Id = (int)reader["id"];
                CentroTrabajo.Nombre = reader["nombre"].ToString();
            }

            //cerrar la conexion con la base
            mainconn.con.Close();

            /*
                Una vez obtenido el centro de trabajo, actualizamos
                los datos del usuario con los datos recibidos
             */

            //creacion de consulta mysql//creacion de consulta mysql
            Query_Data = "UPDATE usuario SET " + "id_centro = " + CentroTrabajo.Id + ", " + "password = '"+NuevaClave +"' WHERE cedula = "+CedulaUsuario;
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //ejecucion de la consulta y obtencion de datos
            mainconn.con.Open();
            cmd.ExecuteNonQuery();

            //cerrar la conexion con la base
            mainconn.con.Close();

            //espacio para logica de modificar usuario existente
            return View("MenuUsuario");
        }

        public ActionResult EliminarUsuarioExistente(int CedulaUsuario)
        {
            //Conexion a la base
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql para buscar el centro de trabajo en la base de datos
            string Query_Data = "UPDATE usuario SET habilitado = 0 WHERE cedula =" +CedulaUsuario;
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //abrir la conexion y realizar la consulta
            mainconn.con.Open();
            cmd.ExecuteNonQuery();

            //cerrar la conexion
            mainconn.con.Close();

            return View("MenuUsuario");
        }
    }

}