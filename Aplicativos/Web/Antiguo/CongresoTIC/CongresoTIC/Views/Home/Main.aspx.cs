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

namespace CongresoTIC.Views.Home
{
    public partial class Main : System.Web.UI.Page
    {

        recibo_pago recibo = new recibo_pago();
        recibopagoController reciboc = new recibopagoController();
        participacionController pc = new participacionController();

        usuario user = new usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());

                    DataTable dt = pc.get_participacion_persona(user);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
                        if (row["EstadoPart"].ToString().Equals("T"))
                        {
                            Result.Text = "";
                            PResult.Visible = false;
                            DataTable g = user.consultar_persona(user);
                            if (g.Rows.Count > 0)
                            {
                                this.getQRCode(g.Rows[0]["idPersona"].ToString());

                                //this.getQRCode("0123456789");
                            }
                        }
                        else
                        {
                            Result.Text = "No se ha generado tu código QR debido a que no te encuentras en estado ACTIVO";
                            Image2.ImageUrl = "../../public/assets/images/fondo/Logo.jpg";
                            PResult.Visible = true;
                        }
                        LPart.Text = row["NombreTipoPart"].ToString();

                        if (!row["EstadoPart"].ToString().Equals("T"))
                        {
                            Notif.Visible = true;
                        }
                        else
                        {
                            Notif.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex) { }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public byte[] getQRCode(string code)
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
            Image2.ImageUrl = "../../QR/" + code + ".png";

            byte[] result = imageToByteArray(imagen);
            return result;
        }
    }
}