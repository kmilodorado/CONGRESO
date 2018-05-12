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
            return new Datos().OperarDatos("");
        }

        public bool Modificar(MenuModel obj)
        {
            return new Datos().OperarDatos("");
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
            return new Datos().OperarDatos("");
        }

        public MenuModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new MenuModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(), 
                consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }

        public DataTable ConsultarPermiso(string tipo,string rol)
        {
            switch (tipo)
            {
                case "USUARIO":
                    return new Datos().ConsultarDatos("");
                case "PARTICIPANTE":
                    return new Datos().ConsultarDatos("");
                default:
                    return new DataTable();
            }
        }
    }
}