using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CongresoTIC.Reportes.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.WebControls;
using LabelKit;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using CrystalDecisions.Shared;

namespace CongresoTIC.Views.Evento
{
    public partial class Generar : System.Web.UI.Page
    {
        subitem sub = new subitem();
        persona us = new persona();
        participacionController pc = new participacionController();
        public static bool all = false;
        public static string cedulas = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cedulas = Request.QueryString["current"].ToString();
                //int current = Int32.Parse(Request.QueryString["current"].ToString());
                this.generarReporte(1);

            }
            catch (Exception ex)
            {
                //Response.Redirect("../../Login.aspx");
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public void generarReporte(int current)
        {
            //DataTableReport data = new DataTableReport();
            switch (current)
            {
                case 1:
                    Escarapelas report = new Escarapelas();
                    report.SetDataSource(this.getEscarapelas().Tables[0]);
                    //CrystalReportViewer1.ReportSource = report;
                    //CrystalReportViewer1.ShowFirstPage();
                    report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Escarapela");
                    //System.IO.MemoryStream mem = (System.IO.MemoryStream)diploma.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = false;
                    Response.ContentType = "application/pdf";
                    break;
            }
        }

        public void generate_code(string id, string text)
        {
            BarcodeGenerator code = new BarcodeGenerator();
            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);
            string path = Server.MapPath("~/bco/" + id + ".png");
            if (!File.Exists(path))
            {
                code.DrawCode128(g, text, 0, 0).Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
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
            byte[] result = imageToByteArray(imagen);
            return result;
        }

        public DataSet getEscarapelas()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable data = new DataTable();
            if (all)
            {
                data = pc.get_activos();
            }
            else
            {
                us.idpersona = 0;
                data = pc.get_activos_uno(us);

                string[] ids = cedulas.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    us.idpersona = Convert.ToInt64(ids[i]);
                    DataTable aux = pc.get_activos_uno(us);
                    if (aux.Rows.Count > 0)
                    {
                        DataRow r = data.NewRow(), r2;
                        r2 = aux.Rows[0];
                        //data.ImportRow(aux.Rows[0]);
                        data.Rows.Add(r2.ItemArray);
                    }
                }
            }

            DataRow dr = null;

            int cont = 1;
            dt.Columns.Add(new DataColumn("Imagen1", typeof(byte[])));
            dt.Columns.Add(new DataColumn("Imagen2", typeof(byte[])));
            dt.Columns.Add(new DataColumn("Nombre1", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre2", typeof(string)));
            dt.Columns.Add(new DataColumn("Rol1", typeof(string)));
            dt.Columns.Add(new DataColumn("Rol2", typeof(string)));
            dt.Columns.Add(new DataColumn("BC1", typeof(byte[])));
            dt.Columns.Add(new DataColumn("BC2", typeof(byte[])));
            dt.Columns.Add(new DataColumn("Data", typeof(byte[])));

            dr = dt.NewRow();
            DataRow f1, f2;
            for (int j = 0; j < data.Rows.Count; j += 2)
            {
                if (j < data.Rows.Count)
                {
                    f1 = data.Rows[j];

                    dr["Nombre1"] = f1["Nombres"].ToString() + " " + f1["Apellidos"].ToString();

                    dr["Rol1"] = f1["NombreTipoPart"].ToString();
                    dr["BC1"] = getQRCode(f1["idPersona"].ToString());

                }
                if (j + 1 < data.Rows.Count)
                {
                    f2 = data.Rows[j + 1];

                    dr["Nombre2"] = f2["Nombres"].ToString() + " " + f2["Apellidos"].ToString();
                    //this.generate_code(f1["idUsuario"].ToString(), f1["idPersona"].ToString());
                    //this.generate_code(f2["idUsuario"].ToString(), f2["idPersona"].ToString());

                    //dr["BC1"] = imageToByteArray(System.Drawing.Image.FromFile(Server.MapPath("~/bco/" + f1["idUsuario"].ToString() + ".png")));
                    //dr["BC2"] = imageToByteArray(System.Drawing.Image.FromFile(Server.MapPath("~/bco/" + f2["idUsuario"].ToString() + ".png")));

                    dr["Rol2"] = f2["NombreTipoPart"].ToString();
                    dr["BC2"] = getQRCode(f2["idPersona"].ToString());


                }
                dt.Rows.Add(dr);
                dr = dt.NewRow();

            }
            ds.Tables.Add(dt);
            return ds;
        }
    }
}