using Microsoft.AspNetCore.Mvc;

namespace Registro_y_control_de_extintores.Controllers
{
    public class Inicio_de_sesionController : Controller
    {
        public IActionResult Inicio_de_sesion()
        {
            return View();
        }

        [HttpPost]
        public string Autenticar_usuario()
        {

            //Request.Form["txtTest"] == "myValue";
            //return Content($"{uname}");
            return "autenticando usuario....";
        }
    }
}
