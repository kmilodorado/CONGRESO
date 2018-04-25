using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class Correos : System.Web.UI.Page
    {
        persona pers = new persona();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public void enviarCorreos()
        //{
        //    try
        //    {
        //        Security sec = new Security();

        //        int total, cont = 0;

        //        DataTable person = pers.get_persona();
        //        if (person.Rows.Count > 0)
        //        {
        //            total = person.Rows.Count;

        //            for (int i = 0; i < total; i++)
        //            {
        //                DataRow row = person.Rows[i];

        //                long h = Convert.ToInt64(row["idPersona"].ToString());

        //                if (h > 1117233687)
        //                {
        //                    if (!row["Correo"].ToString().StartsWith("logistica") && !row["Correo"].ToString().StartsWith("admin"))
        //                    {

        //                        string token = sec.Encripta(row["idPersona"].ToString());
        //                        string url = "http://giecom.co/simposio/Encuesta.aspx?current=" + token;

        //                        Correo objeto = new Correo(row["Correo"].ToString(), "grupoinvestigacion_giecom@outlook.com", "molina1977");
        //                        string contenido = "<p>Hola <b>" + row["Nombres"].ToString() + " " + row["Apellidos"].ToString() + "</b>." +
        //                            " <br/><br/>Le agradecemos su asistencia y participación en el Simposio Internacional de Investigación - UDLA 2017, que ha sido desarrollado durante los días 1, 2 y 3 de Noviembre de 2017.</b>" +
        //                    "<br/><br/>De manera comedida, le solicitamos expresar sus valoraciones y comentarios respecto a la organización y realización del Simposio, lo cual nos enriquece y hace que cada día seamos mejores. Trate de ser lo más objetivo posible y si es el caso sugiera alternativas de mejoramiento continuo." +
        //                    "<br/><br/>Por favor diligencie la encuesta en el siguiente <a href='" + url + "' target='_blank'>enlace</a>, la cual será tenida en cuenta para la generación de su certificado de asistencia al Simposio." +
        //                    "<br/><br/><br/>Atentamente, <br/>Comité organizador Simposio Internacional</p>";

        //                        if (objeto.enviarCorreosAdjunto("ENCUESTA - SIMPOSIO INTERNACIONAL", contenido, null))
        //                        {
        //                            cont++;
        //                        }
        //                    }
        //                }
        //            }
        //            Resultados.Visible = true;
        //            Resultados.CssClass = "alert alert-success";
        //            LResultado.Text = "Se han enviado " + cont + " correos de un total de " + total;


        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public void enviarCorreos()
        {
            try
            {
                Security sec = new Security();

                int total, cont = 0;

                DataTable person = pers.get_persona();
                if (person.Rows.Count > 0)
                {
                    total = person.Rows.Count;
                    string correos = "";

                    for (int i = 0; i < total; i++)
                    {
                        DataRow row = person.Rows[i];

                        long h = Convert.ToInt64(row["idPersona"].ToString());


                        if (!row["Correo"].ToString().StartsWith("logistica") && !row["Correo"].ToString().StartsWith("admin"))
                        {
                            correos += row["Correo"].ToString() + ",";
                            
                        }

                    }

                    TCorreos.Text = correos; 
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "Se han enviado " + cont + " correos de un total de " + total;


                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                this.enviarCorreos();
            }
            catch (Exception) { }
        }
    }
}