using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class Tipo_EventoModel
    {
        public string IDTIPO_EVENTO { get; set; }
        public string DETALLE { get; set; }

        public Tipo_EventoModel()
        {
            IDTIPO_EVENTO = "";
            DETALLE = "";
        }

        public Tipo_EventoModel(string id, string detalle)
        {
            IDTIPO_EVENTO = id;
            DETALLE = detalle;
        }

        public Tipo_EventoModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public Tipo_EventoModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("('" + id + "')");
            return new Tipo_EventoModel(consulta.Rows[0]["IDTIPO_PRECIO"].ToString(), consulta.Rows[0]["TIPO_DETALLE"].ToString());
        }

        public DataTable Consultar(string identificacion,string tipo_evento)
        {
            return new Datos().ConsultarDatos("CALL `PR_INSCRIPCION_CONSULTAR`('" + identificacion + "', '" + tipo_evento + "')");
        }

        public bool Inscribir(string identificacion,string tipo_evento)
        {
            return new Datos().OperarDatos("CALL `PR_INSCRIPCION_REGISTRAR`('"+identificacion+"', '"+tipo_evento+"')");
        }
    }
}