using Eventos.Modelo.Clases;
using Eventos.Models.Complemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class PagPublicMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PARTICIPANTE"] != null)
            {
                ParticipanteModel PART = (ParticipanteModel)Session["PARTICIPANTE"];
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];

                rol.Text = PART.TIPO_PARTICIPANTE.DETALLE;
                salir.HRef = "~/Vistas/Publico/LoginView.aspx?Evento=" + EVEN.SIGLAS;
                salir2.HRef = "~/Vistas/Publico/LoginView.aspx?Evento=" + EVEN.SIGLAS;
                //salir.HRef = "~/Vistas/Publico/EventosView.aspx?Evento=CacaoTics";
                HyperLink3.NavigateUrl = Request.Path.Split('/')[4];
                HyperLink3.Text = Request.Path.Split('/')[4];

                Repeater1.DataSource = new MenuModel().ConsultarPermiso_Navegacion("PARTICIPANTE", PART.TIPO_PARTICIPANTE.IDTIPO_PARTICIPANTE);
                Repeater1.DataBind();

                if (Request.QueryString["alert"] != null)
                {
                    AlertaModel AR = new AlertaModel(Request.QueryString["alert"]);
                    Alerta.Visible = AR.VISIBLE;
                    Alerta.CssClass = AR.ESTILO;
                    Alert.Text = AR.MENSAJE;
                    Afirm.InnerHtml = AR.AFIRMACION;
                }
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }
    }
}