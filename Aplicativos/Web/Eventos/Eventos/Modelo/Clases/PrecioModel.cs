using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class PrecioModel
    {
        public string IDPRECIO { get; set; }
        public string VALOR { get; set; }
        public DateTime  FECHA_CIERRE { get; set; }
        public char ESTADO { get; set; }
        public Tipo_PrecioModel TIPO_PRECIO { get; set; }
        public string EVENTO { get; set; }
        public string TIPO_PERSONA { get; set; }

        public PrecioModel() {
            IDPRECIO = "";
            VALOR = "";
            FECHA_CIERRE = new DateTime();
            ESTADO ='S';
            TIPO_PRECIO = new Tipo_PrecioModel();
            EVENTO = "";
            TIPO_PERSONA = "";
        }

        public PrecioModel(string id,string valor, string fecha_cierre, char estado, string t_precio, string evento, string t_persona)
        {
            IDPRECIO = id;
            VALOR = valor;
            FECHA_CIERRE = DateTime.Parse(fecha_cierre);
            ESTADO = estado;
            TIPO_PRECIO = new Tipo_PrecioModel().Consultar(t_precio);
            EVENTO = evento;
            TIPO_PERSONA = t_persona;
        }
        public PrecioModel(string valor,string fecha_cierre, char estado,string t_precio, string evento, string t_persona)
        {
            VALOR = valor;
            FECHA_CIERRE = DateTime.Parse(fecha_cierre);
            ESTADO = estado;
            TIPO_PRECIO = new Tipo_PrecioModel().Consultar(t_precio);
            EVENTO = evento;
            TIPO_PERSONA = t_persona;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(PrecioModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public DataTable Consultar(string evento)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}