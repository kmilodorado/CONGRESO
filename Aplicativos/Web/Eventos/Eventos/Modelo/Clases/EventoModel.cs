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
        public string LOGO { get; set; }
        public string POSTER { get; set; }
        public DateTime FECHA_INICIAL { get; set; }
        public DateTime FECHA_FINAL { get; set; }
        public string ESTADO { get; set; }
        public string CUPOS { get; set; }
        public string CORREO { get; set; }
        public Tipo_CostoModel TIPO_COSTO { get; set; }

        public EventoModel()
        {
            IDEVENTO = "";
            NOMBRE = "";
            SIGLAS = "";
            LOGO = "";
            POSTER = "";
            FECHA_INICIAL = new DateTime();
            FECHA_FINAL = new DateTime();
            ESTADO = "";
            CUPOS = "";
            CORREO = "";
            TIPO_COSTO = new Tipo_CostoModel();
        }
        public EventoModel(string id, string nombre, string siglas, string logo, string poster, string correo, string fecha_inicial, string fecha_final, string estado, string cupos,  string tipo_costo)
        {
            IDEVENTO = id;
            NOMBRE = nombre;
            SIGLAS = siglas;
            LOGO = logo;
            POSTER = "";
            CORREO = correo;
            FECHA_INICIAL =DateTime.Parse(fecha_inicial);
            FECHA_FINAL = DateTime.Parse(fecha_final);
            ESTADO = estado;
            CUPOS = cupos;
           
            TIPO_COSTO = new Tipo_CostoModel().Consultar(tipo_costo);
        }

        public EventoModel(string nombre, string siglas, string logo, string poster, string correo, string fecha_inicial, string fecha_final, string estado, string cupos, string tipo_costo)
        {
            NOMBRE = nombre;
            SIGLAS = siglas;
            LOGO = logo;
            POSTER = poster;
            CORREO = correo;
            FECHA_INICIAL = DateTime.Parse(fecha_inicial);
            FECHA_FINAL = DateTime.Parse(fecha_final);
            ESTADO = estado;
            CUPOS = cupos;
            TIPO_COSTO = new Tipo_CostoModel().Consultar(tipo_costo);
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos(
                string.Format("CALL `PR_EVENTO_REGISTRAR`('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');",
                NOMBRE,
                SIGLAS,
                LOGO,
                POSTER,
                FECHA_INICIAL.ToString("yyyy/MM/dd"),
                FECHA_FINAL.ToString("yyyy/MM/dd"),
                ESTADO,
                CUPOS,
                TIPO_COSTO.IDTIPO_COSTO,
                CORREO
                ));
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
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_EVENTO_CONSULTAR_ID`('"+id+"')");
            return new EventoModel(
                consulta.Rows[0]["IDEVENTO"].ToString(),
                consulta.Rows[0]["EVEN_NOMBRE"].ToString(),
                consulta.Rows[0]["EVEN_SIGLAS"].ToString(),
                consulta.Rows[0]["EVEN_LOGO"].ToString(),
                consulta.Rows[0]["EVEN_POSTER"].ToString(),
                consulta.Rows[0]["EVEN_CORREO"].ToString(),
                consulta.Rows[0]["EVEN_FECHA_INI"].ToString(),
                consulta.Rows[0]["EVEN_FECHA_FIN"].ToString(),
                consulta.Rows[0]["EVEN_ESTADO"].ToString(),
                consulta.Rows[0]["EVEN_CUPOS"].ToString(),
                consulta.Rows[0]["EVEN_IDTIPO_COSTO"].ToString()
                );
        }

        public EventoModel ConsultarSiglas(string sigla)
        {
            DataTable consulta = new Datos().ConsultarDatos("CALL `PR_EVENTO_CONSULTAR_SIGLAS`('"+sigla+"')");
            return new EventoModel(
                consulta.Rows[0]["IDEVENTO"].ToString(),
                consulta.Rows[0]["EVEN_NOMBRE"].ToString(),
                consulta.Rows[0]["EVEN_SIGLAS"].ToString(),
                consulta.Rows[0]["EVEN_LOGO"].ToString(),
                consulta.Rows[0]["EVEN_POSTER"].ToString(),
                consulta.Rows[0]["EVEN_CORREO"].ToString(),
                consulta.Rows[0]["EVEN_FECHA_INI"].ToString(),
                consulta.Rows[0]["EVEN_FECHA_FIN"].ToString(),
                consulta.Rows[0]["EVEN_ESTADO"].ToString(),
                consulta.Rows[0]["EVEN_CUPOS"].ToString(),
                consulta.Rows[0]["EVEN_IDTIPO_COSTO"].ToString()
                );
        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("CALL `PR_EVENTO_CONSULTAR_G`()");
        }
    }
}