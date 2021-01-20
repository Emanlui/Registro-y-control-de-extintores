using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using MySqlConnector;


namespace Registro_y_control_de_extintores.Models
{
    class CrudExtintor
    {
        //Crear extintor
        public ExtintorModel extintor { set; get; }

        public void Crear_Extintor()
        {

            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "Insert into extintor (id_centro, activo, tipo, ubicacion_geografica, ubicacion, agente_extintor, " +
                                                        "capacidad, ultima_prueba_hidrostatica, proxima_prueba_hidrostatica, " +
                                                        "proximo_mantenimiento, presion, rotulacion, acceso_a_extintor, condicion_extintor, " +
                                                        "seguro_y_marchamo, collarin, condicion_manguera, condicion_boquilla) " +
                                                        "VALUES " +
                                                        "(@id_centro, @activo, @tipo, @ubicacion_geografica, @ubicacion, @agente_extintor, " +
                                                        "@capacidad, @ultima_prueba_hidrostatica, @proxima_prueba_hidrostatica, " +
                                                        "@proximo_mantenimiento, @presion, @rotulacion, @acceso_a_extintor, @condicion_extintor, " +
                                                        "@seguro_y_marchamo, @collarin, @condicion_manguera, @condicion_boquilla) ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@id_centro", MySqlDbType.Int32).Value = extintor.Id_centro;
                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = extintor.Activo;
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = extintor.Tipo;
                cmd.Parameters.Add("@ubicacion_geografica", MySqlDbType.VarChar).Value = extintor.Ubicacion_geografica;
                cmd.Parameters.Add("@ubicacion", MySqlDbType.VarChar).Value = extintor.Ubicacion;
                cmd.Parameters.Add("@agente_extintor", MySqlDbType.VarChar).Value = extintor.Agente_extintor;
                cmd.Parameters.Add("@capacidad", MySqlDbType.Int32).Value = extintor.Capacidad;
                cmd.Parameters.Add("@ultima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Ultima_prueba_hidrostatica;
                cmd.Parameters.Add("@proxima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Proxima_prueba_hidrostatica;
                cmd.Parameters.Add("@proximo_mantenimiento", MySqlDbType.Date).Value = extintor.Proximo_mantenimiento;
                cmd.Parameters.Add("@presion", MySqlDbType.Int32).Value = extintor.Presion;
                cmd.Parameters.Add("@rotulacion", MySqlDbType.Int32).Value = extintor.Rotulacion;
                cmd.Parameters.Add("@acceso_a_extintor", MySqlDbType.Int32).Value = extintor.Acceso_a_extintor;
                cmd.Parameters.Add("@condicion_extintor", MySqlDbType.Int32).Value = extintor.Condicion_extintor;
                cmd.Parameters.Add("@seguro_y_marchamo", MySqlDbType.Int32).Value = extintor.Seguro_y_marchamo;
                cmd.Parameters.Add("@collarin", MySqlDbType.Int32).Value = extintor.Collarin;
                cmd.Parameters.Add("@condicion_manguera", MySqlDbType.Int32).Value = extintor.Condicion_manguera;
                cmd.Parameters.Add("@condicion_boquilla", MySqlDbType.Int32).Value = extintor.Condicion_boquilla;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        public void Eliminar_Extintor()
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE extintor SET habilitado = 0 WHERE activo=@activo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = extintor.Activo;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        public List<ExtintorModel> Obtener_Datos_Extintores()
        {
            //Conexion a la base
            //configuracion de mysql
            Conexion mainconn = new Conexion();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            //creacion de consulta mysql para buscar los extintores en la base de datos
            string Query_Data = "SELECT * FROM extintor";
            cmd = new MySqlCommand(Query_Data, mainconn.con);
            cmd.CommandType = CommandType.Text;

            //abrir la conexion y realizar la consulta
            mainconn.con.Open();
            reader = cmd.ExecuteReader();

            //lista donde guardaremos los datos de los extintores
            List<ExtintorModel> Data_Obtained = new List<ExtintorModel>();

            CrudCentro nombre_centro = new CrudCentro();
            

            if (!reader.HasRows)
            {
                //No hay datos
            }
            else
            {
                //obtener los datos del sql y guardarlos en la lista temporal
                while (reader.Read())
                {
                    var details = new ExtintorModel();

                    //datos del extintor que se agregan a la lista del modelo para ser impresos en el menuPrincipal
                    details.Id_centro = (int)reader["id_centro"];                    
                    details.Centro = nombre_centro.Obtener_Centro_Extintor(details.Id_centro);
                    details.Activo = reader["activo"].ToString();
                    details.Tipo = reader["tipo"].ToString();
                    details.Ubicacion_geografica = reader["ubicacion_geografica"].ToString();
                    details.Ubicacion = reader["ubicacion"].ToString();
                    details.Agente_extintor = reader["agente_extintor"].ToString();
                    details.Capacidad = (int)reader["capacidad"];
                    string[] date = reader["ultima_prueba_hidrostatica"].ToString().Split(" ");
                    details.Ultima_prueba_hidrostatica = date[0];
                    date = reader["proxima_prueba_hidrostatica"].ToString().Split(" ");
                    details.Proxima_prueba_hidrostatica = date[0];
                    date = reader["proximo_mantenimiento"].ToString().Split(" ");
                    details.Proximo_mantenimiento = date[0];
                    details.Presion = (int)(ulong)reader["presion"];
                    details.Rotulacion = (int)reader["rotulacion"];
                    details.Acceso_a_extintor = (int)(ulong)reader["acceso_a_extintor"];
                    details.Condicion_extintor = (int)(ulong)reader["condicion_extintor"];
                    details.Seguro_y_marchamo = (int)(ulong)reader["seguro_y_marchamo"];
                    details.Collarin = (int)(ulong)reader["collarin"];
                    details.Condicion_manguera = (int)(ulong)reader["condicion_manguera"];
                    details.Condicion_boquilla = (int)(ulong)reader["condicion_boquilla"];
                    details.Habilitado = (int)(ulong)reader["habilitado"];

                    Data_Obtained.Add(details);
                }
            }

            return Data_Obtained;
        }

        public byte[] DescargarDatos() {


            using (var libro_trabajo = new XLWorkbook())
            {
                var hoja = libro_trabajo.Worksheets.Add("Datos de Extintores"); //nombre de la hoja                
                hoja.Cell(1, 1).Value = "Id Centro"; //esto debería ser el nombre, para futuras referencias
                hoja.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                //encabezados
                hoja.Cell(1, 2).Value = "Activo";
                hoja.Cell(1, 3).Value = "Ubicacion Geografica";
                hoja.Cell(1, 4).Value = "Ubicacion";
                hoja.Cell(1, 5).Value = "Agente Extintor";
                hoja.Cell(1, 6).Value = "Tipo";
                hoja.Cell(1, 7).Value = "Capacidad";
                hoja.Cell(1, 8).Value = "Ultima Prueba Hidrostatica";
                hoja.Cell(1, 9).Value = "Proxima Prueba Hidrostatica";
                hoja.Cell(1, 10).Value = "Proximo Mantenimiento";
                hoja.Cell(1, 11).Value = "Presion";
                hoja.Cell(1, 12).Value = "Rotulacion";
                hoja.Cell(1, 13).Value = "Acceso a Extintor";
                hoja.Cell(1, 14).Value = "Condicion Extintor";
                hoja.Cell(1, 15).Value = "Seguro y Marchamo";
                hoja.Cell(1, 16).Value = "Collarin";
                hoja.Cell(1, 17).Value = "Condicion Manguera";
                hoja.Cell(1, 18).Value = "Condicion Boquilla";
                hoja.Cell(1, 19).Value = "Habilitado";

                //conexion SQL
                Conexion conexion = new Conexion();
                DataTable dt = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM extintor", conexion.con);
                ad.Fill(dt);
                int i = 2;
                //por si se necesita cambiar la palabra clave a la hora de imprimir los datos
                string incorrecto = "Incorrecto";
                string correcto = "Correcto";
                foreach (DataRow fila in dt.Rows)
                {
                    hoja.Cell(i, 1).Value = fila[1].ToString();//id centro
                    hoja.Cell(i, 2).Value = fila[3].ToString();//tipo
                    hoja.Cell(i, 3).Value = fila[4].ToString();//activo
                    hoja.Cell(i, 4).Value = fila[5].ToString();//ubicacion geografica
                    hoja.Cell(i, 5).Value = fila[2].ToString();//ubicacion
                    hoja.Cell(i, 6).Value = fila[6].ToString();//agente extintor
                    hoja.Cell(i, 7).Value = fila[7].ToString();//capacidad
                    hoja.Cell(i, 8).Value = fila[8].ToString();//ultima prueba hidro
                    hoja.Cell(i, 9).Value = fila[9].ToString();//proxima prueba hidro
                    hoja.Cell(i, 10).Value = fila[10].ToString();//proximo mantenimiento

                    if (fila[11].ToString() == "1")//presion
                    {
                        hoja.Cell(i, 11).Value = incorrecto;
                    }
                    else { hoja.Cell(i, 11).Value = correcto; }

                    if (fila[12].ToString() == "1")//rotulacion
                    {
                        hoja.Cell(i, 12).Value = incorrecto;
                    }
                    else { hoja.Cell(i, 12).Value = correcto; }

                    if (fila[13].ToString() == "1")//acceso a extintor
                    {
                        hoja.Cell(i, 13).Value = incorrecto;

                    }
                    else { hoja.Cell(i, 13).Value = correcto; }

                    if (fila[14].ToString() == "1")//condicion extintor
                    {
                        hoja.Cell(i, 14).Value = incorrecto;

                    }
                    else { hoja.Cell(i, 14).Value = correcto; }

                    if (fila[15].ToString() == "1")//seguro y marchamo
                    {
                        hoja.Cell(i, 15).Value = incorrecto;

                    }
                    else { hoja.Cell(i, 15).Value = correcto; }

                    if (fila[16].ToString() == "1") //collarin
                    {
                        hoja.Cell(i, 16).Value = incorrecto;

                    }
                    else { hoja.Cell(i, 16).Value = correcto; }

                    if (fila[17].ToString() == "1") //condicion manguera
                    {
                        hoja.Cell(i, 17).Value = incorrecto;
                    }
                    else { hoja.Cell(i, 17).Value = correcto; }

                    if (fila[18].ToString() == "1")//condicion boquilla
                    {
                        hoja.Cell(i, 18).Value = incorrecto;
                    }
                    else { hoja.Cell(i, 18).Value = correcto; }

                    if (fila[19].ToString() == "1")//Habilitado
                    {
                        hoja.Cell(i, 19).Value = "Habilitado";
                    }
                    else { hoja.Cell(i, 19).Value = "Deshabilitado"; }

                    i++;
                }
                i = i - 1;
                hoja.Columns("A", "S").AdjustToContents();

                using (var datos = new MemoryStream())
                {
                    libro_trabajo.SaveAs(datos);
                    var contenido = datos.ToArray();
                    return contenido;
                }

            }
        }

        public void Editar_Extintor(string Activo)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE extintor SET id_centro = @id_centro, tipo = @tipo," +
                "ubicacion_geografica = @ubicacion_geografica, ubicacion = @ubicacion, agente_extintor = @agente_extintor , " +
                "capacidad = @capacidad, ultima_prueba_hidrostatica = @ultima_prueba_hidrostatica, proxima_prueba_hidrostatica = @proxima_prueba_hidrostatica, " +
                "proximo_mantenimiento = @proximo_mantenimiento, presion = @presion, rotulacion = @rotulacion, acceso_a_extintor = @acceso_a_extintor, condicion_extintor = @condicion_extintor, " +
                "seguro_y_marchamo = @seguro_y_marchamo, collarin = @collarin, condicion_manguera = @condicion_manguera, condicion_boquilla = @condicion_boquilla " +
                "WHERE activo = @activo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@id_centro", MySqlDbType.Int32).Value = extintor.Id_centro;
                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = extintor.Activo;
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = extintor.Tipo;
                cmd.Parameters.Add("@ubicacion_geografica", MySqlDbType.VarChar).Value = extintor.Ubicacion_geografica;
                cmd.Parameters.Add("@ubicacion", MySqlDbType.VarChar).Value = extintor.Ubicacion;
                cmd.Parameters.Add("@agente_extintor", MySqlDbType.VarChar).Value = extintor.Agente_extintor;
                cmd.Parameters.Add("@capacidad", MySqlDbType.Int32).Value = extintor.Capacidad;
                cmd.Parameters.Add("@ultima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Ultima_prueba_hidrostatica;
                cmd.Parameters.Add("@proxima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Proxima_prueba_hidrostatica;
                cmd.Parameters.Add("@proximo_mantenimiento", MySqlDbType.Date).Value = extintor.Proximo_mantenimiento;
                cmd.Parameters.Add("@presion", MySqlDbType.Int32).Value = extintor.Presion;
                cmd.Parameters.Add("@rotulacion", MySqlDbType.Int32).Value = extintor.Rotulacion;
                cmd.Parameters.Add("@acceso_a_extintor", MySqlDbType.Int32).Value = extintor.Acceso_a_extintor;
                cmd.Parameters.Add("@condicion_extintor", MySqlDbType.Int32).Value = extintor.Condicion_extintor;
                cmd.Parameters.Add("@seguro_y_marchamo", MySqlDbType.Int32).Value = extintor.Seguro_y_marchamo;
                cmd.Parameters.Add("@collarin", MySqlDbType.Int32).Value = extintor.Collarin;
                cmd.Parameters.Add("@condicion_manguera", MySqlDbType.Int32).Value = extintor.Condicion_manguera;
                cmd.Parameters.Add("@condicion_boquilla", MySqlDbType.Int32).Value = extintor.Condicion_boquilla;
                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = Activo.ToString();
                
                cmd.ExecuteNonQuery();
                conexion.con.Close();


            }
        }
    }
}