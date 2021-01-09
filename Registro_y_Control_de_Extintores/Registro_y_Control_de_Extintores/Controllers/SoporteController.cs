using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Registro_y_control_de_extintores.Controllers
{
    public class SoporteController : Controller
    {
        public IActionResult Soporte()
        {
            return View();
        }
    }
}
