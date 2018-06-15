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
                if (eve.LOGO != "")
                {
                    html += "<center><img src='cid:Logo' width='300' height='150' /></center>"
                    + "<br />";
                }
                html += "<h1 style='text-align:center'>" + eve.NOMBRE + "</h1>"
                    + "<br />"
                  + "<h3 style='text-align:center'>¡REGISTRO EXITOSO!</h3>"
                  + "<br />"
                  + "Cordial saludo,"
                  + "<p>"
                  + "<b>" + usu.NOMBRE + " " + usu.APELLIDO + "</b>, gracias por diligenciar el formulario, tu registro para participar del <b>" + eve.NOMBRE + "</b> se realizó satisfactoriamente"
                  + "<br />"
                  + "<br />"
                  + "<b>El Congreso</b> se llevará acabo los próximos <b>" + eve.FECHA_INICIAL.ToString("dd") + " al " + eve.FECHA_FINAL.ToString("dd") + " de " + dtinfo.GetMonthName(Convert.ToInt32(eve.FECHA_FINAL.ToString("MM"))) + " del año en curso</b>. Contaremos con la participación de ponentes locales, nacionales e internacionales."
                  + "<br />"
                  + "<br />"
                  + "Te invitamos a tomar los Cursos Taller Pre-Congreso, con los temas de actualidad en el cultivo de cacao, transformación y comercialización que harán parte de este magno evento. Los talleres tendrán un costo de $20.000 pesos cada uno, que cubrirán los gastos de insumos necesarios, el restante será donado en equipos a fincas productoras ya seleccionadas. "
                  + "<br />"
                  + "<br />"
                  + "También puedes participar del Gran Workshop “Tendencias de la investigación y el desarrollo del sector cacaotero y chocolatero en Colombia”, tendremos ponencias todo el día. El evento será en el Auditorio Jaime Garzón de la sede San Antonio de la Universidad de los Llanos. "
                  + "<br />"
                  + "<br />"
                  + "<b> NOTA IMPORTANTE: El código QR aquí adjunto deberá ser presentado al momento del ingreso al evento, la recomendación es guardar una captura de pantalla, imprimirlo o guardarlo como imagen para agilizar el proceso de entrada al recinto.</b>"
                  + "<br />"
                  + "<br />"
                  + "Tu credencial es:"
                  + "<br />"
                  + "Usuario: <b>" + usu.USERNAME + "</b>"
                  + "<br />"
                  + " Contraseña: <b>" + usu.PASS + "</b>"
                  + "<br />"
                  + "Para consultar tu inscripción ingresa a la siguiente enlace: "
                  + "<a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/LoginView.aspx?Evento=" + eve.SIGLAS + "'>Iniciar Sesión</a>"
                    + "<br />"
                    + "<br />"
                  + "<center><img src='cid:Cod' width='200' height='200' /></center>"
                  + "<br />"
                  + "<br />"
                  + "<center><b>Villavicencio se cubre de chocolate, junio es cacao! Te esperamos</>"
                  + "<br />"
                  + "Saluda, el Equipo Organizador."
                  + "<br /></center>"
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

                img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Codigo\\" + usu.IDENTIFICACION + ".jpg", MediaTypeNames.Image.Jpeg);
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

        public bool EnviarCorreoTaller(EventoModel eve, UsuarioModel usu)
        {
            try
            {
                //Datos del correo a enviar
                m.From = new MailAddress(con_gen.Rows[0]["CORREO"].ToString());
                m.To.Add(new MailAddress(usu.CORREO));
                m.Subject = eve.NOMBRE;

                AlternateView htmlView;
                string html = "";
                DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                //Mensaje
                if (eve.LOGO != "")
                {
                    html += "<center><img src='cid:Logo' width='300' height='150' /></center>"
                    + "<br />";
                }
                html += "<h1 style='text-align:center'>" + eve.NOMBRE + "</h1>"
                    + "<br />"
                  + "<h3 style='text-align:center'>¡REGISTRO EXITOSO!</h3>"
                  + "<br />"
                  + "Cordial saludo,"
                  + "<p>"
                  + "<b>" + usu.NOMBRE + " " + usu.APELLIDO + "</b>, gracias por diligenciar el formulario, tu registro para participar de los <b>Cursos Taller Pre-Congreso.</b> con los temas de actualidad en el cultivo de cacao se realizó satisfactoriamente."
                  + "<br />"
                  + "<br />"
                  + "Los talleres tendrán un costo de $20.000 pesos cada uno, que cubrirán los gastos de insumos necesarios, el restante será donado en equipos a fincas productoras ya seleccionadas."
                  + "<br />"
                  + "<br />"
                  + "<b>Te invitamos a asistir al Congreso Internacional</b> que se llevará acabo los próximos <b>21 y 22 de junio del año en curso.</b> Contaremos con la participación de ponentes locales, nacionales e internacionales."
                  + "<br />"
                  + "<br />"
                  + "También puedes participar del Gran Workshop “Tendencias de la investigación y el desarrollo del sector cacaotero y chocolatero en Colombia”, tendremos ponencias todo el día. El evento será en el Auditorio Jaime Garzón de la sede San Antonio de la Universidad de los Llanos."
                  + "<br />"
                  + "<br />"
                  + "<b> NOTA IMPORTANTE: El código QR aquí adjunto deberá ser presentado al momento del ingreso al evento, la recomendación es guardar una captura de pantalla, imprimirlo o guardarlo como imagen para agilizar el proceso de entrada al recinto.</b>"
                  + "<br />"
                  + "<br />"
                  + "Tu credencial es:"
                  + "<br />"
                  + "Usuario: <b>" + usu.USERNAME + "</b>"
                  + "<br />"
                  + " Contraseña: <b>" + usu.PASS + "</b>"
                  + "<br />"
                  + "Para consultar tu inscripción ingresa a la siguiente enlace: "
                  + "<a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/LoginView.aspx?Evento=" + eve.SIGLAS + "'>Iniciar Sesión</a>"
                    + "<br />"
                    + "<br />"
                  + "<center><img src='cid:Cod' width='200' height='200' /></center>"
                  + "<br />"
                  + "<br />"
                  + "<center><b>Villavicencio se cubre de chocolate, junio es cacao! Te esperamos</>"
                  + "<br />"
                  + "Saluda, el Equipo Organizador."
                  + "<br /></center>"
                  + "</p>";

                htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                LinkedResource img;
                if (eve.LOGO != "")
                {
                    //Insertar Imagen
                    img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Evento\\logo cacao tic.png", MediaTypeNames.Image.Jpeg);
                    img.ContentId = "Logo";
                    htmlView.LinkedResources.Add(img);
                }

                img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Codigo\\" + usu.IDENTIFICACION + ".jpg", MediaTypeNames.Image.Jpeg);
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
        public bool EnviarCorreoWorkShop(EventoModel eve, UsuarioModel usu)
        {
            try
            {
                //Datos del correo a enviar
                m.From = new MailAddress(con_gen.Rows[0]["CORREO"].ToString());
                m.To.Add(new MailAddress(usu.CORREO));
                m.Subject = eve.NOMBRE;

                AlternateView htmlView;
                string html = "";
                DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                //Mensaje
                if (eve.LOGO != "")
                {
                    html += "<center><img src='cid:Logo' width='300' height='150' /></center>"
                    + "<br />";
                }
                html += "<h1 style='text-align:center'>" + eve.NOMBRE + "</h1>"
                    + "<br />"
                  + "<h3 style='text-align:center'>¡REGISTRO EXITOSO!</h3>"
                  + "<br />"
                  + "Cordial saludo,"
                  + "<p>"
                  + "<b>" + usu.NOMBRE + " " + usu.APELLIDO + "</b>, gracias por diligenciar el formulario, tu registro para participar del Workshop “Tendencias de la investigación y el desarrollo del sector cacaotero y chocolatero en Colombia” se realizó satisfactoriamente. Tendremos ponencias todo el día. El evento será en el Auditorio Jaime Garzón de la sede San Antonio de la Universidad de los Llanos. "
                  + "<br />"
                  + "<br />"
                  + "<b>Te invitamos a asistir al Congreso</b> se llevará acabo los próximos <b>21 y 22 de junio del año en curso.</b>. Contaremos con la participación de ponentes locales, nacionales e internacionales."
                  + "<br />"
                  + "<br />"
                  + "Te invitamos a tomar los Cursos Taller Pre-Congreso, con los temas de actualidad en el cultivo de cacao, transformación y comercialización que harán parte de este magno evento. Los talleres tendrán un costo de $20.000 pesos cada uno, que cubrirán los gastos de insumos necesarios, el restante será donado en equipos a fincas productoras ya seleccionadas."
                  + "<br />"
                  + "<br />"
                  + "<b> NOTA IMPORTANTE: El código QR aquí adjunto deberá ser presentado al momento del ingreso al evento, la recomendación es guardar una captura de pantalla, imprimirlo o guardarlo como imagen para agilizar el proceso de entrada al recinto.</b>"
                  + "<br />"
                  + "<br />"
                  + "Tu credencial es:"
                  + "<br />"
                  + "Usuario: <b>" + usu.USERNAME + "</b>"
                  + "<br />"
                  + " Contraseña: <b>" + usu.PASS + "</b>"
                  + "<br />"
                  + "Para consultar tu inscripción ingresa a la siguiente enlace: "
                  + "<a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/LoginView.aspx?Evento=" + eve.SIGLAS + "'>Iniciar Sesión</a>"
                    + "<br />"
                    + "<br />"
                  + "<center><img src='cid:Cod' width='200' height='200' /></center>"
                  + "<br />"
                  + "<br />"
                  + "<center><b>Villavicencio se cubre de chocolate, junio es cacao! Te esperamos</>"
                  + "<br />"
                  + "Saluda, el Equipo Organizador."
                  + "<br /></center>"
                  + "</p>";

                htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                LinkedResource img;
                if (eve.LOGO != "")
                {
                    //Insertar Imagen
                    img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Evento\\logoworkshop.jpg", MediaTypeNames.Image.Jpeg);
                    img.ContentId = "Logo";
                    htmlView.LinkedResources.Add(img);
                }

                img = new LinkedResource(HttpRuntime.AppDomainAppPath + "Imagen\\Codigo\\" + usu.IDENTIFICACION + ".jpg", MediaTypeNames.Image.Jpeg);
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
        public bool CorreoMaxivo(EventoModel eve, string correo)
        {
            try
            {
                //Datos del correo a enviar
                m.From = new MailAddress(con_gen.Rows[0]["CORREO"].ToString());
                m.To.Add(new MailAddress(correo));
                m.Subject = eve.NOMBRE;
               
                AlternateView htmlView;
                string html = "";
                //Mensaje
                html += "<h1 style='text-align:center'>" + eve.NOMBRE + "</h1>";
                if (eve.LOGO != "")
                {
                    html += "<center><img src='cid:Logo' width='300' height='150' /></center>";
                }
                html += "<br />"
                  + "<br />"
                  + "<p>"
                  + "<b>¡ACERCA EL DÍA!</b>"
                  + "<br />"
                  + "<br />"
        + "Nos reuniremos productores, investigadores, estudiantes, administradores y amantes del cacao de Colombia en un solo lugar."
        + "<br />"
        + "<br />"
        + "¡Villavicencio será la casa del gremio cacaocultor del país!"
        + "<br />"
        + "<b>¡GRACIAS!</b>"
        + "<br />"
        + "<br />"
        + "Traemos para ustedes los ponentes más calificados para asegurar la mejor experiencia académica en temas de cacao."
        + "<br />"
        + "COLOMBIA, FRANCIA, GUATEMALA, COSTA RICA Y VENEZUELA."
        + "<br />"
        + "<br />"
        + "Conoce más en <a href='www.theobromaparalapaz.com.co'>www.theobromaparalapaz.com.co</a>"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<h2 style='text-align:center'>TALLERES PRE-CONGRESO 18 Y 19 DE JUNIO DE 2018.</h2>"
        + "<br />"
        + "<br />"
        + "INSTRUCTORES DE LAS MEJORES INSTITUCIONES PREPARADOS PARA DICTAR LOS TALLERES:"
                + "<br />"
                + "Universidad De La Amazonia"
        + "<br />"
        + "Fedecacao"
        + "<br />"
        + "Universidad Surcolombiana"
        + "<br />"
        + "Universidad Simón Bolívar De Venezuela"
        + "<br />"
        + "Universidad De Los Llanos"
        + "<br />"
        + "Agrosavia"
        + "<br />"
        + "Sena"
        + "<br />"
        + "<br />"
        + "LOS CURSOS TENDRÁN UN VALOR DE $20.000 PESOS CADA UNO, SERÁN DONADOS A FINCAS SELECCIONADAS, (Deberán ser cancelados al momento de entrar al aula)."
        + "<br />"
        + "Inscríbete a los cursos aquí: <a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/InscribirCursoView.aspx'>registro.theobromaparalapaz.com.co/Vistas/Publico/InscribirCursoView.aspx</a>"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<h2 style='text-align:center'> WORKSHOP <br /> “Tendencias de la investigación y el desarrollo del sector cacaotero y chocolatero en Colombia”. 20 de junio de 2018.</h2>"
        + "<br />"
        + "<br />"
        + "TENDRÁ LUGAR EN EL AUDITORIO JAIME GARZÓN DE LA SEDE SAN ANTONIO DE LA UNIVERSIDAD DE LOS LLANOS, HABRÁ PONENCIAS NACIONALES TODO EL DÍA."
        + "<br />"
        + "NO TIENE COSTO DE INGRESO."
        + "<br />"
        + "REQUISITO INSCRIPCIÓN PREVIA."
        + "<br />"
        + "<br />"
        + "Inscríbete al Workshop aquí: <a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/WorkshopView.aspx'>registro.theobromaparalapaz.com.co/Vistas/Publico/WorkshopView.aspx</a>"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<h2 style='text-align:center'> CONGRESO INTERNACIONAL THEOBROMA PARA LA PAZ <br />  21 Y 22 DE JUNIO</h2>"
        + "<br />"
        + "<br />"
        + "PONENCIAS NACIONALES E INTERNACIONALES, CONCURSO DE CATACIÓN, FOROS TEMÁTICOS, INTERCAMBIO DE SABERES, GRADUACIÓN DE PRODUCTORES."
        + "<br />"
        + "<br />"
        + "NO TIENE COSTO DE INGRESO."
        + "<br />"
        + "REQUISITO INSCRIPCIÓN PREVIA."
        + "<br />"
        + "Inscríbete al congreso aquí: <a href='http://registro.theobromaparalapaz.com.co/Vistas/Publico/RegistrarView.aspx?Evento=CacaoTics'>registro.theobromaparalapaz.com.co/Vistas/Publico/RegistrarView.aspx?Evento=CacaoTics</a>"
        + "<br />"
        + "<br />"
        + "¡La mejor experiencia académica en un solo recinto!"
        + "<br />"
        + "<br />"
        + "<br />"
        + "<h3 style='text-align:center'> INSCRIBETE YA, LOS CUPOS SON LIMITADOS.</h3>"
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