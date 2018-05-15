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
    public partial class LoginView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["alert"] != null)
            {
                AlertaModel AR = new AlertaModel(Request.QueryString["alert"]);
                Alerta.Visible = AR.VISIBLE;
                Alerta.CssClass = AR.ESTILO;
                Alert.Text = AR.MENSAJE;
                Afirm.InnerHtml = AR.AFIRMACION;
            }
        }

        protected void BTN_INGRESAR_Click(object sender, EventArgs e)
        {
            EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
            if (EVEN != null)
            {
                UsuarioModel USU = new UsuarioModel().Validar(TXT_USER.Text, TXT_PASS.Text);
                if (USU.IDUSUARIO != "")
                {
                    switch (USU.ROL.IDROL)
                    {
                        case "1":
                            Response.Redirect("~/Vistas/Publico/LoginPrivateView.aspx");
                            break;
                        case "2":
                            ParticipanteModel PART = new ParticipanteModel().ConsultarValidar(EVEN.IDEVENTO,USU);

                            if (PART.IDPARTICIPANTE!="")
                            {
                                Session["PARTICIPANTE"] = PART;
                                Response.Redirect("~/Vistas/Privado/Usuario/PrincipalView.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 6);
                            }
                            break;
                    }
                }
                else
                {
                    Response.Redirect("~/Vistas/Publico/LoginView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 5);
                }
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }
    }
}