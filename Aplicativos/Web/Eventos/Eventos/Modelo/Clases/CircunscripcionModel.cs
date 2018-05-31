using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class CircunscripcionModel
    {
        public string IDCIRCUNSCRIPCION { get; set; }
        public string DETALLE { get; set; }

        public CircunscripcionModel()
        {
            IDCIRCUNSCRIPCION = "";
            DETALLE = "";
        }

        public CircunscripcionModel(string id, string detalle)
        {
            IDCIRCUNSCRIPCION = id;
            DETALLE = detalle;
        }

        public CircunscripcionModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public CircunscripcionModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_CIRCUNSCRIPCION_CONSULTAR_ID`('" + id + "')");
            return new CircunscripcionModel(
                consulta.Rows[0]["IDCIRCUNSCRIPCION"].ToString(),
                consulta.Rows[0]["CIRC_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_CIRCUNSCRIPCION_CONSULTAR`()");
        }
    }
}