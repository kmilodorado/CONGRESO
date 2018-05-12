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
    public partial class PagPublic : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EventoModel EVE = new EventoModel().ConsultarSiglas(Request.QueryString["Evento"]);
                titulo.Text = EVE.NOMBRE;
                if (EVE.LOGO!="")
                {
                    icono.ResolveUrl("../../Imagen/Evento/" + EVE.LOGO);
                }
                Evento.InnerHtml =EVE.NOMBRE;
                login.HRef = "LoginView.aspx?Evento="+EVE.SIGLAS;
                inscribir.HRef = "RegistrarView.aspx?Evento=" + EVE.SIGLAS;
                programa.HRef = "ProgramaView.aspx?Evento=" + EVE.SIGLAS;
                Session["EVENTO_PUBLIC"] = EVE;
            }
            catch 
            {
                Response.Redirect("EventosView.aspx");
            }
            
        }
    }
}