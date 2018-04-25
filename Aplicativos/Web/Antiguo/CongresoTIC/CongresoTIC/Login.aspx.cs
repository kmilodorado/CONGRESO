using CongresoTIC.Controllers;
using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC
{
    public partial class Login : System.Web.UI.Page
    {
        usuario user = new usuario();

        usuarioController userc = new usuarioController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Security sec = new Security();
            //Label1.Text = sec.Desencripta("d1VIafijEzagZVHxG7w0Sg==");
        }

        protected void MostrarMensaje(string Mensaje, Page Pagina)
        {
            string scriptStr = "alert(\'" + Mensaje + "\');";
            ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), "msgBox", scriptStr, true);
        }

        public void Ingresar()
        {
            DataRow datos;
            bool ingreso, estado = false;

            try
            {
                //LResultado.Text = "LLEGÓ";
                Security sec = new Security();
                Resultados.Visible = true;
                //ingreso = sec.ValidarIngreso(TUsuario.Text, T_Password.Text);
                ingreso = true;
                if (ingreso)
                {
                    //LResultado.Text = "INGRESO TRUE";
                    user.username = TUsuario.Text;
                    user.contraseña = sec.Encripta(T_Password.Text);

                    DataTable person = userc.validarUsuario(user);
                    if (person.Rows.Count > 0)
                    {
                        //LResultado.Text = "MAYOR QUE CERO";
                        estado = person.Rows.Count > 0;
                        user.idusuario = Convert.ToInt32(person.Rows[0]["idUsuario"].ToString());
                        datos = this.consultarPersona(user);
                        string c = datos["Contraseña"].ToString();
                        Session["Rol"] = datos["FK_idRol"].ToString();

                        if (estado && c.Equals(user.contraseña))
                        {
                            //var iduser = new HttpCookie("idUsuario") { Value = user.idusuario + "" };
                            //Response.Cookies.Add(iduser);
                            Session["idUsuario"] = user.idusuario;
                            Session["Estado"] = "T";
                            Response.Redirect("Views/Home/Main.aspx");
                        }
                        else
                        {
                            Resultados.CssClass = "alert alert-danger";
                            LResultado.Text = "Contraseña incorrecta";
                            T_Password.Focus();
                        }
                    }
                    else
                    {
                        Resultados.CssClass = "alert alert-danger";
                        LResultado.Text = "Usuario incorrecto";
                        TUsuario.Focus();
                    }
                }
                else
                {
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "Usuario o contraseña incorrectos";
                    T_Password.Focus();
                }
            }
            catch (Exception e)
            {
                LResultado.Text = e.Message;
            }
        }


        public DataRow consultarPersona(usuario obj)
        {
            DataTable dt = obj.consultar_persona(obj);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }


        protected void Iniciar_Click(object sender, EventArgs e)
        {
            try
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "openModal()", true);
                this.Ingresar();
            }
            catch (Exception ex)
            {
                //LResultado.Text = "catch: " + ex.Message;
            }
        }

        protected void Recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                Security sec = new Security();
                user.username = TCorreo.Text;
                DataTable person = userc.validarUsuario(user);
                if (person.Rows.Count > 0)
                {
                    DataRow row = person.Rows[0];

                    Correo objeto = new Correo(TCorreo.Text, "grupoinvestigacion_giecom@outlook.com", "molina1977");
                    string contenido = "Hola " + row["Nombres"].ToString() + " " + row["Apellidos"].ToString() + " <br/><br/>Le recordamos que las credenciales de " +
                "acceso a la plataforma del <b>Simposio Internacional de Investigación - UDLA 2017</b> son las siguientes: <br/><br/><b>Usuario: </b> " + row["Username"].ToString() +
                "<br/><b>Contraseña:</b> " + sec.Desencripta(row["Contraseña"].ToString()) + "<br/><br/><br/>" +
                "Atentamente, <br/>Comité organizador Simposio Internacional";
                    if (objeto.enviarCorreosAdjunto("RECUPERAR CONTRASEÑA - SIMPOSIO INTERNACIONAL", contenido, null))
                    {
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-success";
                        LResultado.Text = "La información ha sido enviada correctamente";
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-danger";
                        LResultado.Text = "Ocurrió un error al enviar la información de recuperación de contraseña";
                    }
                }
                else
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "El correo digitado no ha sido registrado";
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}