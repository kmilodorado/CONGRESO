using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class AsistenciaModel
    {
        public string IDASISTENCIA { get; set; }
        public string PARTICIPANTE { get; set; }
        public SesionModel SESION { get; set; }
        public DateTime FECHA_ENTRADA { get; set; }
        public DateTime FECHA_FINAL { get; set; }
        public string ESTADO { get; set; }

        public AsistenciaModel()
        {
            IDASISTENCIA = "";
            PARTICIPANTE = "";
            SESION = new SesionModel();
            FECHA_ENTRADA = new DateTime();
            FECHA_FINAL = new DateTime();
            ESTADO = "";
        }

        public AsistenciaModel(string id, string participante, string sesion, string hora_inicial, string hora_final, string estado)
        {
            IDASISTENCIA = id;
            PARTICIPANTE = participante;
            SESION = new SesionModel().Consultar(sesion);
            FECHA_ENTRADA = DateTime.Parse(hora_inicial);
            FECHA_FINAL = DateTime.Parse(hora_inicial);
            ESTADO = estado;
        }
        public AsistenciaModel(string participante, string sesion, string hora_inicial, string hora_final, string estado)
        {
            PARTICIPANTE = participante;
            SESION = new SesionModel().Consultar(sesion);
            FECHA_ENTRADA = DateTime.Parse(hora_inicial);
            FECHA_FINAL = DateTime.Parse(hora_inicial);
            ESTADO = estado;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(AsistenciaModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public DataTable ConsultarAsistencia(string evento)
        {
            return new Datos().ConsultarDatos("CALL `PR_ASISTENCIA_CONSULTAR`('"+evento+"')");
        }

        public DataTable ConsultarParticipante(string Participante)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}