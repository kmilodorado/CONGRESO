using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class Tipo_PrecioModel
    {
        public string IDTIPO_PRECIO { get; set; }
        public string DETALLE { get; set; }

        public Tipo_PrecioModel()
        {
            IDTIPO_PRECIO = "";
            DETALLE = "";
        }

        public Tipo_PrecioModel(string id, string detalle)
        {
            IDTIPO_PRECIO = id;
            DETALLE = detalle;
        }

        public Tipo_PrecioModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public Tipo_PrecioModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_TIPO_PRECIO_CONSULTAR_ID`('"+id+"')");
            return new Tipo_PrecioModel(consulta.Rows[0]["IDTIPO_PRECIO"].ToString(), consulta.Rows[0]["TIPO_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_TIPO_PRECIO_CONSULTAR_G`()");
        }
    }
}