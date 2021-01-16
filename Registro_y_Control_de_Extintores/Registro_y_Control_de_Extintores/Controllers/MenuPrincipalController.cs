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
            CrudExtintor info_Extintores = new CrudExtintor();
            List<ExtintorModel> lista_extintores = info_Extintores.Obtener_Datos_Extintores();

            CrudCentro info_Centros = new CrudCentro();
            List<string> lista_centros = info_Centros.Obtener_Centros_Extintores(lista_extintores);

            ViewBag.ListaExtintores = lista_extintores;
            ViewBag.ListaCentrosExtintores = lista_centros;
            //despliega el menu principal del manejo de usuarios
            return View("MenuPrincipal");
        }

    }
}