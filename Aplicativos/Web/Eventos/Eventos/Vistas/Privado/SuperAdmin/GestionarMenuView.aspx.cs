using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarMenuView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = new MenuModel().Consultar();
            Repeater1.DataBind();
        }

        protected void BTN_AGREGAR_Click(object sender, EventArgs e)
        {
            if (new MenuModel(TXT_DETALLE.Text, TXT_URL.Text, TXT_ICONO.Text, DDL_TIPO.Text).Registrar())
            {
                Response.Redirect("~/Vistas/Privado/SuperAdmin/GestionarMenuView.aspx?alert=" + 1);
            }
            else
            {
                Response.Redirect("~/Vistas/Privado/SuperAdmin/GestionarMenuView.aspx?alert=" + 2);
            }
        }
        protected void BTN_ACTUALIZAR_Command(object sender, CommandEventArgs e)
        {
            MenuModel MEN = new MenuModel().Consultar(e.CommandArgument.ToString());
            TXT_ID.Value = MEN.IDMENU;
            TXT_DETALLE_MOD.Value = MEN.NOMBRE;
            TXT_URL_MOD.Value = MEN.URL;
            TXT_ICONO_MOD.Value = MEN.ICONO;
            SEL_TIPO.Value = MEN.TIPO;
            MOD.Style["visibility"] = "visible";

        }

        protected void BTN_ELIMINAR_Command(object sender, CommandEventArgs e)
        {
            if (new MenuModel().Eliminar(e.CommandArgument.ToString()))
            {
                Response.Redirect("~/Vistas/Privado/SuperAdmin/GestionarMenuView.aspx?alert=" + 1);
            }
            else
            {
                Response.Redirect("~/Vistas/Privado/SuperAdmin/GestionarMenuView.aspx?alert=" + 2);
            }
        }

        protected void BTN_ACTUALIZAR_Click(object sender, EventArgs e)
        {
            if (new MenuModel(TXT_ID.Value,TXT_DETALLE_MOD.Value,TXT_URL_MOD.Value,TXT_ICONO_MOD.Value,SEL_TIPO.Value).Modificar())
            {
                Response.Redirect("~/Vistas/Privado/SuperAdmin/GestionarMenuView.aspx?alert=" + 1);
            }
            else
            {
                Response.Redirect("~/Vistas/Privado/SuperAdmin/GestionarMenuView.aspx?alert=" + 2);
            }
        }

        protected void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            MOD.Style["visibility"] = "hidden";
        }
    }
}