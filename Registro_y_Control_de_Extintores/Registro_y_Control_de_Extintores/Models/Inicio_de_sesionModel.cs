namespace Registro_y_control_de_extintores.Models
{
    public class Inicio_de_sesion
    {
        public int Id { get; set; }

        public int id_centro { get; set; }

        public int cedula { get; set; }

        public string correo { get; set; }

        public string password { get; set; }

        public int administrador { get; set; }

        public Inicio_de_sesion()
        {
        }
    }
}