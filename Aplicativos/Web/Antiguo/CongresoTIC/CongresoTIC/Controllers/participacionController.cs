using CongresoTIC.Models;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Http;
namespace CongresoTIC.Controllers
{
    public class participacionController : ApiController
    {
        participacion obj_participacion = new participacion();

        usuario user = new usuario();

        public DataRow[] allparticipacion()
        {
            DataTable dt = obj_participacion.get_participacion();
            DataRow[] rows = null;
            if (dt.Rows.Count > 0)
            {
                rows = new DataRow[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rows[i] = dt.Rows[i];
                }
            }
            return rows;
        }
        public participacion[] data()
        {
            DataTable dt = obj_participacion.get_participacion();
            DataRow row;
            participacion[] participacions = null;
            if (dt.Rows.Count > 0)
            {
                participacions = new participacion[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    participacions[i] = new participacion(Convert.ToInt32(row["idpartic"].ToString()), Convert.ToInt32(row["fk_idtipopart"].ToString()), Convert.ToInt32(row["fk_idevento"].ToString()), Convert.ToInt32(row["fk_idusuario"].ToString()), row["estado"].ToString(), row["fecha"].ToString());
                }
            }
            return participacions;
        }

        public DataTable get_inscritos()
        {
            return obj_participacion.get_inscritos();
        }

        public IHttpActionResult cargar_qr(persona obj)
        {
            this.getQRCode(Convert.ToString(obj.idpersona));

            return Json(new
            {
                data = "Código generado",
                result = true
            });
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

            //string path = Server.MapPath("~/QR/" + code + ".png");
            string path = "";
            if (!File.Exists(path))
            {
                imagen.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

            byte[] result = imageToByteArray(imagen);
            return result;
        }

        public DataTable get_activos()
        {
            return obj_participacion.get_activos();
        }

        public DataTable get_activos_uno(persona p)
        {
            return obj_participacion.get_activos_uno(p);
        }

        public DataTable get_participacion_persona(usuario obj)
        {
            return obj_participacion.get_participacion_persona(obj);
        }

        public IEnumerable<participacion> get_participacion()
        {
            return data();
        }
        public IHttpActionResult get_participacion(int id)
        {
            var obj = data().FirstOrDefault((o) => o.idpartic == id);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public string insert_participacion(participacion obj)
        {
            if (obj_participacion.insert_participacion(obj))
            {
                return "I200";
            }
            else
            {
                return "I500";
            }
        }
        [HttpPost]
        public string update_participacion(participacion obj)
        {
            if (obj_participacion.update_participacion(obj))
            {
                return "U200";
            }
            else
            {
                return "U500";
            }
        }
    }
}
