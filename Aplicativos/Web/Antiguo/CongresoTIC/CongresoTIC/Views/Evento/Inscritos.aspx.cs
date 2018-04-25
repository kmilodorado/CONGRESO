using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CongresoTIC.Reportes;
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
    public partial class Inscritos : System.Web.UI.Page
    {
        public DataTable dt = null;
        public DataRow Fila;

        participacion partic = new participacion();
        participacionController particc = new participacionController();
        recibopagoController reciboc = new recibopagoController();
        usuario user = new usuario();


        subitem sub = new subitem();
        recibo_pago recibo = new recibo_pago();

        ImageButton res = new ImageButton();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["Estado"].ToString().Equals("T"))
                {
                    string id;

                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("1"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            Contenido.Visible = true;
                            dt = particc.get_inscritos();
                            dt.Columns.Add("idRecibo");
                            dt.Columns.Add("Referencia");
                            dt.Columns.Add("Habil");

                            DataRow r, r2;
                            DataTable dt2;

                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    r = dt.Rows[i];
                                    user.idusuario = Convert.ToInt32(r["idUsuario"].ToString());
                                    dt2 = reciboc.recibos_por_persona(user);
                                    if (dt2.Rows.Count > 0)
                                    {
                                        r2 = dt2.Rows[0];
                                        dt.Rows[i]["idRecibo"] = r2["idRecibo"].ToString();
                                        dt.Rows[i]["Referencia"] = r2["Referencia"].ToString();
                                        dt.Rows[i]["Habil"] = "T";
                                    }
                                    else
                                    {
                                        dt.Rows[i]["idRecibo"] = "0";
                                        dt.Rows[i]["Referencia"] = "";
                                        dt.Rows[i]["Habil"] = "F";
                                    }
                                }
                            }
                        }
                        else
                        {
                            Contenido.Visible = false;
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

        public void cargarLista(DataTable dt, DropDownList obj, string text, string value)
        {
            obj.Items.Add(new ListItem("", "0"));
            DataRow fila;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fila = dt.Rows[i];
                obj.Items.Add(new ListItem(fila[text].ToString(), fila[value].ToString()));
            }
        }

        protected void Enviar_Click(object sender, ImageClickEventArgs e)
        {
            //this.MostrarMensaje("Hola", this.Page);
        }

        protected void Resultado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //public void Enviar_Correo()
        //{
        //    Persona persona = new Persona();
        //    envio.idEnvio = Convert.ToInt32(idEC.Text);
        //    DataTable dt = envio.consultarEnvios2(envio, 1);
        //    DataRow row = null;
        //    if (dt.Rows.Count > 0)
        //    {
        //        row = dt.Rows[0];
        //        persona.Correo = row["Correo"].ToString();
        //        persona.Nombres = row["Nombres"].ToString();
        //        persona.Apellidos = row["Apellidos"].ToString();
        //    }

        //    Correo objeto = new Correo(persona.Correo, "semillerodeprogramacion@outlook.com", "molina1977");
        //    string contenido = "Hola, " + persona.Nombres + "." +
        //        "\n\nEl siguiente es el RESULTADO ACTUAL de la revisión a la entrega que usted ha realizado previamente para el Semillero de Programación:\n\n" +
        //        "Ejercicio: " + row["ID"].ToString() + " - " + row["NombreEjercicio"].ToString() +
        //        "\nRespuesta: " + row["NombreRespuesta"].ToString() +
        //        (row["Comentario"].ToString().Equals("") ? "" : "\nComentarios: " + row["Comentario"].ToString()) +

        //        "\n\nPor este medio y a través de la plataforma del Semillero se le estará informando cualquier noticia adicional. Gracias por cumplir con su entrega." +
        //        "\n\n\nCordialmente," +
        //        "\n\nDiana María Espinosa Sarmiento.";
        //    objeto.enviarCorreos("Revisión de ejercicios", contenido);
        //}



        protected void OpenWindowConfirm(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "abrir()", true);
        }

        protected void Source_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                recibo.idrecibo = Convert.ToInt32(idEC.Text);
                DataRow fila2 = recibo.get_recibopago_id(recibo).Rows[0];
                string path = fila2["Ruta"].ToString().Replace("-", "\\");

                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    //Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";//vnd.ms-word.document"; //x-zip-compressed";
                    Response.AddHeader("content-disposition", "attachment; filename=" + fila2["File"].ToString());
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    FileStream sourceFile = new FileStream(path, FileMode.Open);
                    long FileSize;
                    FileSize = sourceFile.Length;
                    byte[] getContent = new byte[(int)FileSize];

                    sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                    sourceFile.Close();

                    Response.BinaryWrite(getContent);
                    Response.Flush();
                    Response.End();

                }
            }
            catch (Exception ex) { }
        }

        protected void Rechazar_Click(object sender, EventArgs e)
        {
            try
            {
                user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());

                DataTable datos_cuenta = user.consultar_persona(user);
                DataRow data = datos_cuenta.Rows[0];

                partic.estado = "F";
                partic.calificador = data["Nombres"].ToString() + " " + data["Apellidos"].ToString();

                recibo.idrecibo = Convert.ToInt32(idEC.Text);
                DataTable d = recibo.get_recibopago_id(recibo);

                partic.idpartic = Convert.ToInt32(d.Rows[0]["FK_idParticipacion"].ToString());

                if (partic.update_inscripcion(partic))
                {
                    Page_Load(sender, e);
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "La inscripción ha sido RECHAZADA correctamente";

                    DataTable part = this.datos_partic(partic.idpartic + "");
                    if (part.Rows.Count > 0)
                    {
                        DataRow drpart = part.Rows[0];
                        Correo objeto = new Correo(drpart["Correo"].ToString(), "grupoinvestigacion_giecom@outlook.com", "molina1977");
                        string contenido = "<p>Hola " + drpart["Nombres"].ToString() + " " + drpart["Apellidos"].ToString() + " <br/><br/>Su inscripción al <b>Simposio Internacional de Investigación UDLA 2017</b> ha sido <b>RECHAZADA.</b> " + "<br/><br/>" +

                        "<br/>Atentamente, <br/>Comité organizador Simposio Internacional</p>";

                        objeto.enviarCorreosAdjunto("INSCRIPCIÓN ACEPTADA - SIMPOSIO", contenido, null);
                    }


                }
                else
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "No ha sido posible RECHAZAR la inscripción";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());

                DataTable datos_cuenta = user.consultar_persona(user);
                DataRow data = datos_cuenta.Rows[0];

                partic.estado = "T";
                partic.calificador = data["Nombres"].ToString() + " " + data["Apellidos"].ToString();

                recibo.idrecibo = Convert.ToInt32(idEC.Text);
                DataTable d = recibo.get_recibopago_id(recibo);

                partic.idpartic = Convert.ToInt32(d.Rows[0]["FK_idParticipacion"].ToString());

                if (partic.update_inscripcion(partic))
                {
                    Page_Load(sender, e);
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "La inscripción ha sido ACEPTADA correctamente";

                    

                    DataTable part = this.datos_partic(partic.idpartic + "");
                    if (part.Rows.Count > 0)
                    {
                        
                        DataRow drpart = part.Rows[0];
                        this.getQRCode(drpart["idPersona"].ToString());

                        Correo objeto = new Correo(drpart["Correo"].ToString(), "grupoinvestigacion_giecom@outlook.com", "molina1977");
                        string contenido = "<p>Hola " + drpart["Nombres"].ToString() + " " + drpart["Apellidos"].ToString() + " <br/><br/>Su inscripción al <b>Simposio Internacional de Investigación UDLA 2017</b> ha sido <b>ACEPTADA.</b> " + "<br/><br/>" +

                        "Le recordamos presentar el residuo electrónico el día del evento." +
                        "<br/><br/>Además, su entrada al Simposio Internacional será controlada mediante el siguiente código QR, que debe ser presentado por usted.<br/><br/>" +
                        "<img src='http://191.102.85.226/simposio/QR/" + drpart["idPersona"].ToString() + ".png' alt='Código QR' />" +
                        "<br/><br/><br/>Atentamente, <br/>Comité organizador Simposio Internacional</p>";

                        objeto.enviarCorreosAdjunto("INSCRIPCIÓN ACEPTADA - SIMPOSIO", contenido, null);
                    }


                }
                else
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "No ha sido posible ACEPTAR la inscripción";
                }
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable datos_partic(string id_partic)
        {
            return partic.get_dato_participacion(id_partic);
        }

        protected void GrillaReportes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GenerarActivos_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = particc.get_activos();
                ReportForm.dtGral = dt;
                ReportForm.titulo = "ESTUDIANTES INSCRITOS EN EL SIMPOSIO INTERNACIONAL";
                Response.Redirect("../Home/ReportForm.aspx?current=3");
            }
            catch (Exception ex)
            {

            }
        }



        protected void Activar_Click(object sender, EventArgs e)
        {
            try
            {
                user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());

                DataTable datos_cuenta = user.consultar_persona(user);
                DataRow data = datos_cuenta.Rows[0];

                partic.estado = "T";
                partic.calificador = data["Nombres"].ToString() + " " + data["Apellidos"].ToString();


                partic.idpartic = Convert.ToInt32(idP.Text);

                if (partic.update_inscripcion(partic))
                {
                    Page_Load(sender, e);
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "La persona ha sido activada para el Simposio Internacional de Investigación";

                    DataTable part = this.datos_partic(partic.idpartic + "");
                    if (part.Rows.Count > 0)
                    {
                        DataRow drpart = part.Rows[0];
                        this.getQRCode(drpart["idPersona"].ToString());
                        Correo objeto = new Correo(drpart["Correo"].ToString(), "grupoinvestigacion_giecom@outlook.com", "molina1977");
                        string contenido = "<p>Hola " + drpart["Nombres"].ToString() + " " + drpart["Apellidos"].ToString() + " <br/><br/>Su inscripción al <b>Simposio Internacional de Investigación UDLA 2017</b> ha sido <b>ACEPTADA.</b> " + "<br/><br/>" +

                        "Le recordamos presentar el residuo electrónico el día del evento." +
                        "<br/><br/>Además, su entrada al Simposio Internacional será controlada mediante el siguiente código QR, que debe ser presentado por usted.<br/><br/>" +
                        "<img src='http://191.102.85.226/simposio/QR/" + drpart["idPersona"].ToString() + ".png' alt='Código QR' />" +
                        "<br/><br/><br/>Atentamente, <br/>Comité organizador Simposio Internacional</p>";

                        objeto.enviarCorreosAdjunto("INSCRIPCIÓN ACEPTADA - SIMPOSIO", contenido, null);
                    }

                }
                else
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "No ha sido posible ACTIVAR la inscripción de la persona";
                }
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

            byte[] result = imageToByteArray(imagen);
            return result;
        }
    }
}