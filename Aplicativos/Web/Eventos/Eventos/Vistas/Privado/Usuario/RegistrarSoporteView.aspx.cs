using Eventos.Modelo.Clases;
using Eventos.Models.Complemento;
using Gma.QrCodeNet.Encoding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class RegistrarSoporteView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EVENTO_PUBLIC"] != null)
                {
                    DDL_TIPO_DOC.DataSource = new Tipo_IdentificacionModel().Consultar();
                    DDL_TIPO_DOC.DataTextField = "TIPO_DETALLE";
                    DDL_TIPO_DOC.DataValueField = "ID";
                    DDL_TIPO_DOC.DataBind();
                    DDL_TIPO_DOC.Items.Insert(0, new ListItem("Seleccionar Tipo Identificación", ""));

                    DataTable Consulta = new MunicipioModel().ConsultarPais();
                    DDL_PAIS_NAC.DataSource = Consulta;
                    DDL_PAIS_NAC.DataTextField = "PAIS_NOMBRE";
                    DDL_PAIS_NAC.DataValueField = "IDPAIS";
                    DDL_PAIS_NAC.DataBind();
                    DDL_PAIS_NAC.Items.Insert(0, new ListItem("Seleccionar País Nacimiento", ""));

                    DDL_GENERO.DataSource = new GeneroModel().Consultar();
                    DDL_GENERO.DataTextField = "GENE_DETALLE";
                    DDL_GENERO.DataValueField = "IDGENERO";
                    DDL_GENERO.DataBind();
                    DDL_GENERO.Items.Insert(0, new ListItem("Seleccionar Genero", ""));
                    EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                    Repeater1.DataSource = new ParticipanteModel().ConsultarParticipantes(EVEN.IDEVENTO, "5");
                    Repeater1.DataBind();
                }
                else
                {
                    Response.Redirect("~/Vistas/Publico/EventosView.aspx");
                }
            }

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
            if (EVEN != null)
            {
                UsuarioModel usu = new UsuarioModel().ConsultarUserIdentificacion(TXT_IDENTIFICACION.Text);
                if (DDL_TIPO_DOC.Text != "" && DDL_GENERO.Text != "" && DDL_PAIS_NAC.Text != "")
                {
                    usu.IDENTIFICACION = TXT_IDENTIFICACION.Text;
                    usu.TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION = DDL_TIPO_DOC.SelectedValue;
                    usu.NOMBRE = TXT_NOMBRE.Text;
                    usu.APELLIDO = TXT_APELLIDO.Text;
                    usu.CORREO = TXT_CORREO.Text;
                    usu.CELULAR = TXT_CELULAR.Text;
                    usu.MUNICIPIO_RES.IDMUNICIPIO = "4439";
                    usu.DIRECCION = " ";
                    usu.INSTITUCION = TXT_INSTITUCION.Text;
                    usu.FORMACION.IDFORMACION = "1";
                    usu.OCUPACION.IDOCUPACION = "1";
                    usu.USERNAME = TXT_IDENTIFICACION.Text;
                    usu.PASS = TXT_IDENTIFICACION.Text;
                    usu.GENERO.IDGENERO = DDL_GENERO.Text;
                    usu.FECHA_NAC = DateTime.Parse(TXT_FECHA_NAC.Text);
                    usu.PAIS_NAC = DDL_PAIS_NAC.Text;
                    usu.CONDICION.IDESPECIAL = "1";
                    usu.CIRCUNSCRIPCION.IDCIRCUNSCRIPCION = "1";
                    usu.ROL.IDROL = "2";
                    if (new ParticipanteModel(EVEN.IDEVENTO, usu, "5", "N").Registrar())
                    {
                        Response.Redirect("~/Vistas/Privado/Usuario/RegistrarSoporteView.aspx?alert=" + 1);
                    }
                    else
                    {
                        Response.Redirect("~/Vistas/Privado/Usuario/RegistrarSoporteView.aspx?alert=" + 2);
                    }
                }
                else
                {
                    Response.Redirect("~/Vistas/Privado/Usuario/RegistrarSoporteView.aspx?alert=" + 4);
                }
            }
            else
            {
                Response.Redirect("~/Vistas/Privado/Usuario/EventosView.aspx");
            }
        }

    }
}