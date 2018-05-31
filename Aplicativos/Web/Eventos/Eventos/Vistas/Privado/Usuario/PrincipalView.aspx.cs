using Eventos.Modelo.Clases;
using Eventos.Models.Complemento;
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

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class PrincipalView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ParticipanteModel PART = (ParticipanteModel)Session["PARTICIPANTE"];
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];

                titulo_evento.InnerHtml =EVEN.NOMBRE;
                Label2.Text = PART.USUARIO.NOMBRE+" " + PART.USUARIO.APELLIDO;
                Label1.Text = PART.TIPO_PARTICIPANTE.DETALLE;
                Image1.ImageUrl = "~/Imagen/Codigo/"+PART.USUARIO.USERNAME+".jpg";

            }
            catch
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
           


            //DataTable consulta = new ParticipanteModel().ConsultarParticipantes("1");
            //for (int i = 0; i < consulta.Rows.Count; i++)
            //{
            //    this.getQRCode(consulta.Rows[i]["USUA_USERNAME"].ToString());
            //}
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


            string path = Server.MapPath("~/Imagen/Codigo/" + code + ".jpg");
            if (!File.Exists(path))
            {
                imagen.Save(path, ImageFormat.Jpeg);
            }
            byte[] result = imageToByteArray(imagen);
            return result;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}