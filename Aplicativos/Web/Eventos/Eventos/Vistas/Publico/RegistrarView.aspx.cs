using Eventos.Modelo.Clases;
using Eventos.Models.Complemento;
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

namespace Eventos.Vistas.Publico
{
    public partial class RegistrarView1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    EventoModel EVE = new EventoModel().ConsultarSiglas(Request.QueryString["Evento"]);
                    titulo.Text = EVE.NOMBRE;
                    if (EVE.LOGO != "")
                    {
                        icono.Href = "../../Imagen/Evento/" + EVE.LOGO;
                    }
                    Image2.ImageUrl = "~/Imagen/Evento/" + EVE.LOGO;
                    Evento.InnerHtml = EVE.NOMBRE;
                    titulo_registro.InnerHtml = "INSCRIPCIÓN AL " + EVE.NOMBRE;
                    login.HRef = "LoginView.aspx?Evento=" + EVE.SIGLAS;
                    inscribir.HRef = "RegistrarView.aspx?Evento=" + EVE.SIGLAS;
                    programa.HRef = "ProgramaView.aspx?Evento=" + EVE.SIGLAS;
                    Session["EVENTO_PUBLIC"] = EVE;

                    DDL_TIPO_DOC.DataSource = new Tipo_IdentificacionModel().Consultar();
                    DDL_TIPO_DOC.DataTextField = "TIPO_DETALLE";
                    DDL_TIPO_DOC.DataValueField = "ID";
                    DDL_TIPO_DOC.Items.Insert(0, new ListItem("Seleccionar Tipo Identificación", ""));

                    DataTable Consulta = new MunicipioModel().ConsultarPais();
                    DDL_PAIS.DataSource = Consulta;
                    DDL_PAIS.DataTextField = "PAIS_NOMBRE";
                    DDL_PAIS.DataValueField = "IDPAIS";
                    DDL_PAIS.Items.Insert(0, new ListItem("Seleccionar País Residencia", ""));

                    DDL_PAIS_NAC.DataSource = Consulta;
                    DDL_PAIS_NAC.DataTextField = "PAIS_NOMBRE";
                    DDL_PAIS_NAC.DataValueField = "IDPAIS";
                    DDL_PAIS_NAC.Items.Insert(0, new ListItem("Seleccionar País Nacimiento", ""));

                    DDL_GENERO.DataSource = new GeneroModel().Consultar();
                    DDL_GENERO.DataTextField = "GENE_DETALLE";
                    DDL_GENERO.DataValueField = "IDGENERO";
                    DDL_GENERO.Items.Insert(0, new ListItem("Seleccionar Genero", ""));

                    DDL_CONDICION.DataSource = new EspecialModel().Consultar();
                    DDL_CONDICION.DataTextField = "COND_DETALLE";
                    DDL_CONDICION.DataValueField = "IDCOND_ESPECIAL";
                    DDL_CONDICION.Items.Insert(0, new ListItem("Cuenta con alguna condición especial", ""));

                    DDL_CIRCUNS.DataSource = new CircunscripcionModel().Consultar();
                    DDL_CIRCUNS.DataTextField = "CIRC_DETALLE";
                    DDL_CIRCUNS.DataValueField = "IDCIRCUNSCRIPCION";
                    DDL_CIRCUNS.Items.Insert(0, new ListItem("Seleccionar Circunscripción", ""));

                    DDL_FORMACION.DataSource = new FormacionModel().Consultar();
                    DDL_FORMACION.DataTextField = "FORM_DETALLE";
                    DDL_FORMACION.DataValueField = "ID";
                    DDL_FORMACION.Items.Insert(0, new ListItem("Seleccionar Nivel de Formación", ""));

                    DDL_OCUPACION.DataSource = new OcupacionModel().Consultar();
                    DDL_OCUPACION.DataTextField = "OCUP_DETALLE";
                    DDL_OCUPACION.DataValueField = "ID";
                    DDL_OCUPACION.Items.Insert(0, new ListItem(" Seleccionar Ocupación", ""));

                    DDL_PARTICIPACION.DataSource = new Tipo_ParticipanteModel().Consultar();
                    DDL_PARTICIPACION.DataTextField = "TIPO_DETALLE";
                    DDL_PARTICIPACION.DataValueField = "ID";
                    DDL_PARTICIPACION.Items.Insert(0, new ListItem("Seleccionar Tipo de Participación", ""));
                    DataBind();
                    Repeater1.DataSource = new CuestionarioModel().ConsultarPreguntas();
                    Repeater1.DataBind();

                    if (Request.QueryString["alert"] != null)
                    {
                        AlertaModel AR = new AlertaModel(Request.QueryString["alert"]);
                        Alerta.Visible = AR.VISIBLE;
                        Alerta.CssClass = AR.ESTILO;
                        Alert.Text = AR.MENSAJE;
                        Afirm.InnerHtml = AR.AFIRMACION;
                    }
                }
            }
            catch
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            EventoModel EVEN = (EventoModel)Session["EVENTO_PUBLIC"];
            if (EVEN != null)
            {

                UsuarioModel usu = new UsuarioModel().ConsultarUserIdentificacion(TXT_IDENTIFICACION.Text);
                if (usu.IDUSUARIO == "")
                {
                    if (DDL_TIPO_DOC.Text != "" && DDL_OCUPACION.Text != "" && DDL_FORMACION.Text != "" && DDL_MUNICIPIO.Text != "" && DDL_PARTICIPACION.Text != "" && DDL_GENERO.Text != "" && DDL_PAIS_NAC.Text != "" && DDL_CONDICION.Text != "" && DDL_CIRCUNS.Text != "")
                    {
                        usu.IDENTIFICACION = TXT_IDENTIFICACION.Text;
                        usu.TIPO_IDENTIFICACION.IDTIPO_IDENTIFICACION = DDL_TIPO_DOC.SelectedValue;
                        usu.NOMBRE = TXT_NOMBRE.Text;
                        usu.APELLIDO = TXT_APELLIDO.Text;
                        usu.CORREO = TXT_CORREO.Text;
                        usu.CELULAR = TXT_CELULAR.Text;
                        usu.MUNICIPIO_RES.IDMUNICIPIO = DDL_MUNICIPIO.SelectedValue;
                        usu.DIRECCION = TXT_DIRECCION.Text;
                        usu.INSTITUCION = TXT_INSTITUCION.Text;
                        usu.FORMACION.IDFORMACION = DDL_FORMACION.SelectedValue;
                        usu.OCUPACION.IDOCUPACION = DDL_OCUPACION.SelectedValue;
                        usu.USERNAME = TXT_IDENTIFICACION.Text;
                        usu.PASS = TXT_IDENTIFICACION.Text;
                        usu.GENERO.IDGENERO = DDL_GENERO.Text;
                        usu.FECHA_NAC = DateTime.Parse(TXT_FECHA_NAC.Text);
                        usu.PAIS_NAC = DDL_PAIS_NAC.Text;
                        usu.CONDICION.IDESPECIAL = DDL_CONDICION.Text;
                        usu.CIRCUNSCRIPCION.IDCIRCUNSCRIPCION = DDL_CIRCUNS.Text;
                        usu.ROL.IDROL = "2";
                        if (new ParticipanteModel(EVEN.IDEVENTO, usu, DDL_PARTICIPACION.Text, "N").Registrar())
                        {
                            //Generar Codigo QR
                            this.getQRCode(usu.IDENTIFICACION);

                            //Registrar Cuestionario
                            foreach (Control item in Repeater1.Items)
                            {
                                TextBox txt = (TextBox)item.FindControl("TXT_RESPUESTA");
                                Label lab = (Label)item.FindControl("LB_PREGUNTA");
                                new CuestionarioModel().RegistrarRespuesta(lab.Text, txt.Text, usu.IDENTIFICACION);
                            }

                            //Enviar Correo
                            CorreoEvento CORREO = new CorreoEvento();
                            if (CORREO.EnviarCorreo(TXT_CORREO.Text, "ensayo", "exitoso", EVEN, usu))
                            {
                                new Tipo_EventoModel().Inscribir(usu.IDENTIFICACION, "1");
                                Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 7);
                            }
                            else
                            {
                                Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 3);
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 2);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 4);
                    }
                }
                else
                {
                    if (new Tipo_EventoModel().Consultar(usu.IDENTIFICACION, "1").Rows.Count == 0)
                    {
                        //Registrar Cuestionario
                        foreach (Control item in Repeater1.Items)
                        {
                            TextBox txt = (TextBox)item.FindControl("TXT_RESPUESTA");
                            Label lab = (Label)item.FindControl("LB_PREGUNTA");
                            new CuestionarioModel().RegistrarRespuesta(lab.Text, txt.Text, usu.IDENTIFICACION);
                        }

                        //Enviar Correo
                        CorreoEvento CORREO = new CorreoEvento();
                        if (CORREO.EnviarCorreo(usu.CORREO, "ensayo", "exitoso", EVEN, usu))
                        {
                            new Tipo_EventoModel().Inscribir(usu.IDENTIFICACION, "1");
                            Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 10);
                        }
                        else
                        {
                            Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 3);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Vistas/Publico/RegistrarView.aspx?Evento=" + EVEN.SIGLAS + "&alert=" + 11);
                    }
                }
            }
            else
            {
                Response.Redirect("~/Vistas/Publico/EventosView.aspx");
            }
        }


        protected void DDL_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_MUNICIPIO.DataSource = new MunicipioModel().ConsultarMunicipio(DDL_DEPARTAMENTO.Text);
            DDL_MUNICIPIO.DataTextField = "MUNI_NOMBRE";
            DDL_MUNICIPIO.DataValueField = "IDMUNICIPIO";
            DDL_MUNICIPIO.DataBind();
            DDL_PAIS.Items.Insert(0, new ListItem("Seleccionar Municipio", ""));
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


            string path = Server.MapPath("~/Imagen/Codigo/" + code + ".jpg");
            if (!File.Exists(path))
            {
                imagen.Save(path, ImageFormat.Jpeg);
            }
            byte[] result = imageToByteArray(imagen);
            return result;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        protected void DDL_PAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_DEPARTAMENTO.DataSource = new MunicipioModel().ConsultarDepartamento(DDL_PAIS.Text);
            DDL_DEPARTAMENTO.DataTextField = "MUNI_DEPARTAMENTO";
            DDL_DEPARTAMENTO.DataValueField = "MUNI_DEPARTAMENTO";
            DDL_DEPARTAMENTO.DataBind();
            DDL_PAIS.Items.Insert(0, new ListItem("Seleccionar Departamento", ""));
        }
    }
}
