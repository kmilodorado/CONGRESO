using Eventos.Modelo.Clases;
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
            Response.Write("<script>demo.showNotification('bottom','center');</script>");
        }

        protected void BTN_INGRESAR_Click(object sender, EventArgs e)
        {
            UsuarioModel USU = new UsuarioModel().Validar(TXTUSUARIO.Text,TXTPASS.Text);
            if (USU.IDUSUARIO=="")
            {
                Response.Redirect("../Privado/SuperAdmin/PrincipalView.aspx");
            }
            else
            {

            }
        }
    }
}