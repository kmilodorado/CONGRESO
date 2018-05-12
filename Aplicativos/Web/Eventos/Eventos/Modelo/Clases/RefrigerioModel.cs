using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class RefrigerioModel
    {
        public string IDREFRIGERIO { get; set; }
        public string PARTICIPANTE { get; set; }
        public SesionModel SESION { get; set; }
        public DateTime FECHA_RECLAMO { get; set; }
        public string ESTADO { get; set; }

        public RefrigerioModel()
        {
            IDREFRIGERIO = "";
            PARTICIPANTE = "";
            SESION = new SesionModel();
            FECHA_RECLAMO = new DateTime();
            ESTADO = "";
        }

        public RefrigerioModel(string id, string participante, string sesion, string hora_inicial, string estado)
        {
            IDREFRIGERIO = id;
            PARTICIPANTE = participante;
            SESION = new SesionModel().Consultar(sesion);
            FECHA_RECLAMO = DateTime.Parse(hora_inicial);
            ESTADO = estado;
        }
        public RefrigerioModel(string participante, string sesion, string hora_inicial,  string estado)
        {
            PARTICIPANTE = participante;
            SESION = new SesionModel().Consultar(sesion);
            FECHA_RECLAMO = DateTime.Parse(hora_inicial);
            ESTADO = estado;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(RefrigerioModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public DataTable ConsultarAsistencia(string evento)
        {
            return new Datos().ConsultarDatos("");
        }

        public DataTable ConsultarParticipante(string Participante)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}