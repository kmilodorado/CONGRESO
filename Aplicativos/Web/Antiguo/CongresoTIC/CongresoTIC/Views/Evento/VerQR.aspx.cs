using CongresoTIC.Controllers;
using CongresoTIC.Models;
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
    public partial class VerQR : System.Web.UI.Page
    {
        public static DataTable dt = new DataTable();
        public static DataRow row;

        asistencia asi = new asistencia();

        persona per = new persona();
        subitem sub = new subitem();

        personaController pc = new personaController();
        asistenciaController ac = new asistenciaController();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    string id;

                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("7"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            dt = asi.get_asistencias();

                            if (!IsPostBack)
                            {
                                spa.Visible = false;
                            }
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



        protected void Registrar_Click(object sender, EventArgs e)
        {

        }

        public void buscarAsistente(string cedula)
        {
            try
            {
                per.idpersona = Convert.ToInt64(cedula);
                DataTable dta = pc.get_persona_bycedula(per);
                DataRow row;
                string tip = "";
                int h, m;
                if (dta.Rows.Count > 0)
                {
                    row = dta.Rows[0];
                    LName.Text = row["Nombres"].ToString() + " " + row["Apellidos"].ToString();

                    this.getQRCode(row["idPersona"].ToString());

                    //dt.Rows.Add(row["idPersona"].ToString(), row["Nombres"].ToString() + " " + row["Apellidos"].ToString(), asi.fecha, asi.sesion, asi.tipo, state);
                    t_documento.Text = "";

                    spa.Visible = true;
                    LPart.Text = row["NombreTipoPart"].ToString();
                    Cedula.Text = "Identificación: " + row["idPersona"].ToString();
                    Acceso.Text = "Correo: " + row["Correo"].ToString();
                    Estado.Text = "Estado: " + (row["EstadoPart"].ToString().Equals("T") ? "Activo" : "Inactivo");
                    Security sec = new Security();
                    Private.Text = sec.Desencripta(row["Contraseña"].ToString());
                }
                else
                {
                    LName.Text = "Participante no encontrado";
                    t_documento.Text = "";
                    spa.Visible = false;
                    LPart.Text = "";
                    Cedula.Text = "";
                    Acceso.Text = "";
                    Estado.Text = "";
                    QR.ImageUrl = "";
                    Private.Text = "";
                }
                //t_documento.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        public void getQRCode(string code)
        {
            string path = Server.MapPath("~/QR/" + code + ".png");
            if (!File.Exists(path))
            {
                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrCode = new QrCode();
                qrEncoder.TryEncode(code, out qrCode);

                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

                MemoryStream ms = new MemoryStream();

                renderer.WriteToStream(qrCode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
                var imageTemporal = new Bitmap(ms);
                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));

                imagen.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                QR.ImageUrl = "~/QR/" + code + ".png";
            }
            else
            {
                QR.ImageUrl = "~/QR/" + code + ".png";
            }

        }

        protected void t_documento_TextChanged(object sender, EventArgs e)
        {
            buscarAsistente(t_documento.Text);
            //Page_Load(sender, e);
        }
    }
}