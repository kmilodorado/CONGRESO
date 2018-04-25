using CongresoTIC.Controllers;
using CongresoTIC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class ReciboPago : System.Web.UI.Page
    {
        DataTable dtEj, dt2, dt3;
        public DataRow Fila;
        public DataTable dt = new DataTable();

        participacion partic = new participacion();
        participacionController particc = new participacionController();
        recibopagoController reciboc = new recibopagoController();
        usuario user = new usuario();


        subitem sub = new subitem();
        recibo_pago recibo = new recibo_pago();
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("4"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
                            Contenido.Visible = true;
                            dt = reciboc.recibos_por_persona(user);

                            if (!IsPostBack)
                            {

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
                        Contenido.Visible = false;
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-danger";
                        LResultado.Text = "Acceso denegado.";
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
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

        protected void MostrarMensaje(string Mensaje, Page Pagina)
        {
            string scriptStr = "alert(\'" + Mensaje + "\');";
            ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), "msgBox", scriptStr, true);
        }


        protected void Enviar_Click(object sender, EventArgs e)
        {
            string postedfile = t_fuente.PostedFile.FileName;
            if (t_fuente.HasFile)
            {

                //fs = t_enunciado.PostedFile.InputStream;
                ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "abrir()", true);
            }
            else
            {
                Resultados.Visible = true;
                Resultados.CssClass = "alert alert-danger";
                LResultado.Text = "No has seleccionado el archivo";
            }
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

        public string getRuta()
        {
            return "C:-inetpub-wwwroot-simposio-simposio-xAsfaMja-";
        }


        public bool cargarArchivo(string name, string ext)
        {
            bool d = true;
            try
            {
            String path = Server.MapPath("/simposio/simposio/xAsfaMja/");
            if (t_fuente.HasFile)
            {
                
                    //t_enunciado.PostedFile.SaveAs(path
                    //        + t_enunciado.FileName);
                    t_fuente.PostedFile.SaveAs(path
                            + name + ext);
                
            }
            }
            catch (Exception ex)
            {
                Resultados.CssClass = "alert alert-danger";
                LResultado.Text = ex.Message;
                d = false;
            }
            return d;
        }

        public bool insert_recibo()
        {
            bool result = false;
            user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
            DataTable dr = particc.get_participacion_persona(user);
            DataRow row;
            string name, ext;
            if (dr.Rows.Count > 0)
            {
                ext = Path.GetExtension(t_fuente.FileName);

                row = dr.Rows[0];
                recibo.partic = row["idPartic"].ToString();

                user.idusuario = Convert.ToInt32(Session["idUsuario"].ToString());
                Contenido.Visible = true;
                DataTable d = reciboc.recibos_por_persona(user);
                if (d.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "Ya has cargado un comprobante de pago. La solicitud se encuentra en proceso.";
                }
                else
                {

                    name = user.idusuario + "_Recibo" + (d.Rows.Count + 1);

                    recibo.file = name + ext;
                    recibo.referencia = t_referencia.Text;
                    recibo.ruta = this.getRuta() + name + ext;

                    if (this.cargarArchivo(name, ext))
                    {
                        result = reciboc.insert_recibopago(recibo);
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-danger";
                        //LResultado.Text = "Error al cargar el archivo, por favor informe al administrador.";

                    }
                }
            }
            return result;
        }

        protected void EnviarFuente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!t_referencia.Text.Equals(""))
                {
                    if (t_fuente.HasFile)
                    {
                        if (this.insert_recibo())
                        {
                            Page_Load(sender, e);
                            Resultados.Visible = true;
                            Resultados.CssClass = "alert alert-success";
                            LResultado.Text = "Archivo cargado con éxito";
                        }
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-danger";
                        LResultado.Text = "No has seleccionado el archivo";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "validate()", true);
                }

            }
            catch (Exception ex)
            {
                Resultados.Visible = true;
                Resultados.CssClass = "alert alert-danger";
                LResultado.Text = "Error al cargar el archivo, por favor informe al administrador.";
            }
        }
    }
}