using CongresoTIC.Controllers;
using CongresoTIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC.Views.Evento
{
    public partial class Refrigerios : System.Web.UI.Page
    {
        public static DataTable dt = new DataTable(), dt2;
        public static DataRow row, row2;

        refrigerio refr = new refrigerio();
        participacion part = new participacion();

        persona per = new persona();
        subitem sub = new subitem();

        personaController pc = new personaController();
        refrigerioController rc = new refrigerioController();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString().Equals("T"))
                {
                    string id;

                    id = Request.QueryString["id"].ToString() != null ? Request.QueryString["id"].ToString() : null;

                    if (id != null && id.Equals("6"))
                    {
                        if (sub.validarAcceso(id, Session["Rol"].ToString()))
                        {
                            dt = refr.get_refrigerios();

                            if (!IsPostBack)
                            {
                                spa.Visible = false;
                                //dt = new DataTable();
                                //dt.Columns.Add("ID");
                                //dt.Columns.Add("Estudiante");
                                //dt.Columns.Add("Fecha");
                                //dt.Columns.Add("Sesion");
                                //dt.Columns.Add("Estado");

                                this.llenarConsumo();
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

        public void llenarConsumo()
        {
            string jornada = "", dia = "";
            dt2 = part.get_inscritos2();
            DataRow f;

            dt2.Columns.Add("M1");
            dt2.Columns.Add("M2");
            dt2.Columns.Add("J1");
            dt2.Columns.Add("J2");
            dt2.Columns.Add("V1");
            dt2.Columns.Add("V2");
            dt2.Columns.Add("Porcentaje");

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                f = dt2.Rows[i];

                dt2.Rows[i]["M1"] = "X";
                dt2.Rows[i]["M2"] = "X";
                dt2.Rows[i]["J1"] = "X";
                dt2.Rows[i]["J2"] = "X";
                dt2.Rows[i]["V1"] = "X";
                dt2.Rows[i]["V2"] = "X";
                dt2.Rows[i]["Porcentaje"] = "100 %";
            }
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                refr.idrefrigerio = Convert.ToInt32(idEC.Text);
                if (refr.borrar_refrigerio(refr))
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "Operación exitosa";
                }
                else
                {
                    Resultados.Visible = true;
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "Operación fallida";
                }
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        public void buscarAsistente(string cedula)
        {
            try
            {
                per.idpersona = Convert.ToInt64(cedula);
                DataTable dta = pc.get_persona_bycedula(per);
                DataRow row;
                string tip = "";
                int h;
                if (dta.Rows.Count > 0)
                {
                    row = dta.Rows[0];
                    LName.Text = row["Nombres"].ToString() + " " + row["Apellidos"].ToString();

                    DateTime time = DateTime.Now;

                    refr.fecha = time.ToString("yyyy-MM-dd HH:mm:ss");
                    //asi.fecha = "2016-09-27 16:24:34";
                    refr.fk_idpartic = Convert.ToInt32(row["idPartic"].ToString());
                    refr.estado = "T";

                    h = Convert.ToInt32(time.ToString("HH"));


                    refr.sesion = h <= 12 ? "1" : "2";
                    refr.name = "Name";
                    refr.date = time.ToString("yyyy-MM-dd");
                    refr.idusuario = Session["idUsuario"].ToString();


                    if ((h >= 7 && h <= 9) || (h >= 14 && h <= 15))
                    {
                        tip = "Entrada";
                    }
                    else if ((h >= 11 && h <= 13) || (h >= 17 && h <= 19))
                    {
                        tip = "Salida";
                    }

                    string state;

                    if (rc.insert_refrigerio(refr))
                    {
                        state = "T";
                    }
                    else
                    {
                        state = "F";
                    }

                    //dt.Rows.Add(row["idPersona"].ToString(), row["Nombres"].ToString() + " " + row["Apellidos"].ToString(), refr.fecha, refr.sesion, state);
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