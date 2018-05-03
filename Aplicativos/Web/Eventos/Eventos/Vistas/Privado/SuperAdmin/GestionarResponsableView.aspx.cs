using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarResponsableView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Tipo de documento
                DDL_TIPO_DOCUMENTO.DataSource = new Tipo_IdentificacionModel().Consultar();
                DDL_TIPO_DOCUMENTO.DataTextField = "TIPO_DETALLE";
                DDL_TIPO_DOCUMENTO.DataValueField = "ID";
                DDL_TIPO_DOCUMENTO.DataBind();

                //formacion de la persona
                DDL_FORMACION.DataSource = new FormacionModel().Consultar();
                DDL_FORMACION.DataTextField = "FORM_DETALLE";
                DDL_FORMACION.DataValueField = "ID";
                DDL_FORMACION.DataBind();

                //Ocupación
                DDL_OCUPACION.DataSource = new OcupacionModel().Consultar();
                DDL_OCUPACION.DataTextField = "OCUP_DETALLE";
                DDL_OCUPACION.DataValueField = "ID";
                DDL_OCUPACION.DataBind();

                //Departamento
                DDL_DEPARTAMENTO.DataSource = new MunicipioModel().ConsultarDepartamento();
                DDL_DEPARTAMENTO.DataTextField = "DEPA_NOMBRE";
                DDL_DEPARTAMENTO.DataValueField = "IDDEPARTAMENTO";
                DDL_DEPARTAMENTO.DataBind();

            }

        }

        protected void DDL_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_MUNICIPIO.DataSource = new MunicipioModel().ConsultarMunicipio(DDL_DEPARTAMENTO.SelectedValue);
            DDL_MUNICIPIO.DataTextField = "MUNI_NOMBRE";
            DDL_MUNICIPIO.DataValueField = "IDMUNICIPIO";
            DDL_MUNICIPIO.DataBind();

        }

        protected void BTN_REGISTRAR_Click(object sender, EventArgs e)
        {
            if (new PersonaModel().RegistrarPersona())
            {
                if (new UsuarioModel().RegistrarUsuario())
                {

                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}