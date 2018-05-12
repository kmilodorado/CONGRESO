using Eventos.Modelo.Clases;
using Eventos.Models.Complemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Publico
{
    public partial class RegistrarView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDL_TIPO_DOC.DataSource = new Tipo_IdentificacionModel().Consultar();
                DDL_TIPO_DOC.DataTextField = "TIPO_DETALLE";
                DDL_TIPO_DOC.DataValueField = "ID";
                DDL_TIPO_DOC.DataBind();

                DDL_DEPARTAMENTO.DataSource = new MunicipioModel().ConsultarDepartamento();
                DDL_DEPARTAMENTO.DataTextField = "DEPA_NOMBRE";
                DDL_DEPARTAMENTO.DataValueField = "IDDEPARTAMENTO";
                DDL_DEPARTAMENTO.DataBind();

                DDL_FORMACION.DataSource = new FormacionModel().Consultar();
                DDL_FORMACION.DataTextField = "FORM_DETALLE";
                DDL_FORMACION.DataValueField = "ID";
                DDL_FORMACION.DataBind();

                DDL_OCUPACION.DataSource = new OcupacionModel().Consultar();
                DDL_OCUPACION.DataTextField = "OCUP_DETALLE";
                DDL_OCUPACION.DataValueField = "ID";
                DDL_OCUPACION.DataBind();

                DDL_PARTICIPACION.DataSource = new Tipo_ParticipanteModel().Consultar();
                DDL_PARTICIPACION.DataTextField = "TIPO_DETALLE";
                DDL_PARTICIPACION.DataValueField = "ID";
                DDL_PARTICIPACION.DataBind();

                if (Request.QueryString["alert"] != null)
                {
                    AlertaModel AR = new AlertaModel(Request.QueryString["alert"]);
                    Alerta.Visible = AR.VISIBLE;
                    Alerta.CssClass = AR.ESTILO;
                    Alert.Text = AR.MENSAJE;
                    Afirm.InnerHtml = AR.AFIRMACION;
                }
            }

        }

        protected void DDL_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_MUNICIPIO.DataSource = new MunicipioModel().ConsultarMunicipio(DDL_DEPARTAMENTO.Text);
            DDL_MUNICIPIO.DataTextField = "MUNI_NOMBRE";
            DDL_MUNICIPIO.DataValueField = "IDMUNICIPIO";
            DDL_MUNICIPIO.DataBind();
        }


        protected void Registrar_Click(object sender, EventArgs e)
        {
            EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
            if (EVEN != null)
            {
                if (DDL_TIPO_DOC.Text != "" && DDL_OCUPACION.Text != "" && DDL_FORMACION.Text != "" && DDL_MUNICIPIO.Text != "" && DDL_PARTICIPACION.Text != "")
                {
                    UsuarioModel usu = new UsuarioModel().ConsultarUserIdentificacion(TXT_IDENTIFICACION.Text);
                    if (usu.IDUSUARIO == "")
                    {
                        usu.IDENTIFICACION = TXT_IDENTIFICACION.Text;
                        usu.TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION = DDL_TIPO_DOC.SelectedValue;
                        usu.NOMBRE = TXT_NOMBRE.Text;
                        usu.APELLIDO = TXT_APELLIDO.Text;
                        usu.CORREO = TXT_CORREO.Text;
                        usu.CELULAR = TXT_CELULAR.Text;
                        usu.MUNICIPIO.IDMUNICIPIO = DDL_MUNICIPIO.SelectedValue;
                        usu.DIRECCION = TXT_DIRECCION.Text;
                        usu.INSTITUCION = TXT_INSTITUCION.Text;
                        usu.FORMACION.IDFORMACION = DDL_FORMACION.SelectedValue;
                        usu.OCUPACION.IDOCUPACION = DDL_OCUPACION.SelectedValue;
                        usu.USERNAME = TXT_USER.Text;
                        usu.PASS = TXT_PASS.Text;
                        usu.ROL.IDROL = "2";
                        if (new ParticipanteModel(EVEN.IDEVENTO, usu, DDL_PARTICIPACION.Text, "N").Registrar())
                        {
                            CorreoEvento CORREO = new CorreoEvento();

                            if (CORREO.EnviarCorreo(TXT_CORREO.Text, "ensayo", "exitoso", EVEN))
                            {
                                Response.Redirect("RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 1);
                            }
                            else
                            {
                                Response.Redirect("RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 3);
                            }
                        }
                        else
                        {
                            Response.Redirect("RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 2);
                        }
                    }
                    else
                    {
                        //Ya existe la persona

                    }
                }
                else
                {
                    Response.Redirect("RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 4);
                }

            }
            else
            {

            }
        }
    }
}