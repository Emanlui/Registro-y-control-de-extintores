using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Registro_y_control_de_extintores.Models;
using System;
using System.Data;

namespace Registro_y_control_de_extintores.Controllers
{
    public class Inicio_de_sesionController : Controller
    {

        public IActionResult Inicio_de_sesion()
        {
            return View();
        }

        [HttpGet]
        public string Autenticar_usuario(string uname, string psw)
        {
            Conexion con = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            string correo_bd = null;
            string password_bd = null;
            try
            {

                string sql = "select * from usuario where usuario.correo = @correo";

                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.Add("@correo", MySqlDbType.VarChar).Value = uname;
                cmd.CommandType = CommandType.Text;
                con.con.Open();
                reader = cmd.ExecuteReader();

                if (reader == null)
                {

                    return "No se encontro el usuario.";
                }

                while (reader.Read())
                {

                    correo_bd = reader.GetString("correo");
                    password_bd = reader.GetString("password");
                }

                if (correo_bd == uname && password_bd == psw)
                {

                    return "Bienvenido " + uname;
                }
                else
                {

                    return "Credenciales incorrectas.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (con.con != null) con.con.Close();
            }
        }
    }
}
