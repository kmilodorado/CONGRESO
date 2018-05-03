using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class OcupacionModel
    {
        public string IDOCUPACION { get; set; }
        public string DETALLE { get; set; }

        public OcupacionModel()
        {
            IDOCUPACION = "";
            DETALLE = "";
        }

        public OcupacionModel(string id, string detalle)
        {
            IDOCUPACION = id;
            DETALLE = detalle;
        }

        public OcupacionModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public OcupacionModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_OCUPACION_CONSULTAR_ID`('"+id+"')");
            return new OcupacionModel(consulta.Rows[0]["IDOCUPACION"].ToString(), consulta.Rows[0]["TIPO_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_OCUPACION_CONSULTAR_G`()");
        }
    }
}