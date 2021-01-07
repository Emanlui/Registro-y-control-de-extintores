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

        public IActionResult Administrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearRequest(string nombre)
        {

            if (!String.IsNullOrEmpty(nombre))
            {
                //TODO: Save the data in database  
                
                if(crud.Crear_Centro(nombre) == 0) return RedirectToAction("index", "Home");
                else
                {
                    return RedirectToAction("administrar", "Centro");
                }
                
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
                crud.Eliminar_Centro(nombre);
                return RedirectToAction("index", "Home");
            }
            else
                return RedirectToAction("index", "Home");
        }

    }
}
