//using SistemaAuditoria.Models.Clases;
//using SistemaAuditoria.Models.Interface;
using Eventos.AccesoDatos.Clase;
using Eventos.Modelo.Clases;
using System;
using System.Data;
using System.Drawing.Imaging;
using System.Globalization;
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
        DataTable con_gen = new Datos().ConsultarDatos("SELECT * FROM GENERAL;");

        public bool EnviarCorreo(string correo, string Titulo, string mensaje, EventoModel eve, UsuarioModel usu)
        {
            try
            {
                //Datos del correo a enviar
                m.From = new MailAddress(con_gen.Rows[0]["CORREO"].ToString());
                m.To.Add(new MailAddress(correo));
                m.Subject = eve.NOMBRE;

                AlternateView htmlView;
                string html = "";
                DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                //Mensaje
                html += "<h1 style='text-align:center'>" + eve.NOMBRE + "</h1>";
                if (eve.LOGO != "")
                {
                    html += "<center><img src='cid:Logo' width='300' height='150' /></center>";
                }
                html += "<br />"
                  + "<br />"
                  + "<h3>Registro exitoso</h3>"
                  + "<br />"
                  + "Reciban cordial saludo."
                  + "<p>"
                  + "<b>" + usu.NOMBRE + " " + usu.APELLIDO + "</b> Comedidamente me dirijo a ustedes con el fin de darles a conocer que su registro se realizó satisfactoriamente."
                  + "<br />"
                  + "<br />"
                  + "Lo en el <b>\"" + eve.NOMBRE + "\"</b>, evento que se llevará a cabo durante la fecha comprendida del " + eve.FECHA_INICIAL.ToString("dd") + " al " + eve.FECHA_FINAL.ToString("dd") + " de " +dtinfo.GetMonthName(Convert.ToInt32(eve.FECHA_FINAL.ToString("MM"))) + " del año en curso. Durante el desarrollo de nuestro evento, contaremos con la participación de ponentes locales, nacionales e internacionales."
                  + "<br />"
                  + "<br />"
                  + "Su credencial es:"
                  + "<br />"
                  + "Usuario: <b>" + usu.USERNAME + "</b>"
                  + "<br />"
                  + " Contraseña: <b>" + usu.PASS + "</b>"
                  + "<br />"
                  + "<center><img src='cid:Cod' width='200' height='200' /></center>"
                  + "<br />"
                  + "Para hacer efectiva la inscripción al congreso se deben dirigir a la siguiente enlace:"
                  + "<br />"
                  + "<a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/LoginView.aspx?Evento=" + eve.SIGLAS + "'>Iniciar Sesión</a>"
                  + "<br />"
                  + "<br />"
                  + "De antemano agradecemos su atención y valiosa participación."
                  + "<br />"
                  + "<br />"
                  + "Cordialmente."
                  + "</p>";

                htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                LinkedResource img;
                if (eve.LOGO != "")
                {
                    //Insertar Imagen
                    img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Evento\\" + eve.LOGO, MediaTypeNames.Image.Jpeg);
                    img.ContentId = "Logo";
                    htmlView.LinkedResources.Add(img);
                }

                img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Codigo\\" + usu.IDENTIFICACION+".jpg", MediaTypeNames.Image.Jpeg);
                img.ContentId = "Cod";
                htmlView.LinkedResources.Add(img);

                m.AlternateViews.Add(htmlView);//Correo listo para enviar

                //Datos del correo de envio
                m.IsBodyHtml = true;
                smpt.Host = con_gen.Rows[0]["SMTP"].ToString();
                smpt.Port = Convert.ToInt32(con_gen.Rows[0]["PUERTO"].ToString());
                smpt.Credentials = new NetworkCredential(con_gen.Rows[0]["CORREO"].ToString(), con_gen.Rows[0]["PASS"].ToString());
                smpt.EnableSsl = false;
                smpt.Send(m);

                return true;//Correo enviado
            }
            catch
            {
                return false;//Correo no enviado
            }
        }

        public bool RecuperarPassword(EventoModel eve, PersonaModel per)
        {
            try
            {
                //Datos del correo a enviar
                m.From = new MailAddress(con_gen.Rows[0]["CORREO"].ToString());
                m.To.Add(new MailAddress(per.CORREO));
                m.Subject = eve.NOMBRE;

                AlternateView htmlView;
                string html = "";
                DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                //Mensaje
                html += "<h1 style='text-align:center'>" + eve.NOMBRE + "</h1>";
                if (eve.LOGO != "")
                {
                    html += "<center><img src='cid:Logo' width='300' height='150' /></center>";
                }
                html += "<br />"
                  + "<br />"
                  + "<h3>Recuperar Contraseña</h3>"
                  + "<p>"
                  + "Hola <b>" + per.NOMBRE + " " + per.APELLIDO + "</b>, El sistema de eventos a restaurado su contraseña."
                  + "<br />"
                  + "<br />"
                  + "Su credencial es:"
                  + "<br />"
                  + "Usuario: <b>" + per.IDENTIFICACION + "</b>"
                  + "<br />"
                  + " Contraseña: <b>" + per.IDENTIFICACION + "</b>"
                  + "</p>";

                htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                LinkedResource img;
                if (eve.LOGO != "")
                {
                    //Insertar Imagen
                    img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Evento\\" + eve.LOGO, MediaTypeNames.Image.Jpeg);
                    img.ContentId = "Logo";
                    htmlView.LinkedResources.Add(img);
                }

                m.AlternateViews.Add(htmlView);//Correo listo para enviar

                //Datos del correo de envio
                m.IsBodyHtml = true;
                smpt.Host = con_gen.Rows[0]["SMTP"].ToString();
                smpt.Port = Convert.ToInt32(con_gen.Rows[0]["PUERTO"].ToString());
                smpt.Credentials = new NetworkCredential(con_gen.Rows[0]["CORREO"].ToString(), con_gen.Rows[0]["PASS"].ToString());
                smpt.EnableSsl = false;
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