using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class Tipo_IdentificacionModel
    {
        public string IDTIPO_IDENTIFICACION { get; set; }
        public string DETALLE { get; set; }

        public Tipo_IdentificacionModel()
        {
            IDTIPO_IDENTIFICACION = "";
            DETALLE = "";
        }

        public Tipo_IdentificacionModel(string id, string detalle)
        {
            IDTIPO_IDENTIFICACION = id;
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public Tipo_IdentificacionModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new Tipo_IdentificacionModel(consulta.Rows[0][""].ToString(), consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}