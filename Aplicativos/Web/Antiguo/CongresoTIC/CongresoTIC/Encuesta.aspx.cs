using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC
{
    public partial class Encuesta : System.Web.UI.Page
    {
        persona pers = new persona();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Security sec = new Security();
                string encrypt = Request.QueryString["current"].ToString().Replace(" ","+").ToString();

                if (!String.IsNullOrEmpty(encrypt))
                {
                    string cedula = sec.Desencripta(encrypt);
                    this.verEncuesta(cedula);
                    panelencuesta.Visible = true;
                }
                else
                {
                    panelencuesta.Visible = false;
                    Resultados.CssClass = "alert alert-danger";
                    Resultados.Visible = true;
                    LResultado.Text = "No se ha podido identificar la persona que va a diligenciar la encuesta. Por favor ingrese nuevamente al enlace que fue enviado a su correo electrónico.";
                }
                

            }
            catch (Exception ex)
            {
                panelencuesta.Visible = false;
                Resultados.CssClass = "alert alert-danger";
                Resultados.Visible = true;
                LResultado.Text = "Ha ocurrido un error: No ha sido encontrado el código de la persona. Por favor ingrese al enlace que fue enviado a su correo electrónico.";
            }
        }

        public void getPersona(string cedula)
        {
            try
            {
                persona obj = new persona();
                obj.idpersona = Convert.ToInt64(cedula);
                DataTable dt = pers.get_persona_bycedula(obj);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "Asistente: " + cedula + " - " + dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                }
                else
                {
                    panelencuesta.Visible = false;
                    Resultados.CssClass = "alert alert-danger";
                    Resultados.Visible = true;
                    LResultado.Text = "No se ha identificado la persona para diligenciar la encuesta. Por favor ingrese nuevamente al enlace que fue enviado a su correo electrónico.";
                }

            }
            catch (Exception) { }
        }

        public bool verEncuesta(string cedula)
        {
            try
            {
                this.getPersona(cedula);
            }
            catch (Exception) { }
            return pers.ver_encuesta(cedula);
        }
    }
}