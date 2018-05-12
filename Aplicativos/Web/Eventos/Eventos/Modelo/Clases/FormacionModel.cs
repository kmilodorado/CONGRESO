using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class FormacionModel
    {
        public string IDFORMACION { get; set; }
        public string DETALLE { get; set; }

        public FormacionModel()
        {
            IDFORMACION = "";
            DETALLE = "";
        }

        public FormacionModel(string id, string detalle)
        {
            IDFORMACION = id;
            DETALLE = detalle;
        }

        public FormacionModel(string detalle)
        {
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public FormacionModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_FORMACION_CONSULTAR_ID`('"+id+"');");
            return new FormacionModel(consulta.Rows[0]["IDFORMACION"].ToString(), consulta.Rows[0]["FORM_DETALLE"].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_FORMACION_CONSULTAR_G`();");
        }
    }
}