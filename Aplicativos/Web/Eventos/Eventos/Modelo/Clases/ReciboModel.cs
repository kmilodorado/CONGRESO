using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class ReciboModel
    {
        public string IDRECIBO { get; set; }
        public string PARTICIPANTE { get; set; }
        public string ARCHIVO { get; set; }
        public string VALIDADOR { get; set; }
        public string ESTADO { get; set; }

        public ReciboModel()
        {
            IDRECIBO = "";
            PARTICIPANTE = "";
            ARCHIVO = "";
            VALIDADOR = "";
            ESTADO = "";
        }

        public ReciboModel(string id, string participante, string direccion, string validador, string estado)
        {
            IDRECIBO = id;
            PARTICIPANTE = participante;
            ARCHIVO = direccion;
            VALIDADOR = validador;
            ESTADO = estado;
        }
        public ReciboModel(string participante, string direccion, string validador, string estado)
        {
            PARTICIPANTE = participante;
            ARCHIVO = direccion;
            VALIDADOR = validador;
            ESTADO = estado;
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(ReciboModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public ReciboModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new ReciboModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }
        public ReciboModel ConsultarParticipante(string participante)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new ReciboModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        } 

        public DataTable ConsultarParticipantes(string evento)
        {
            return new Datos().ConsultarDatos("");
        }

        public DataTable ConsultarParticipantes(string evento, string tipo_participante)
        {
            return new Datos().ConsultarDatos("");
        }
    }
}