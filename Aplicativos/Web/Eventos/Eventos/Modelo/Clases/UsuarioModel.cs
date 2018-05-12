using Eventos.AccesoDatos.Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eventos.Modelo.Clases
{
    public class UsuarioModel : PersonaModel
    {
        public string IDUSUARIO { get; set; }
        public string USERNAME { get; set; }
        public string PASS { get; set; }
        public string ESTADO { get; set; }
        public RolModel ROL { get; set; }

        public UsuarioModel()
            : base()
        {
            IDUSUARIO = "";
            USERNAME = "";
            ESTADO = "";
            ROL = new RolModel();
        }

        public UsuarioModel(string id, string usuario, string estado, string rol, string idpersona)
            : base(idpersona)
        {
            IDUSUARIO = id;
            USERNAME = usuario;
            ESTADO = estado;
            ROL = new RolModel().Consultar(rol);
        }

        public bool RegistrarUsuario()
        {
            return new Datos().OperarDatos("");
        }

        public bool ModificarUsuario(UsuarioModel obj)
        {
            return new Datos().OperarDatos("");
        }

        public UsuarioModel ConsultarUsuario(string id)
        {
            try
            {
                DataTable consulta = new Datos().ConsultarDatos("CALL `PR_USUARIO_CONSULTAR_ID`('" + id + "')");
                return new UsuarioModel(
                    consulta.Rows[0]["IDUSUARIO"].ToString(),
                    consulta.Rows[0]["USUA_USERNAME"].ToString(),
                    consulta.Rows[0]["USUA_ESTADO"].ToString(),
                    consulta.Rows[0]["USUA_IDPERSONA"].ToString(),
                    consulta.Rows[0]["USUA_IDROL"].ToString());
            }
            catch
            {
                return new UsuarioModel();
            }
        }

        public UsuarioModel ConsultarUser(string user)
        {
            try
            {
                DataTable consulta = new Datos().ConsultarDatos("CALL `PR_USUARIO_CONSULTAR_USER`('" + user + "')");
                return new UsuarioModel(
                    consulta.Rows[0]["IDUSUARIO"].ToString(),
                    consulta.Rows[0]["USUA_USERNAME"].ToString(),
                    consulta.Rows[0]["USUA_ESTADO"].ToString(),
                    consulta.Rows[0]["USUA_IDPERSONA"].ToString(),
                    consulta.Rows[0]["USUA_IDROL"].ToString());
            }
            catch
            {
                return new UsuarioModel();
            }
        }

        public UsuarioModel ConsultarUserIdentificacion(string identificacion)
        {
            try
            {
                DataTable consulta = new Datos().ConsultarDatos("CALL `PR_USUARIO_CONSULTAR_IDENTIFICACION`('" + identificacion + "')");
                return new UsuarioModel(
                    consulta.Rows[0]["IDUSUARIO"].ToString(),
                    consulta.Rows[0]["USUA_USERNAME"].ToString(),
                    consulta.Rows[0]["USUA_ESTADO"].ToString(),
                    consulta.Rows[0]["USUA_IDROL"].ToString(),
                    consulta.Rows[0]["USUA_IDPERSONA"].ToString());
            }
            catch
            {
                return new UsuarioModel();
            }

        }
        public UsuarioModel Validar(string user, string pass)
        {

            DataTable consulta = new Datos().ConsultarDatos(string.Format("CALL `PR_USUARIO_VALIDAR`('{0}', '{1}')", user, pass));
            try
            {
                return new UsuarioModel(
                consulta.Rows[0]["IDUSUARIO"].ToString(),
                consulta.Rows[0]["USERNAME"].ToString(),
                consulta.Rows[0]["ESTADO"].ToString(),
                consulta.Rows[0]["USUA_IDROL"].ToString(),
                consulta.Rows[0]["USUA_IDPERSONA"].ToString());
            }
            catch
            {

                return new UsuarioModel();
            }

        }

        public DataTable Consultar()
        {
            return new Datos().ConsultarDatos("");
        }
    }
}