using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class ProgramaModel
    {
        public string IDPROGRAMA { get; set; }
        public string EVENTO { get; set; }
        public string TEMA { get; set; }
        public DateTime HORA_INICIO { get; set; }
        public DateTime HORA_FIN { get; set; }
        public string LUGAR { get; set; }

        public ProgramaModel()
        {
            IDPROGRAMA = "";
            EVENTO = "";
            TEMA = "";
            HORA_INICIO = new DateTime();
            HORA_FIN = new DateTime();
            LUGAR = "";
        }

        public ProgramaModel(string id, string evento, string tema, string hora_inicial, string hora_final,string lugar)
        {
            IDPROGRAMA = id;
            EVENTO = evento;
            TEMA = tema;
            HORA_INICIO = DateTime.Parse(hora_inicial);
            HORA_FIN = DateTime.Parse(hora_inicial);
            LUGAR = lugar;
        }
        public ProgramaModel(string evento, string tema, string hora_inicial, string hora_final, string lugar)
        {
            EVENTO = evento;
            TEMA = tema;
            HORA_INICIO = DateTime.Parse(hora_inicial);
            HORA_FIN = DateTime.Parse(hora_inicial);
            LUGAR = lugar;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(ProgramaModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public DataTable ConsultarTemas(string evento)
        {
            return new Datos().ConsultarDatos("");
        }

        public DataTable ConsultarPrograma(string programa)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}