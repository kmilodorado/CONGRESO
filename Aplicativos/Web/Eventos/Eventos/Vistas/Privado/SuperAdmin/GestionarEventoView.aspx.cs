using Eventos.Modelo.Clases;
using Eventos.Modelo.Complemento;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.SuperAdmin
{
    public partial class GestionarEventoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DDL_VALOR.DataSource = new Tipo_CostoModel().Consultar();
                DDL_VALOR.DataTextField = "TIPO_DETALLE";
                DDL_VALOR.DataValueField = "ID";
                DDL_VALOR.DataBind();
            }
            catch
            {

            }
        }

        protected void BTN_REGISTRAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (new EventoModel(TXT_NOMBRE.Text, TXT_SIGLAS.Text, FILE_LOGO.PostedFile.FileName, FILE_POSTER.PostedFile.FileName, TXT_CORREO.Text, Metodos.ordenarfecha(TXT_FECHA_INI.Text), Metodos.ordenarfecha(TXT_FECHA_FIN.Text), "HABILITADO", TXT_CUPOS.Text, DDL_VALOR.Text).Registrar())
                {
                    if (FILE_LOGO.PostedFile.FileName != "")
                    {
                        FILE_LOGO.PostedFile.SaveAs(Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "Imagen"), Path.GetFileName(FILE_LOGO.PostedFile.FileName)));
                    }

                    if (FILE_POSTER.PostedFile.FileName != "")
                    {
                        FILE_POSTER.PostedFile.SaveAs(Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "Imagen"), Path.GetFileName(FILE_POSTER.PostedFile.FileName)));
                    }

                    Response.Redirect("GestionarResponsableView.aspx");
                }
                else
                {

                }
            }
            catch
            {

            }

        }
    }

   
}