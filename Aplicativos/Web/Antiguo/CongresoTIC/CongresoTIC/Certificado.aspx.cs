using CongresoTIC.Models;
using CongresoTIC.Views.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC
{
    public partial class Certificado : System.Web.UI.Page
    {
        persona pers = new persona();
        Security sec = new Security();

        usuario user = new usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Resultados.Visible = true;
                string cedula = TFCedula.Text;
                if (!String.IsNullOrEmpty(cedula))
                {
                    persona m = new persona();
                    m.idpersona = Convert.ToInt64(cedula);
                    DataTable datos = pers.get_persona_bycedula(m);

                    if (datos.Rows.Count > 0)
                    {
                        DataRow row = datos.Rows[0];

                        if (row["Encuesta"].ToString().Equals("T"))
                        {
                            BEncuesta.Visible = false;
                            Resultados.CssClass = "alert alert-success";
                            LResultado.Text = "Nombre: " + row["Nombres"].ToString() + " " + row["Apellidos"].ToString() + " | ROL: " + row["NombreTipoPart"].ToString();

                            user.idusuario = Convert.ToInt32(row["idUsuario"].ToString());
                            DataTable dt = user.consultar_persona(user);
                            ReportForm.dtGral = dt;
                            ReportForm.titulo = "CERTIFICADO - SIMPOSIO INTERNACIONAL DE INVESTIGACIÓN";
                            Response.Redirect("Views/Home/ReportForm.aspx?current=4");
                        }
                        else
                        {
                            BEncuesta.Visible = true;
                            Resultados.CssClass = "alert alert-danger";
                            LResultado.Text = "Para generar su certificado, le solicitamos comedidamente diligenciar una encuesta para evaluar la organización y el desarrollo del evento.";
                        }
                    }
                    else
                    {
                        BEncuesta.Visible = false;
                        Resultados.CssClass = "alert alert-danger";
                        LResultado.Text = "No se ha encontrado un participante con el número de identificación digitado";
                    }

                }
            }
            catch (Exception ex) { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TFCedula.Text))
                {
                    string token = sec.Encripta(TFCedula.Text);
                    Response.Redirect("Encuesta.aspx?current=" + token);
                }
            }
            catch (Exception) { }
        }
    }
}