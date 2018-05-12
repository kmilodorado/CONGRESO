//using SistemaAuditoria.Models.Clases;
//using SistemaAuditoria.Models.Interface;
using Eventos.AccesoDatos.Clase;
using Eventos.Modelo.Clases;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace Eventos.Models.Complemento
{
    public class CorreoEvento
    {
        MailMessage m = new MailMessage();
        SmtpClient smpt = new SmtpClient();
        //GeneralModel GN = new GeneralModel().ConsultarGeneral();

        public bool EnviarCorreo(string correo, string Titulo, string mensaje, EventoModel eve)
        {
            try
            {
                DataTable con_gen = new Datos().ConsultarDatos("SELECT * FROM GENERAL;");
                //Datos del correo a enviar
                m.From = new MailAddress(con_gen.Rows[0]["CORREO"].ToString());
                m.To.Add(new MailAddress(correo));
                m.Subject = eve.NOMBRE;

                AlternateView htmlView;
                if (eve.LOGO != "")
                {
                    //Mensaje
                    string html = "<center><h1>" + eve.NOMBRE + "</h1>"
                   + "</BR>"
                   + "</BR>"
                   + "<img src='cid:Logo'/></center>"
                   + "</BR>"
                   + "<h3>" + Titulo + "</h3>"
                   + "</BR>"
                   + "<p>" + mensaje + "</p>";


                    //Agregar el mensaje al correo
                    htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);

                    //Insertar Imagen
                    LinkedResource img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Evento\\" + eve.LOGO, MediaTypeNames.Image.Jpeg);
                    img.ContentId = "Logo";
                    htmlView.LinkedResources.Add(img);

                }
                else
                {
                    //Mensaje
                    string html = "<center><h1>" + eve.NOMBRE + "</h1>"
                   + "</BR>"
                   + "</BR>"
                   + "<h3>" + Titulo + "</h3>"
                   + "</BR>"
                   + "<p>" + mensaje + "</p>";
                    htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                }

                m.AlternateViews.Add(htmlView);//Correo listo para enviar

                //Datos del correo de envio
                m.IsBodyHtml = true;
                smpt.Host = con_gen.Rows[0]["SMTP"].ToString();
                smpt.Port = Convert.ToInt32(con_gen.Rows[0]["PUERTO"].ToString());
                smpt.Credentials = new NetworkCredential(con_gen.Rows[0]["CORREO"].ToString(), con_gen.Rows[0]["PASS"].ToString());
                smpt.EnableSsl = true;
                smpt.Send(m);

                return true;//Correo enviado
            }
            catch
            {
                return false;//Correo no enviado
            }
        }
    }
}