using Eventos.Models.Complemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Reporte
{
    public partial class EnviarCorreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new CorreoEvento().EnviarCorreoWorkShop(new Modelo.Clases.EventoModel().Consultar("1"), new Modelo.Clases.UsuarioModel().ConsultarUserIdentificacion("1022404089"));
        }
    }
}