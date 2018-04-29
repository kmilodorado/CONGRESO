using Eventos.AccesoDatos.Clase;
using Eventos.AccesoDatos.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class Tipo_PersonaModel
    {
        public string IDTIPO_PERSONA { get; set; }
        public string DETALLE { get; set; }

        public Tipo_PersonaModel()
        {
            IDTIPO_PERSONA = "";
            DETALLE = "";
        }

        public Tipo_PersonaModel(string id,string detalle)
        {
            IDTIPO_PERSONA = id;
            DETALLE = detalle;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public Tipo_PersonaModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new Tipo_PersonaModel(consulta.Rows[0][""].ToString(),consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}