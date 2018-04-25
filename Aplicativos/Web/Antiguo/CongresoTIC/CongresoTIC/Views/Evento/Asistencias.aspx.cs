using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CrystalDecisions.Shared;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class Asistencias : System.Web.UI.Page
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

                    if (id != null && id.Equals("5"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            dt = asi.get_asistencias();
                            
                            if (!IsPostBack)
                            {
                                spa.Visible = false;
                                //getQR("12214314");
                                //dt = new DataTable();
                                //dt.Columns.Add("ID");
                                //dt.Columns.Add("Estudiante");
                                //dt.Columns.Add("Fecha");
                                //dt.Columns.Add("Sesion");
                                //dt.Columns.Add("Tipo");
                                //dt.Columns.Add("Estado");
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

        public void getQR(string code)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(code, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
            byte[] result = imageToByteArray(imagen);
            //panelResultado.BackgroundImage = imagen;

            // Guardar en el disco duro la imagen (Carpeta del proyecto)
            //imagen.Save("imagen.png", ImageFormat.Png);
            //btnGuardar.Enabled = true;
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public byte[] getQRCode(string code)
        {

            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = qrEncoder.Encode(code);
            byte[] result;


            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            using (FileStream stream = new FileStream(@"c:\temp\HelloWorld.png", FileMode.Create))
            {
                renderer.WriteToStream(qrCode.Matrix, System.Drawing.Imaging.ImageFormat.Png, stream);
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    result = ms.ToArray();
                }
            }
            return result;
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

                    DateTime time = DateTime.Now;

                    asi.fecha = time.ToString("yyyy-MM-dd HH:mm:ss");
                    string Date = time.ToString("yyyy-MM-dd");
                    //asi.fecha = "2016-09-27 16:24:34";
                    asi.fk_idpartic = Convert.ToInt32(row["idPartic"].ToString());
                    asi.estado = "T";
                    asi.idusuario = Session["idUsuario"].ToString();

                    h = Convert.ToInt32(time.ToString("HH"));
                    m = Convert.ToInt32(time.ToString("mm"));

                    asi.sesion = h <= 12 ? "1" : "2";

                    //if ((h >= 7 && h <= 9) || (h >= 14 && h <= 15))
                    //{
                    //    tip = "Entrada";
                    //}
                    //else if ((h >= 11 && h <= 13) || (h >= 17 && h <= 19))
                    //{
                    //    tip = "Salida";
                    //}

                    asi.fecha = Date;
                    DataTable data = asi.get_reg_asistencia(asi);
                    if (data.Rows.Count == 0)
                    {
                        tip = "Entrada";
                    }
                    else
                    {
                        tip = "Salida";
                    }

                    string state;
                    asi.tipo = tip;
                    asi.date = Date;
                    asi.fecha = time.ToString("yyyy-MM-dd HH:mm:ss");
                    if (ac.insert_asistencia(asi))
                    {
                        state = "T";
                    }
                    else
                    {
                        state = "F";
                    }

                    //dt.Rows.Add(row["idPersona"].ToString(), row["Nombres"].ToString() + " " + row["Apellidos"].ToString(), asi.fecha, asi.sesion, asi.tipo, state);
                    t_documento.Text = "";

                    spa.Visible = true;
                    LPart.Text = row["NombreTipoPart"].ToString();
                }
                else
                {
                    LName.Text = "Participante no encontrado";
                    t_documento.Text = "";
                    spa.Visible = false;
                    LPart.Text = "";
                }
                //t_documento.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        protected void t_documento_TextChanged(object sender, EventArgs e)
        {
            buscarAsistente(t_documento.Text);
            Page_Load(sender, e);
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                asi.idasistencia = Convert.ToInt32(idEC.Text);
                if (asi.borrar_asistencia(asi))
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "Operación exitosa";
                }
                else
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "Operación fallida";
                }
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {

            }
        }
    }
}