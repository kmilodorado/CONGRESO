using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class EventoModel
    {
        public string IDEVENTO { get; set; }
        public string NOMBRE { get; set; }
        public string SIGLAS { get; set; }
        public DateTime FECHA_INICIAL { get; set; }
        public DateTime FECHA_FINAL { get; set; }
        public string ESTADO { get; set; }
        public string CUPOS { get; set; }
        public LugarModel LUGAR { get; set; }
        public Tipo_CostoModel TIPO_COSTO { get; set; }

        public EventoModel()
        {
            IDEVENTO = "";
            NOMBRE = "";
            SIGLAS = "";
            FECHA_INICIAL = new DateTime();
            FECHA_FINAL = new DateTime();
            ESTADO = "";
            CUPOS = "";
            LUGAR = new LugarModel();
            TIPO_COSTO = new Tipo_CostoModel();
        }
        public EventoModel(string id, string nombre, string siglas, string fecha_inicial, string fecha_final, string estado, string cupos, string lugar, string tipo_costo)
        {
            IDEVENTO = id;
            NOMBRE = nombre;
            SIGLAS = siglas;
            FECHA_INICIAL =DateTime.Parse(fecha_inicial);
            FECHA_FINAL = DateTime.Parse(fecha_final);
            ESTADO = estado;
            CUPOS = cupos;
            LUGAR = new LugarModel().Consultar(lugar);
            TIPO_COSTO = new Tipo_CostoModel().Consultar(tipo_costo);
        }

        public EventoModel(string nombre, string siglas, string fecha_inicial, string fecha_final, string estado, string cupos, string lugar, string tipo_costo)
        {
            NOMBRE = nombre;
            SIGLAS = siglas;
            FECHA_INICIAL = DateTime.Parse(fecha_inicial);
            FECHA_FINAL = DateTime.Parse(fecha_final);
            ESTADO = estado;
            CUPOS = cupos;
            LUGAR = new LugarModel().Consultar(lugar);
            TIPO_COSTO = new Tipo_CostoModel().Consultar(tipo_costo);
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(EventoModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public bool ModificarEstado(string id,string estado)
        {
            return new Datos().OperarDatos("");
        }
        public EventoModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new EventoModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public EventoModel ConsultarSiglas(string sigla)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new EventoModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}