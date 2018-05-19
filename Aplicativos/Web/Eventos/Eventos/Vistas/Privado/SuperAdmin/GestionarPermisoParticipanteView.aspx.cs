using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarPermisoParticipanteView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDL_PARTICIPANTE.DataSource = new Tipo_ParticipanteModel().Consultar();
                DDL_PARTICIPANTE.DataTextField = "TIPO_DETALLE";
                DDL_PARTICIPANTE.DataValueField = "ID";
                DDL_PARTICIPANTE.DataBind();
                datatables.DataSource = new MenuModel().ConsultarTipo("PARTICIPANTE");
                datatables.DataBind();
            }
        }

        protected void CB_SELECIONAR_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            string accion = "FALSE";
            if (CB.Checked)
            {
                accion = "TRUE";
            }
            new MenuModel().GestionarPermiso("PARTICIPANTE", CB.Text, DDL_PARTICIPANTE.Text, accion);
        }

        protected void DDL_PARTICIPANTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Iterate through the Products.Rows property
            foreach (GridViewRow row in datatables.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("CB_SELECIONAR");
                if (cb != null)
                {
                    if (new MenuModel().ConsultarPermiso("PARTICIPANTE", DDL_PARTICIPANTE.Text, row.Cells[1].Text).Rows.Count != 0)
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
    }
}