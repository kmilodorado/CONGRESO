using CongresoTIC.Reportes.Forms;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Home
{
    public partial class ReportForm : System.Web.UI.Page
    {
        public static DataTable dtGral;
        public static string titulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int current = Int32.Parse(Request.QueryString["current"].ToString());
                //int current = 2;
                this.generarReporte(current);

            }
            catch (Exception ex)
            {
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
                    break;
                case 3:
                    Inscritos report = new Inscritos();
                    report.SetDataSource(dtGral);
                    //CrystalReportViewer1.ReportSource = report;
                    //CrystalReportViewer1.ShowFirstPage();
                    report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Inscritos_SimposioInternacional");
                    //System.IO.MemoryStream mem = (System.IO.MemoryStream)diploma.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = false;
                    Response.ContentType = "application/pdf";
                    break;
                case 4:
                    Certificados diploma = new Certificados();
                    diploma.SetDataSource(dtGral);
                    //diploma.ExportToDisk(ExportFormatType.PortableDocFormat, path);
                    diploma.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "CertificadoSimposioInternacional");
                    //System.IO.MemoryStream mem = (System.IO.MemoryStream)diploma.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = false;
                    Response.ContentType = "application/pdf";
                    //Response.BinaryWrite(mem.ToArray());


                    //using (var mStream = (MemoryStream)diploma.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
                    //{
                    //    Response.Clear();
                    //    Response.Buffer = true;
                    //    Response.ContentType = "application/pdf";
                    //    Response.BinaryWrite(mStream.ToArray());
                    //}
                    //Response.End();
                    //Response.Buffer = false;
                    //Response.ClearContent();
                    //Response.ClearHeaders();
                    ////sakamos el nombre para el pdf
                    //string NombreExport = "ReportePrueba";        //akamos la path a exportar
                    //                                                                                                                       //le ponemos la extención
                    //NombreExport += ".pdf";
                    ////exportamos a pdf
                    //diploma.ExportToDisk(ExportFormatType.PortableDocFormat, path);
                    //CrystalReportViewer1.ReportSource = diploma;
                    //CrystalReportViewer1.ShowFirstPage();
                    break;
            }
        }
    }
}