using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CongresoTIC.Views.Home;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class Export : System.Web.UI.Page
    {
        subitem sub = new subitem();
        participacionController pc = new participacionController();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    string id;

                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("2"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {

                        }
                        else
                        {
                            Resultados.Visible = true;
                            Resultados.CssClass = "alert alert-danger";
                            LResultado.Text = "Acceso denegado.";
                        }
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-danger";
                        LResultado.Text = "Acceso denegado.";
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("../../Login.aspx");
            }
        }

        protected void GenerarUno_Click(object sender, EventArgs e)
        {
            try
            {
                Logistica.all = false;
                Logistica.cedulas = t_cedula.Text;

                Response.Redirect("Logistica.aspx?current=2");
            }
            catch (Exception ex)
            {

            }
        }

        protected void GenerarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                Logistica.all = true;
                Logistica.cedulas = "";

                Response.Redirect("Logistica.aspx?current=1");
            }
            catch (Exception ex)
            {

            }
        }



        public void getQRCode(string code)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(code, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));

            string path = Server.MapPath("../../QR/" + code + ".png");
            if (!File.Exists(path))
            {
                imagen.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

        }

        protected void QR_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = pc.get_inscritos();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    this.getQRCode(row["idPersona"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Certificado_Click(object sender, EventArgs e)
        {
            try
            {
                persona per = new persona();

                per.idpersona = Convert.ToInt64(t_documento.Text);
                //user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
                DataTable dt = per.get_persona_bycedula(per);
                ReportForm.dtGral = dt;
                ReportForm.titulo = "CERTIFICADO DE ASISTENCIA AL SIMPOSIO INTERNACIONAL DE INVESTIGACION";
                Response.Redirect("../Home/ReportForm.aspx?current=4");

            }
            catch (Exception ex)
            {

            }
        }
    }
}