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
    public partial class Masivos : System.Web.UI.Page
    {
        asistencia asis = new asistencia();
        asistenciaController ac = new asistenciaController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool registrarAsistencia(asistencia asi)
        {
            asis.fecha = asi.fecha;
            asis.fk_idpartic = asi.fk_idpartic;
            asis.estado = "T";
            asis.idusuario = Session["idUsuario"].ToString();

            asis.sesion = asi.sesion;

            asis.tipo = asi.tipo;
            asi.date = asi.date;
            return ac.insert_asistencia(asi);
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                DataTable dt;
                if (t_tipo.SelectedValue.Equals("Salida"))
                {
                    asis.tipo = "Entrada";
                    asis.sesion = t_sesion.SelectedValue;
                    asis.date = t_fecha.Text;
                    asis.fecha = t_fecha.Text + " " + t_hora.Text;
                    dt = asis.get_asistencias_tipo(asis);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row;
                        asis.tipo = t_tipo.SelectedValue;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            row = dt.Rows[i];
                            asis.fk_idpartic = Convert.ToInt32(row["FK_idPartic"].ToString());
                            if (registrarAsistencia(asis))
                            {
                                cont++;
                            }
                        }
                        if (cont > 0)
                        {
                            Resultados.Visible = true;
                            Resultados.CssClass = "alert alert-success";
                            LResultado.Text = "Se han registrado " + cont + " asistencias para el día " + asis.fecha + ", Sesión: " + asis.sesion + ", Tipo: " + asis.tipo;
                        }
                        else
                        {
                            Resultados.Visible = true;
                            Resultados.CssClass = "alert alert-warning";
                            LResultado.Text = "No existen asistencias por registrar. Todos los participantes han tienen su respectiva " + asis.tipo;

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                DataTable dt;
                if (t_tipo.SelectedValue.Equals("Salida"))
                {
                    asis.tipo = "Entrada";
                    asis.sesion = t_sesion.SelectedValue;
                    asis.date = t_fecha.Text;
                    asis.fecha = t_fecha.Text + " " + t_hora.Text;
                    dt = asis.get_asistencias_tipo(asis);
                    if (dt.Rows.Count > 0)
                    {
                        asis.tipo = t_tipo.SelectedValue;


                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-success";
                        LResultado.Text = dt.Rows.Count + " registros encontrados";
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.CssClass = "alert alert-warning";
                        LResultado.Text = "No se han encontrado resultados";

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}