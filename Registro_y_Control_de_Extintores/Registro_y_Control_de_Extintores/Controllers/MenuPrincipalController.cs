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
using ClosedXML.Excel;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Registro_y_control_de_extintores.Controllers
{
    public class MenuPrincipalController : Controller
    {
        [Authorize(Roles = "Admin,User")]
        public ActionResult MostrarMenuPrincipal()
        {
            CrudExtintor info_Extintores = new CrudExtintor();
            List<ExtintorModel> lista_extintores = info_Extintores.Obtener_Datos_Extintores();

            CrudCentro info_Centros = new CrudCentro();
            List<string> lista_centros = info_Centros.Obtener_Centros_Extintores(lista_extintores);

            ViewBag.ListaExtintores = lista_extintores;
            ViewBag.ListaCentrosExtintores = lista_centros;
            //despliega el menu principal del manejo de usuarios
            return View("MenuPrincipal");
        }

        [Authorize(Roles = "Admin,User")]
        public FileContentResult DescargarDatos()
        {
            CrudExtintor Datos = new CrudExtintor();
            var contenido = Datos.DescargarDatos();
            return File(contenido, "application/vnd.openxmlformats-officedocument-spreadsheetml.sheet", "Datos Extintores.xlsx");
        }

        [HttpGet]
        public ActionResult EditarExtintor(string Activo)
        {
            CrudExtintor EditarExtintor = new CrudExtintor();

            EditarExtintor.Editar_Extintor(Activo);

            return View("MenuPrincipal");
        }

    }
}