using Eventos.Models.Complemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class PagPrivateMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink3.NavigateUrl = Request.Path.Split('/')[4];
            HyperLink3.Text = Request.Path.Split('/')[4];
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
}