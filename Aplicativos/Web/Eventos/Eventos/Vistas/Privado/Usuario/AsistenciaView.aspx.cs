using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class AsistenciaView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EVENTO_PUBLIC"] != null)
            {
                ParticipanteModel PART = new ParticipanteModel();
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                Repeater1.DataSource = new AsistenciaModel().ConsultarAsistencia(EVEN.IDEVENTO);
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }
    }
}