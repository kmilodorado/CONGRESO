//using SistemaAuditoria.Models.Clases;
//using SistemaAuditoria.Models.Interface;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace SistemaAuditoria.Models.Complemento
{
    public class Correo
    {
        MailMessage m = new MailMessage();
        SmtpClient smpt = new SmtpClient();
        //GeneralModel GN = new GeneralModel().ConsultarGeneral();

        public bool EnviarCorreo(string correo,string Titulo,string mensaje)
        {
            try
            {
               // //Datos del correo a enviar
               // m.From = new MailAddress(GN.GEN_CORREO);
               // m.To.Add(new MailAddress(correo));
               // m.Subject = GN.GEN_NOMBRE;

               // //Mensaje
               // string html = "<center><h1>" + GN.GEN_NOMBRE + "  " + GN.GEN_VERSION + "</h1>"
               //+ "</BR>"
               //+ "</BR>"
               //+ "<img src='cid:Logo'/></center>"
               //+ "</BR>"
               //+ "<h3>"+Titulo+ "</h3>"
               //+ "</BR>"
               //+ "<p>"+mensaje+"</p>";


               // //Agregar el mensaje al correo
               // AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);

               // //Insertar Imagen
               // LinkedResource img = new LinkedResource(HttpRuntime.AppDomainAppPath+"Images\\" + GN.GEN_LOGO, MediaTypeNames.Image.Jpeg);
               // img.ContentId = "Logo";
               // htmlView.LinkedResources.Add(img);


               // m.AlternateViews.Add(htmlView);//Correo listo para enviar

               // //Datos del correo de envio
               // m.IsBodyHtml = true;
               // smpt.Host = GN.GEN_SMPT;
               // smpt.Port = Convert.ToInt32(GN.GEN_PUERTO);
               // smpt.Credentials = new NetworkCredential(GN.GEN_CORREO, GN.GEN_PASS);
               // smpt.EnableSsl = true;
               // smpt.Send(m);

                return true;//Correo enviado
            }
            catch
            {
                return false;//Correo no enviado
            }
        }
    }
}