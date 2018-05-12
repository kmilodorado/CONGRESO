using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Publico
{
    public partial class EventosView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = new EventoModel().Consultar();
            Repeater1.DataBind();
        }
    }
}