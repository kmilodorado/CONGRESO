using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class Tipo_CostoModel
    {
        public string IDTIPO_COSTO { get; set; }
        public string DETALLE { get; set; }

        public Tipo_CostoModel()
        {
            IDTIPO_COSTO = "";
            DETALLE = "";
        }

        public Tipo_CostoModel(string id, string detalle)
        {
            IDTIPO_COSTO = id;
            DETALLE = detalle;
        }

        public Tipo_CostoModel( string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public Tipo_CostoModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new Tipo_CostoModel(consulta.Rows[0][""].ToString(), consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}