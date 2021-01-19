﻿using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Registro_y_control_de_extintores.Models;
using System;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Registro_y_control_de_extintores.Controllers
{
    public class Inicio_de_sesionController : Controller
    {

        public IActionResult Inicio_de_sesion()
        {
            return View();
        }

        public IActionResult Cerrar_sesion()
        {
            HttpContext.Session.Remove("SessionUser");
            HttpContext.Session.Clear();
            return RedirectToAction("Inicio_de_sesion", "Inicio_de_sesion");
        }

        [HttpGet]
        public IActionResult OlvidarContrasena()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CambiarContrasena(string username, string password)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            string tipo = null;

            if (username.Contains("@"))
            {
                tipo = "correo";
            }
            else
            {
                tipo = "cedula";
            }

            using (MySqlCommand cmd = new MySqlCommand())
            {
              
                cmd.CommandText = "UPDATE usuario SET password = @pwd WHERE " + tipo + " = @uname";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@uname", MySqlDbType.VarChar).Value = username;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }

            return RedirectToAction("Inicio_de_sesion", "Inicio_de_sesion");
        }

        [HttpGet]
        public IActionResult Autenticar_usuario(string uname, string psw)
        {
            Conexion con = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            string correo_bd = null;
            int cedula_db = 0;
            string password_bd = null;
            string tipo = null;
            int administrador_bd = 0;

            if (uname.Contains("@"))
            {
                tipo = "correo";
            }
            else
            {
                tipo = "cedula";
            }
            
            try
            {
                cmd = new MySqlCommand();
                cmd.CommandText = "select * from usuario where " + tipo + " = @correo;";
                cmd.Connection = con.con;
                cmd.Parameters.Add("@correo", MySqlDbType.VarChar).Value = uname;
                cmd.CommandType = CommandType.Text;

                con.con.Open();
                reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    TempData["msg"] = "Error de autenticación";
                    return RedirectToAction("Inicio_de_sesion", "Inicio_de_sesion");
                }

                while (reader.Read())
                {
                    if (tipo == "cedula")
                    {
                        cedula_db = reader.GetInt32("cedula");
                        password_bd = reader.GetString("password");
                        administrador_bd = reader.GetInt16("administrador");
                    }
                    else
                    {
                        correo_bd = reader.GetString("correo");
                        password_bd = reader.GetString("password");
                        administrador_bd = reader.GetInt16("administrador");
                    }
                }

                Console.WriteLine("correo:" + correo_bd + " contrasena:" + password_bd);

                if (correo_bd == uname && password_bd == psw || cedula_db.ToString() == uname && password_bd == psw)
                {
                    //HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userInfo));
                    //var user = JsonConvert.DeserializeObject<Inicio_de_sesion>(HttpContext.Session.GetString("SessionUser"));
                    if (administrador_bd > 0)
                    {
                        HttpContext.Session.SetString("SessionUser", uname);
                        return RedirectToAction("MostrarMenuPrincipal", "MenuPrincipal");
                    }
                    else {
                        HttpContext.Session.SetString("SessionUser", uname);
                        return RedirectToAction("MostrarMenuPrincipal", "MenuPrincipal");
                    }
                }
                else
                {
                    TempData["msg"] = "Error de autenticación";
                    return RedirectToAction("Inicio_de_sesion", "Inicio_de_sesion");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error de autenticación";
                return RedirectToAction("Inicio_de_sesion", "Inicio_de_sesion");
            }
            finally
            {
                if (reader != null) reader.Close();
                if (con.con != null) con.con.Close();
            }
        }
    }
}
