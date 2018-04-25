using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CongresoTIC.Models
{
    public class Correo
    {
        protected string emailTo = string.Empty;
        protected string emailFrom = string.Empty;
        protected string password = string.Empty;
        protected SmtpClient client = new SmtpClient();

        public Correo(string para, string de, string contraseña)
        {
            emailTo = para;
            emailFrom = de;
            password = contraseña;
        }

        public bool enviarCorreosAdjunto(string asunto, string msj, Attachment archivo)
        {
            bool estado = true;
            System.Net.Mail.MailMessage mg = new System.Net.Mail.MailMessage();
            mg.From = new MailAddress(emailFrom);
            mg.To.Add(emailTo);
            mg.Subject = asunto;
            mg.Body = msj;
            mg.IsBodyHtml = true;

            if (archivo != null)
            {
                mg.Attachments.Add(archivo);
            }
            SmtpClient sc = new SmtpClient("smtp.live.com");
            sc.Port = 25;
            sc.Credentials = new NetworkCredential(emailFrom, password);
            sc.EnableSsl = true;

            try
            {
                sc.Send(mg);
            }
            catch (Exception ex)
            {
                estado = false;
            }
            sc.Dispose();
            return estado;
        }
    }
}