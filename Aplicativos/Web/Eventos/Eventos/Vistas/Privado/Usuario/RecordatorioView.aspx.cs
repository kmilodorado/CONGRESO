using Eventos.Modelo.Clases;
using Eventos.Models.Complemento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventos.Vistas.Privado.Usuario
{
    public partial class RecordatorioView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnviarCorreo_Click(object sender, EventArgs e)
        {
            if (Session["EVENTO_PUBLIC"] != null)
            {
                
                EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
                DataTable participante = new ParticipanteModel().ConsultarParticipantes(EVEN.IDEVENTO);
                string CorreosNoEnviados = "";
                for (int i = 0; i < participante.Rows.Count; i++)
                {
                    if (new CorreoEvento().CorreoMaxivo(EVEN, participante.Rows[i]["PERS_CORREO"].ToString())==false)
                    {
                        CorreosNoEnviados += participante.Rows[i]["PERS_CORREO"].ToString();
                    } 
                }
                   
                Label1.Text = CorreosNoEnviados;
            }
        }
    }
}