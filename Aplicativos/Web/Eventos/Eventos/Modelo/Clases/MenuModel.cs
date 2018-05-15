using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class MenuModel
    {
        public string IDMENU { get; set; }
        public string NOMBRE { get; set; }
        public string URL { get; set; }
        public string ICONO { get; set; }
        public string TIPO { get; set; }

        public MenuModel()
        {
            IDMENU = "";
            NOMBRE = "";
            URL = "";
            ICONO = "";
            TIPO = "";
        }
        public MenuModel(string id, string nombre, string url, string icono, string tipo)
        {
            IDMENU = id;
            NOMBRE = nombre;
            URL = url;
            ICONO = icono;
            TIPO = tipo;
        }

        public MenuModel( string nombre, string url, string icono, string tipo)
        {
            NOMBRE = nombre;
            URL = url;
            ICONO = icono;
            TIPO = tipo;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("CALL `PR_MENU_REGISTRAR`('"+NOMBRE+ "', '" + URL + "', '" + ICONO + "', '" + TIPO + "')");
        }

        public bool Modificar()
        {
            return new Datos().OperarDatos("CALL `PR_MENU_ACTUALIZAR`('"+IDMENU+ "', '" + NOMBRE + "', '" + URL + "', '" + ICONO + "', '" + TIPO + "')");
        }

        public bool AgregarPermiso(string tipo,string menu, string rol)
        {
            switch (tipo)
            {
                case "USUARIO":
                    return new Datos().OperarDatos("");
                case "PARTICIPANTE":
                    return new Datos().OperarDatos("");
                default:
                    return false;
            }
        }

        public bool EliminarPermiso(string tipo, string rol)
        {
            switch (tipo)
            {
                case "USUARIO":
                    return new Datos().OperarDatos("");
                case "PARTICIPANTE":
                    return new Datos().OperarDatos("");
                default:
                    return false;
            }
        }

        public bool Eliminar(string id)
        {
            return new Datos().OperarDatos("CALL `PR_MENU_ELIMINAR`('"+id+"')");
        }

        public MenuModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_MENU_CONSULTAR_ID`('"+id+"')");
            return new MenuModel(
                consulta.Rows[0]["IDMENU"].ToString(),
                consulta.Rows[0]["MENU_NOMBRE"].ToString(),
                consulta.Rows[0]["MENU_URL"].ToString(),
                consulta.Rows[0]["MENU_ICONO"].ToString(), 
                consulta.Rows[0]["MENU_TIPO"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_MENU_CONSULTAR_G`()");
        }

        public DataTable ConsultarPermiso(string tipo,string rol)
        {
            switch (tipo)
            {
                case "USUARIO":
                    return new Datos().ConsultarDatos("CALL `PR_PERMISO_CONSULTAR`('"+rol+"')");
                case "PARTICIPANTE":
                    return new Datos().ConsultarDatos("");
                default:
                    return new DataTable();
            }
        }
    }
}