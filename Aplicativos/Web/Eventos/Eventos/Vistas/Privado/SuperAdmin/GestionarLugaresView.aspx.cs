using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarLugaresView : System.Web.UI.Page
    {
        EventoModel EVEN = new EventoModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] !=null||Request.QueryString["Eliminar"]!=null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        EVEN = new EventoModel().Consultar(Request.QueryString["id"]);
                        Titulo.Text = EVEN.NOMBRE;
                        Session["EVENTO_ADMIN"] = EVEN;
                        if (!IsPostBack)
                        {
                            DDL_LUGAR.DataSource = new LugarModel().Consultar();
                            DDL_LUGAR.DataTextField = "NOMBRE";
                            DDL_LUGAR.DataValueField = "IDLUGAR";
                            DDL_LUGAR.DataBind();
                        }
                        Repeater2.DataSource = new LugarModel().ConsultarEvento(EVEN.IDEVENTO);
                        Repeater2.DataBind();
                    }

                    if (Request.QueryString["Eliminar"] != null)
                    {
                        EVEN = (EventoModel)Session["EVENTO_ADMIN"];
                        if (new LugarModel().EliminarLugares(EVEN.IDEVENTO, Request.QueryString["Eliminar"]))
                        {
                            Response.Redirect("GestionarLugaresView.aspx?id="+EVEN.IDEVENTO);
                        }
                        else
                        {
                            Response.Redirect("GestionarLugaresView.aspx?id=" + EVEN.IDEVENTO);
                        }
                    }
                }
                else
                {
                    Response.Redirect("PrincipalView.aspx");
                }
               
            }
            catch
            {
                Response.Redirect("PrincipalView.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EVEN = (EventoModel)Session["EVENTO_ADMIN"];
            LugarModel lu = new LugarModel();
            if (lu.ValidarEvento(EVEN.IDEVENTO, DDL_LUGAR.SelectedValue).Rows.Count == 0)
            {
                if (lu.RegistrarLugares(EVEN.IDEVENTO, DDL_LUGAR.Text))
                {
                    Response.Redirect("GestionarLugaresView.aspx?id=" + EVEN.IDEVENTO);
                }
                else
                {
                    //Error en el registro
                }
            }
            else
            {
                //Error ya existe agregado este lugar
            }


        }

    }
}