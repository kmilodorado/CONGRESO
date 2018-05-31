using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class CuestionarioModel
    {
        public string IDPREGUNTA { get; set; }
        public string RESPUESTA { get; set; }

       public CuestionarioModel()
        {
            IDPREGUNTA = "";
            RESPUESTA = "";
        }
        public CuestionarioModel(string id,string respuesta)
        {
            IDPREGUNTA = id;
            RESPUESTA = respuesta;
        }

        public DataTable ConsultarPreguntas()
        {
            return new Datos().ConsultarDatos("CALL `PR_PREGUNTA_CONSULTAR`()");
        }

        public void RegistrarRespuesta(string text,string respuesta,string identificacion)
        {
           new Datos().OperarDatos("CALL `PR_RESPUESTA_REGISTRAR`('"+text+"', '"+respuesta+"', '"+ identificacion + "')");
        }
    }
}