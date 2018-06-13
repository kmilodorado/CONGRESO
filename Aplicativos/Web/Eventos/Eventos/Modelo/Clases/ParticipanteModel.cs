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
            TIPO_PARTICIPANTE = new Tipo_ParticipanteModel();
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

        public ParticipanteModel(string id, string evento, UsuarioModel usuario, string tipo_participante, string certificado)
        {
            IDPARTICIPANTE = id;
            EVENTO = evento;
            USUARIO = usuario;
            TIPO_PARTICIPANTE = new Tipo_ParticipanteModel().Consultar(tipo_participante);
            CERTIFICADO = certificado.ToCharArray()[0];
        }
        public ParticipanteModel(string evento, UsuarioModel usuario, string tipo_participante, string certificado)
        {
            EVENTO = evento;
            USUARIO = usuario;
            TIPO_PARTICIPANTE = new Tipo_ParticipanteModel().Consultar(tipo_participante);
            CERTIFICADO = certificado.ToCharArray()[0];
        }
        public bool Registrar()
        {

            return new Datos().OperarDatos(string.Format("CALL `PR_PARTICIPANTE_REGISTRAR`('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}','{16}','{17}','{18}','{19}','{20}')",
                USUARIO.IDENTIFICACION,
                USUARIO.TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION,
                USUARIO.NOMBRE,
                USUARIO.APELLIDO,
                USUARIO.CORREO,
                USUARIO.CELULAR,
                USUARIO.MUNICIPIO_RES.IDMUNICIPIO,
                USUARIO.DIRECCION,
                USUARIO.INSTITUCION,
                USUARIO.FORMACION.IDFORMACION,
                USUARIO.OCUPACION.IDOCUPACION,
                USUARIO.USERNAME,
                USUARIO.PASS,
                USUARIO.ROL.IDROL,
                EVENTO,
                TIPO_PARTICIPANTE.IDTIPO_PARTICIPANTE,
                USUARIO.GENERO.IDGENERO,
                USUARIO.FECHA_NAC.ToString("yyyy-MM-dd"),
                USUARIO.PAIS_NAC,
                USUARIO.CONDICION.IDESPECIAL,
                USUARIO.CIRCUNSCRIPCION.IDCIRCUNSCRIPCION
                ));
        }

        public bool Inscripcion()
        {
            return new Datos().OperarDatos(string.Format("CALL `PR_PARTICIPANTE_INSCRIPCION`('{0}', '{1}', '{2}');", EVENTO, USUARIO.IDUSUARIO, TIPO_PARTICIPANTE.IDTIPO_PARTICIPANTE));
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


        public ParticipanteModel ConsultarValidar(string evento, UsuarioModel user)
        {
            DataTable consulta = new Datos().ConsultarDatos(string.Format("CALL `PR_PARTICIPANTE_VALIDAR`('{0}', '{1}')", evento, user.IDUSUARIO));

            if (consulta.Rows.Count != 0)
            {
                return new ParticipanteModel(
                    consulta.Rows[0]["IDPARTICIPANTE"].ToString(),
                    evento,
                    user,
                    consulta.Rows[0]["PART_IDTIPO_PARTICIPANTE"].ToString(),
                    consulta.Rows[0]["PART_CERTIFICADO"].ToString()
                    );
            }
            else
            {
                return new ParticipanteModel();
            }

        }

        public DataTable ConsultarParticipantes(string evento, string tipo_participante)
        {
            return new Datos().ConsultarDatos("CALL `PR_PARTICIPANTE_CONSULTAR_EVENTO`('" + evento + "', '" + tipo_participante + "')");
        }

        public DataTable ConsultarParticipantes(string evento)
        {
            return new Datos().ConsultarDatos("CALL `PR_PARTICIPANTE_CONSULTAR_EVENTOS`('" + evento + "')");
        }

        public DataTable ConsultarParticipanteInscripcion(string evento, string inscripcion)
        {
            return new Datos().ConsultarDatos("CALL PR_PARTICIPANTE_CONSULTAR_INSCIRPCION('" + evento + "', '" + inscripcion + "')");
        }
        public DataTable ConsultarParticipanteCurso(string participante)
        {
            return new Datos().ConsultarDatos("CALL `PR_CURSO_SELECCION`('" + participante + "')");
        }

        public DataTable ConsultarParticipanteCurso()
        {
            return new Datos().ConsultarDatos("CALL `PR_CURSO_SELECCIONAR_G`()");
        }
    }
}