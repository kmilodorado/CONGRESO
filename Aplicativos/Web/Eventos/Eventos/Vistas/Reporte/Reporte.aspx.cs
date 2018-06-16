using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Reporte
{
    public partial class Reporte : System.Web.UI.Page
    {
        public DataTable consulta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["report"]!=null)
            {
                consulta = (DataTable)Session["report"];
            }
        }
    }
}