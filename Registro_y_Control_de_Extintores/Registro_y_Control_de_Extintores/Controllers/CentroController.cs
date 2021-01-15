using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Registro_y_control_de_extintores.Models;

namespace Registro_y_control_de_extintores.Controllers
{
    public class CentroController : Controller
    {
        
        CrudCentro crud = new CrudCentro();
        CentroDeTrabajoModel ctm = new CentroDeTrabajoModel();

        public string prueba()
        {
            return "Hola, esta es una prueba" + User.Identity.Name;
        }
        public IActionResult Administrar()
        {
            List<CentroDeTrabajoModel> centrosDeTrabajo = crud.ObtenerDatosDeCentros();
            ViewBag.ListaCentros = centrosDeTrabajo;
            return View();
        }

        [HttpPost]
        public IActionResult CrearRequest(string nombre)
        {

            if (!String.IsNullOrEmpty(nombre))
            {
                //TODO: Save the data in database  

                ctm.Nombre = nombre;
                crud.centro = ctm;
                crud.Crear_Centro();

                return RedirectToAction("index", "Home");
            }

            
            else
                return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public IActionResult EliminarRequest(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                //TODO: Save the data in database  
                ctm.Nombre = nombre;
                crud.centro = ctm;
                crud.Eliminar_Centro();
                return RedirectToAction("index", "Home");
            }
            else
                return RedirectToAction("index", "Home");
        }

    }
}
