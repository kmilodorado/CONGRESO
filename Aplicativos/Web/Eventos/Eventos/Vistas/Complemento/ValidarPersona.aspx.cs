using Eventos.Modelo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Complemento
{
    public partial class ValidarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]!=null)
            {
                UsuarioModel USU = new UsuarioModel().ConsultarUserIdentificacion(Request.QueryString["id"]);
                if (USU.IDENTIFICACION!="")
                {
                    Response.Write("true,"+USU.IDENTIFICACION+"," + USU.NOMBRE + "," + USU.APELLIDO + "," + USU.CORREO + "," + USU.CELULAR + "," + USU.DIRECCION + "," + USU.INSTITUCION + "," + USU.USERNAME + "," + USU.FECHA_NAC);
                }
                else
                {
                    Response.Write("false,no existe");
                }
            }
            else
            {
                Response.Write("false,no existe");
            }
        }
    }
}