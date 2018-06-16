using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class ParticipanteView : System.Web.UI.Page
    {

        public DataTable CONSULTA;
        public DataTable GENERAL = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {  
            if (Session["EVENTO_PUBLIC"] != null)
            {
                ParticipanteModel PART = new ParticipanteModel();
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                GENERAL = PART.ConsultarParticipanteCurso();
                Repeater1.DataSource = PART.ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "1");
                Repeater1.DataBind();
                Repeater2.DataSource = PART.ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "2");
                Repeater2.DataBind();
                Repeater3.DataSource = PART.ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "3");
                Repeater3.DataBind();
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }

        }

        public DataTable Cursos(string participante)
        {
            DataTable aux = new DataTable();
            try
            {
                var query =from order in GENERAL.AsEnumerable()
                                           where order.Field<Int32>("SELE_IDPARTICIPANTE") == Convert.ToInt32(participante)
                                           select order;
                aux = GENERAL.Clone();
                query.CopyToDataTable(aux, LoadOption.PreserveChanges);
            }
            catch (Exception io)
            {
                //Response.Write("<script>openInfo3('Revise su conexión a internet',1);</script>");
                ScriptManager.RegisterStartupScript(Page, GetType(), "key", "openInfo3('Revise su conexión a internet',1);", true);
            }
            return aux;
        }

        protected void Reporte_Click(object sender, EventArgs e)
        {
            if (Session["EVENTO_PUBLIC"] != null)
            {
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                Session["report"] = new ParticipanteModel().ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "1");
                Response.Redirect("~/Vistas/Reporte/Reporte.aspx");
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["EVENTO_PUBLIC"] != null)
            {
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                Session["report"] = new ParticipanteModel().ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "2");
                Response.Redirect("~/Vistas/Reporte/Reporte.aspx");
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["EVENTO_PUBLIC"] != null)
            {
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                Session["report"] = new ParticipanteModel().ConsultarParticipanteInscripcion(EVEN.IDEVENTO, "3");
                Response.Redirect("~/Vistas/Reporte/Reporte.aspx");
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }
    }
}