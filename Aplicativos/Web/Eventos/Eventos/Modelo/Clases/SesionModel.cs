using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class SesionModel
    {
        public string IDSESION { get; set; }
        public string NOMBRE { get; set; }
        public DateTime HORA_INI { get; set; }
        public DateTime HORA_FINAL { get; set; }
        public string EVENTO { get; set; }

        public SesionModel()
        {
            IDSESION = "";
            NOMBRE = "";
            HORA_INI = new DateTime();
            HORA_FINAL = new DateTime();
            EVENTO = "";
        }

        public SesionModel(string id, string nombre, string hora_inicial, string hora_final, string evento)
        {
            IDSESION = id;
            NOMBRE = evento;
            HORA_INI = DateTime.Parse(hora_inicial);
            HORA_FINAL = DateTime.Parse(hora_inicial);
            EVENTO = evento;
        }
        public SesionModel(string nombre, string hora_inicial, string hora_final, string evento)
        {
            NOMBRE = evento;
            HORA_INI = DateTime.Parse(hora_inicial);
            HORA_FINAL = DateTime.Parse(hora_inicial);
            EVENTO = evento;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(SesionModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public SesionModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new SesionModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public DataTable ConsultarSesion(string evento)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}