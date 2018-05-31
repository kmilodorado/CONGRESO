using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class ParticipanteView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EVENTO_PUBLIC"] != null)
            {
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                Repeater1.DataSource = new ParticipanteModel().ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "1");
                Repeater1.DataBind();
                Repeater2.DataSource = new ParticipanteModel().ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "2");
                Repeater2.DataBind();
                Repeater3.DataSource = new ParticipanteModel().ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "3");
                Repeater3.DataBind();
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
           
        }
    }
}