using CongresoTIC.Controllers;
using CongresoTIC.Models;
using CongresoTIC.Views.Evento;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CongresoTIC
{
    public partial class Inscripcion : System.Web.UI.Page
    {

        departamentoController dptoc = new departamentoController();
        municipioController mpioc = new municipioController();
        personaController personac = new personaController();
        tipo_documentoController tdc = new tipo_documentoController();
        tipo_participanteController tpc = new tipo_participanteController();

        Security sec = new Security();

        departamento dpto = new departamento();
        municipio mpio = new municipio();
        persona pers = new persona();
        usuario user = new usuario();
        participacion partic = new participacion();

        DataTable dptos, mpios, roles, tipos, tipodoc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                dptos = dptoc.get_departamentos();
                this.cargarLista(dptos, t_dpto, "NombreDpto", "idDpto");

                tipodoc = tdc.get_tipo_documentos();
                this.cargarLista(tipodoc, t_tdocumento, "NombreTipoDoc", "idTipoDoc");

                roles = tpc.get_tipo_persona();
                this.cargarLista(roles, t_tipopers, "NombreTipoPersona", "idTipoPersona");
                t_tipopers.SelectedValue = "1";

                tipos = tpc.get_tipo_participantes();
                this.cargarLista(tipos, t_tipopart, "NombreTipoPart", "idTipoPart");

                t_tipopart.SelectedValue = "1";

                //t_institución.Text = "UNIAMAZONIA";

                t_dpto.SelectedValue = "8";
                dpto.iddpto = Convert.ToInt32(t_dpto.SelectedValue);
                mpios = mpioc.get_mpio_by_dpto(dpto);
                this.cargarLista(mpios, t_mpio, "NombreMpio", "idMpio");
                t_mpio.SelectedValue = "360";
            }
        }

        public void cargarLista(DataTable dt, DropDownList obj, string text, string value)
        {
            obj.Items.Clear();
            obj.Items.Add(new ListItem("", "0"));
            DataRow fila;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fila = dt.Rows[i];
                obj.Items.Add(new ListItem(fila[text].ToString(), fila[value].ToString()));
            }
        }

        public bool registrarPersona()
        {
            if (user.get_users().Rows.Count > 0)
            {
                user.idusuario = Convert.ToInt32(user.get_id_user().Rows[0]["id"].ToString()) + 1;
            }
            else
            {
                user.idusuario = 1;
            }
            pers.fk_idtipodoc = Convert.ToInt32(t_tdocumento.SelectedValue);
            pers.idpersona = Convert.ToInt64(t_ndocumento.Text);
            pers.nombres = t_nombres.Text;
            pers.apellidos = t_apellidos.Text;
            pers.correo = t_correo.Text;
            pers.institucion = t_institución.Text;
            pers.observaciones = t_observacion.Text;
            pers.fk_idtipopers = Convert.ToInt32(t_tipopers.SelectedValue);
            pers.fk_idmpio = Convert.ToInt32(t_mpio.SelectedValue);
            user.username = t_correo.Text;
            user.contraseña = sec.Encripta(t_password.Text);

            partic.fk_idevento = 1;
            partic.fk_idtipopart = Convert.ToInt32(t_tipopart.SelectedValue);
            partic.fk_iduser = user.idusuario;

            return personac.insert_persona(pers, user, partic);
        }

        protected void Inscribir_Click(object sender, EventArgs e)
        {
            try
            {
                Resultados.Visible = true;

                if (this.registrarPersona())
                {
                    Resultados.CssClass = "alert alert-success";
                    LResultado.Text = "Tu solicitud de inscripción al SIMPOSIO INTERNACIONAL DE INVESTIGACIÓN ha sido enviada de forma exitosa";
                    LResult.Text = "Para continuar con el proceso, debes iniciar sesión y seguir las instrucciones";

                    this.getQRCode(t_ndocumento.Text);

                    DatosPersona.Text = "<h3>" + t_nombres.Text + " " + t_apellidos.Text + "</h3><h4>" + t_ndocumento.Text + "</h4>";
                    QRPersona.ImageUrl = "QR/" + t_ndocumento.Text + ".png";

                    t_password.Text = "123";

                }
                else
                {
                    Resultados.CssClass = "alert alert-danger";
                    LResultado.Text = "Ha ocurrido un error. Verifica e intenta nuevamente.";
                    LResult.Text = "";
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "openRegister()", true);
            }
            catch (Exception ex)
            {
            }
        }

        protected void BImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Logistica.all = false;
                Logistica.cedulas = t_ndocumento.Text;

                Response.Redirect("Views/Evento/Logistica.aspx?current=2");
            }
            catch (Exception) { }
        }

        protected void t_dpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpto.iddpto = Convert.ToInt32(t_dpto.SelectedValue);
            mpios = mpioc.get_mpio_by_dpto(dpto);
            this.cargarLista(mpios, t_mpio, "NombreMpio", "idMpio");
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public byte[] getQRCode(string code)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(code, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));


            string path = Server.MapPath("QR/" + code + ".png");
            if (!File.Exists(path))
            {
                imagen.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

            byte[] result = imageToByteArray(imagen);
            return result;
        }
    }
}