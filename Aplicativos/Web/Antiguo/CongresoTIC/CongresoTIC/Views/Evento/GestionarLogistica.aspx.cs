using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CrystalDecisions.Shared;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class GestionarLogistica : System.Web.UI.Page
    {
        public static DataTable dt = new DataTable();
        public static DataRow row;

        asistencia asi = new asistencia();

        persona per = new persona();
        subitem sub = new subitem();
        participacion part = new participacion();

        personaController pc = new personaController();
        asistenciaController ac = new asistenciaController();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    string id;

                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("8"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            dt = part.get_logistica();

                            if (!IsPostBack)
                            {
                                spa.Visible = false;
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

        protected void Registrar_Click(object sender, EventArgs e)
        {

        }

        public void buscarAsistente(string cedula)
        {
            bool state = false;
            try
            {
                per.idpersona = Convert.ToInt64(cedula);
                DataTable dta = pc.get_persona_bycedula(per);
                DataRow row;
                string tip = "";
                int h, m;
                if (dta.Rows.Count > 0)
                {
                    row = dta.Rows[0];
                    LName.Text = row["Nombres"].ToString() + " " + row["Apellidos"].ToString();
                    part.fk_iduser = Convert.ToInt32(row["idUsuario"].ToString());

                    if (part.insert_logistica(part))
                    {
                        state = true;
                    }
                    else
                    {
                        state = false;
                    }

                    //dt.Rows.Add(row["idPersona"].ToString(), row["Nombres"].ToString() + " " + row["Apellidos"].ToString(), asi.fecha, asi.sesion, asi.tipo, state);
                    t_documento.Text = "";

                    spa.Visible = true;
                    LPart.Text = row["NombreTipoPart"].ToString();
                }
                else
                {
                    LName.Text = "Participante no encontrado";
                    t_documento.Text = "";
                    spa.Visible = false;
                    LPart.Text = "";
                }
                //t_documento.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        protected void t_documento_TextChanged(object sender, EventArgs e)
        {
            buscarAsistente(t_documento.Text);
            Page_Load(sender, e);
        }
    }
}