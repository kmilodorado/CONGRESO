using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CongresoTIC.Views.Home;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class Certificado : System.Web.UI.Page
    {
        subitem sub = new subitem();
        personaController pc = new personaController();
        usuarioController uc = new usuarioController();
        usuario user = new usuario();
        participacion part = new participacion();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    string id;

                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("3"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
                            DataTable d = part.get_participacion_persona(user);
                            if (d.Rows.Count > 0)
                            {
                                DataRow f = d.Rows[0];
                                part.idpartic = Convert.ToInt32(f["idPartic"].ToString());
                                DataTable date = part.get_certificados(part);
                                if (date.Rows.Count >= 4)
                                {
                                    Generar.Visible = true;
                                    Resultados.Visible = true;
                                    Resultados.CssClass = "alert alert-success";
                                    LResultado.Text = "¡Muy bien! Se ha registrado tu asistencia al Simposio Internacional de Investigación 2017";
                                }
                                else
                                {
                                    Generar.Visible = false;
                                    Resultados.Visible = true;
                                    Resultados.CssClass = "alert alert-danger";
                                    LResultado.Text = "El certificado no se ha podido generar debido a que no cuentas con el mínimo de asistencia al Simposio Internacional de Investigación. Disculpe las molestias causadas. Si presenta algún inconveniente, por favor comunicarse con el comité organizador";
                                }
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

        //protected void Generar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //string url = "http://200.21.7.94/congreso/#no-back-button";

        //        //string pdf_page_size = "A4";
        //        //PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
        //        //    pdf_page_size, true);

        //        //string pdf_orientation = "Landscape";
        //        //PdfPageOrientation pdfOrientation =
        //        //    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
        //        //    pdf_orientation, true);

        //        //int webPageWidth = 1024;
        //        //try
        //        //{
        //        //    webPageWidth = Convert.ToInt32(600);
        //        //}
        //        //catch { }

        //        //int webPageHeight = 0;
        //        //try
        //        //{
        //        //    webPageHeight = Convert.ToInt32(100);
        //        //}
        //        //catch { }

        //        //// instantiate a html to pdf converter object
        //        //HtmlToPdf converter = new HtmlToPdf();

        //        //// set converter options
        //        //converter.Options.PdfPageSize = pageSize;
        //        //converter.Options.PdfPageOrientation = pdfOrientation;
        //        //converter.Options.WebPageWidth = webPageWidth;
        //        //converter.Options.WebPageHeight = webPageHeight;

        //        //// create a new pdf document converting an url
        //        //PdfDocument doc = converter.ConvertUrl(url);

        //        //// save pdf document
        //        //doc.Save(Response, false, "Sample.pdf");

        //        //// close pdf document
        //        //doc.Close();

        //        //user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
        //        //DataTable dt = user.consultar_persona(user);
        //        //ReportForm.dtGral = dt;
        //        //ReportForm.titulo = "CERTIFICADO DE ASISTENCIA AL CONGRESO TIC";
        //        //Response.Redirect("../Home/ReportForm.aspx?current=4");

        //        using (MemoryStream ms = new MemoryStream())
        //        {

        //            var output = new FileStream(Server.MapPath("../../QR/MyFirstPDF.pdf"), FileMode.Create);

        //            Document doc = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25);
        //            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

        //            doc.AddTitle("Mi primer PDF");
        //            doc.AddCreator("Roberto Torres");

        //            doc.Open();

        //            doc.Add(new Paragraph("Mi primer documento PDF"));
        //            doc.Add(Chunk.NEWLINE);

        //            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

        //            // Creamos una tabla que contendrá el nombre, apellido y país 
        //            // de nuestros visitante.
        //            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Server.MapPath("../../QR/Cert.png"));
        //            imagen.BorderWidth = 0;
        //            imagen.Alignment = Element.ALIGN_CENTER;
        //            imagen.ScaleAbsolute(0, 0);
        //            imagen.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);

        //            // Insertamos la imagen en el documento
        //            doc.Add(imagen);

        //            PdfPTable tblPrueba = new PdfPTable(3);
        //            tblPrueba.WidthPercentage = 100;

        //            // Configuramos el título de las columnas de la tabla
        //            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
        //            clNombre.BorderWidth = 0;
        //            clNombre.BorderWidthBottom = 0.75f;

        //            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
        //            clApellido.BorderWidth = 0;
        //            clApellido.BorderWidthBottom = 0.75f;

        //            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
        //            clPais.BorderWidth = 0;
        //            clPais.BorderWidthBottom = 0.75f;

        //            // Añadimos las celdas a la tabla
        //            tblPrueba.AddCell(clNombre);
        //            tblPrueba.AddCell(clApellido);
        //            tblPrueba.AddCell(clPais);

        //            // Llenamos la tabla con información
        //            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
        //            clNombre.BorderWidth = 0;

        //            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
        //            clApellido.BorderWidth = 0;

        //            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
        //            clPais.BorderWidth = 0;

        //            // Añadimos las celdas a la tabla
        //            tblPrueba.AddCell(clNombre);
        //            tblPrueba.AddCell(clApellido);
        //            tblPrueba.AddCell(clPais);

        //            clNombre = new PdfPCell(new Phrase("Juan", _standardFont));
        //            clNombre.BorderWidth = 0;

        //            clApellido = new PdfPCell(new Phrase("Rodríguez", _standardFont));
        //            clApellido.BorderWidth = 0;

        //            clPais = new PdfPCell(new Phrase("México", _standardFont));
        //            clPais.BorderWidth = 0;

        //            tblPrueba.AddCell(clNombre);
        //            tblPrueba.AddCell(clApellido);
        //            tblPrueba.AddCell(clPais);

        //            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
        //            doc.Add(tblPrueba);

        //            doc.Close();
        //            writer.Close();

        //            Response.ContentType = "pdf/application";
        //            Response.AddHeader("content-disposition",
        //            "attachment;filename=Certificado.pdf");
        //            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        protected void Generar_Click(object sender, EventArgs e)
        {
            try
            {
                //user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
                user.idusuario = 5;
                DataTable dt = user.consultar_persona(user);
                ReportForm.dtGral = dt;
                ReportForm.titulo = "CERTIFICADO DE ASISTENCIA AL SIMPOSIO INTERNACIONAL DE INVESTIGACIÓN";
                Response.Redirect("../Home/ReportForm.aspx?current=4");

               
            }
            catch (Exception ex)
            {

            } 
        }
    }
}