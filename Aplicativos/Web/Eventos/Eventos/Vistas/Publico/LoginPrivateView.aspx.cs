using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Publico
{
    public partial class LoginPrivateView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_INGRESAR_Click(object sender, EventArgs e)
        {
            UsuarioModel USU = new UsuarioModel().Validar(TXTUSUARIO.Text, TXTPASS.Text);
            if (USU.IDUSUARIO != "")
            {
                if (USU.ROL.IDROL == "1")
                {
                    Session["USUARIO"] = USU;
                    Response.Redirect("~/Vistas/Privado/SuperAdmin/PrincipalView.aspx");
                }
                else
                {
                    Response.Redirect("~/Vistas/Publico/LoginPrivateView.aspx?alert=" + 5);
                }
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/LoginPrivateView.aspx?alert=" + 5);
            }
        }
    }
}