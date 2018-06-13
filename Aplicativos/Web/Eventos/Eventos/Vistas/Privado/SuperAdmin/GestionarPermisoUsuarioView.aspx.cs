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
                datatables.DataSource = new MenuModel().ConsultarTipo("USUARIO"); ;
                datatables.DataBind();
            }
        }


        protected void DDL_ROL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Iterate through the Products.Rows property
            foreach (GridViewRow row in datatables.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("CB_SELECIONAR");
                if (cb != null)
                {
                    if (new MenuModel().ConsultarPermiso("USUARIO", DDL_ROL.Text, row.Cells[1].Text).Rows.Count != 0)
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Checked = false;
                    }
                }
            }
        }

        protected void CB_SELECIONAR_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            new MenuModel().GestionarPermiso("USUARIO", CB.Text, DDL_ROL.Text, CB.Checked);
        }

    }
}