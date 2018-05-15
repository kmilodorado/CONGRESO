using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarPermisoUsuarioView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDL_ROL.DataSource = new RolModel().Consultar();
                DDL_ROL.DataTextField = "ROL_DETALLE";
                DDL_ROL.DataValueField = "IDROL";
                DDL_ROL.DataBind();
                Repeater1.DataSource = new MenuModel().ConsultarPermiso("USUARIO", "0");
                Repeater1.DataBind();
            }
        }

        protected void CB_VALIDACION_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void DDL_ROL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repeater1.DataSource = new MenuModel().ConsultarPermiso("USUARIO", DDL_ROL.Text);
            Repeater1.DataBind();
        }
    }
}