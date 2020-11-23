using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Registro_y_control_de_extintores.Controllers
{
    public class MenuUsuarioController : Controller
    { 
        public ActionResult MenuPrincipalUsuarios()
        {
            //despliega el menu principal del manejo de usuarios
            return View("Menu_usuario");
        }
    
    // POST: MenuUsuarioController

        public ActionResult CrearUsuarioMenu()
        {
            //despliega el menu para crear usuarios
            return View("CrearUsuario");
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

        public ActionResult RegistrarUsuarioNuevo()
        {
            //espacio para logica de registrar usuario nuevo
            return View("Menu_usuario");
        }

        public ActionResult ModificarUsuarioExistente()
        {
            //espacio para logica de modificar usuario existente
            return View("Menu_usuario");
        }

        public ActionResult EliminarUsuarioExistente()
        {
            //espacio para logica de eliminar usuario existente
            return View("Menu_usuario");
        }
    }

}