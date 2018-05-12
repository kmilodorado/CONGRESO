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
        EventoModel EVEN = new EventoModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    EVEN = new EventoModel().Consultar(Request.QueryString["id"]);
                    Session["EVENTO_ADMIN"]= EVEN;
                    Titulo.Text = EVEN.NOMBRE;
                    Repeater1.DataSource = new ParticipanteModel().ConsultarParticipantes(EVEN.IDEVENTO,"6");
                    Repeater1.DataBind();
                }
                catch
                {
                    Response.Redirect("PrincipalView.aspx");
                }
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
            try
            {
                EVEN = (EventoModel)Session["EVENTO_ADMIN"];
                UsuarioModel usu = new UsuarioModel();
                if (BTN_REGISTRAR.Text=="Registrar")
                {
                    usu.IDENTIFICACION = TXT_IDENTIFICACION.Text;
                    usu.TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION = DDL_TIPO_DOCUMENTO.SelectedValue;
                    usu.NOMBRE = TXT_NOMBRE.Text;
                    usu.APELLIDO = TXT_APELLIDO.Text;
                    usu.CORREO = TXT_CORREO.Text;
                    usu.CELULAR = TXT_CELULAR.Text;
                    usu.MUNICIPIO.IDMUNICIPIO = DDL_MUNICIPIO.SelectedValue;
                    usu.DIRECCION = TXT_DIRECCION.Text;
                    usu.INSTITUCION = TXT_INSTITUCION.Text;
                    usu.FORMACION.IDFORMACION = DDL_FORMACION.SelectedValue;
                    usu.OCUPACION.IDOCUPACION = DDL_OCUPACION.SelectedValue;
                    usu.USERNAME = TXT_USUARIO.Text;
                    usu.PASS = TXT_PASS.Text;
                    usu.ROL.IDROL = "2";

                    if (new ParticipanteModel(EVEN.IDEVENTO, usu, "6", "N").Registrar())
                    {
                        //Datos registrados Exitoriamente
                    }
                    else
                    {
                        //Error en el registro del participante
                    }
                }
                else
                {
                    usu = usu.ConsultarUserIdentificacion(TXT_CONSULTAR.Text);
                    if (new ParticipanteModel(EVEN.IDEVENTO, usu, "6", "N").Inscripcion())
                    {
                        //Datos registrados Exitoriamente
                    }
                    else
                    {
                        //Error en el registro del participante
                    }

                }
                Response.Redirect("GestionarResponsableView.aspx?id=" + EVEN.IDEVENTO);
            }
            catch
            {
                //Error en el ingreso de los datos
            }

        }

        protected void TXT_IDENTIFICACION_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UsuarioModel per = new UsuarioModel().ConsultarUserIdentificacion(TXT_CONSULTAR.Text);
                TXT_IDENTIFICACION.Text = per.IDENTIFICACION;
                TXT_IDENTIFICACION.ReadOnly = true;
                DDL_TIPO_DOCUMENTO.SelectedValue = per.TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION;
                TXT_NOMBRE.Text = per.NOMBRE;
                TXT_NOMBRE.ReadOnly = true;
                TXT_APELLIDO.Text = per.APELLIDO;
                TXT_APELLIDO.ReadOnly = true;
                TXT_CORREO.Text = per.CORREO;
                TXT_CORREO.ReadOnly = true;
                TXT_CELULAR.Text = per.CELULAR;
                TXT_CELULAR.ReadOnly = true;
                TXT_DIRECCION.Text = per.DIRECCION;
                TXT_DIRECCION.ReadOnly = true;
                TXT_INSTITUCION.Text = per.INSTITUCION;
                TXT_INSTITUCION.ReadOnly = true;
                DDL_FORMACION.SelectedValue = per.FORMACION.IDFORMACION;
                DDL_OCUPACION.SelectedValue = per.OCUPACION.IDOCUPACION;
                TXT_USUARIO.Text = per.USERNAME;
                TXT_USUARIO.ReadOnly = true;
                BTN_REGISTRAR.Text = "Agregar Responsable";
            }
            catch
            {
                Label1.Text = "La consulta no encontro resultado";
            }

        }
    }
}