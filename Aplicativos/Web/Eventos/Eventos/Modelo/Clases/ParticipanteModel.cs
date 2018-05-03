using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class ParticipanteModel
    {
        public string IDPARTICIPANTE { get; set; }
        public string EVENTO { get; set; }
        public UsuarioModel USUARIO { get; set; }
        public Tipo_ParticipanteModel TIPO_PARTICIPANTE { get; set; }
        public char CERTIFICADO { get; set; }

        public ParticipanteModel()
        {
            IDPARTICIPANTE = "";
            EVENTO = "";
            USUARIO = new UsuarioModel();
            TIPO_PARTICIPANTE = new  Tipo_ParticipanteModel();
            CERTIFICADO = 'N';
        }

        public ParticipanteModel(string id, string evento, string usuario, string tipo_participante, string certificado)
        {
            IDPARTICIPANTE = id;
            EVENTO = evento;
            USUARIO = new UsuarioModel().ConsultarUsuario(usuario);
            TIPO_PARTICIPANTE = new Tipo_ParticipanteModel().Consultar(tipo_participante);
            CERTIFICADO = certificado.ToCharArray()[0];
        }
        public ParticipanteModel(string evento, string usuario, string tipo_participante, string certificado)
        {
            EVENTO = evento;
            USUARIO = new UsuarioModel().ConsultarUsuario(usuario);
            TIPO_PARTICIPANTE = new Tipo_ParticipanteModel().Consultar(tipo_participante);
            CERTIFICADO = certificado.ToCharArray()[0];
        }

        public bool Registrar()
        {
            return new Datos().OperarDatos("");
        }

        public bool Modificar(ParticipanteModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public ParticipanteModel Consultar(string id)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new ParticipanteModel(
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString(),
                consulta.Rows[0][""].ToString());
        }

        public ParticipanteModel ConsultarUser(string user)
        {
            DataTable consulta = new Datos().ConsultarDatos("");
            return new ParticipanteModel(
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

        public DataTable ConsultarParticipantes(string evento,string tipo_participante)
        {
            return new Datos().ConsultarDatos("");
        }

    }
}