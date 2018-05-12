using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarTiposView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datatable.DataSource = new Tipo_CostoModel().Consultar();
            datatable.DataBind();
        }

        protected void DDL_TIPO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTN_REGISTRAR_Click(object sender, EventArgs e)
        {

        }

        protected void datatable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}