using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class EspecialModel
    {
        public string IDESPECIAL { get; set; }
        public string DETALLE { get; set; }

        public EspecialModel()
        {
            IDESPECIAL = "";
            DETALLE = "";
        }

        public EspecialModel(string id, string detalle)
        {
            IDESPECIAL = id;
            DETALLE = detalle;
        }

        public EspecialModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public EspecialModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_ESPECIAL_CONSULTAR_ID`('"+id+"')");
            return new EspecialModel(
                consulta.Rows[0]["IDCOND_ESPECIAL"].ToString(),
                consulta.Rows[0]["COND_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_ESPECIAL_CONSULTAR`()");
        }
    }
}