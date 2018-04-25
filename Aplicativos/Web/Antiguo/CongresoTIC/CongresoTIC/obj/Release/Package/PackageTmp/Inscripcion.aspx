<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" Inherits="CongresoTIC.Inscripcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inscripción - Simposio Internacional</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="public/assets/images/fondo/Logo.jpg" rel="shortcut icon" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <link rel="stylesheet" href="public/assets/content/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="public/assets/content/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="public/assets/content/dist/css/skins/_all-skins.min.css" />


    <script type="text/javascript">

        function openInfo() {
            $('#info').modal()
        }
        function openRegister() {
            $('#register').modal()
        }

        function irQR() {
            var cedula = document.getElementById("t_ndocumento").value;
            location.href = "Views/Evento/Generar.aspx?current=" + cedula;
        }

    </script>
    <style>
        .qr {
            width: 50%;
            margin: auto;
        }
    </style>
</head>
<body style="background-color: rgb(247, 247, 247)">
    <form id="Form1" role="form" runat="server">

        <br />
        <div class="container">
            <div class="row">

                <div class="col-md-12 col-md-offset-0">
                    <div class="box box-success">

                        <div class="panel-body">
                            <fieldset>

                                <div class="box-header text-center">
                                    <div class="col-md-12">
                                        <h2 style="font-size: 25pt">
                                            <b>Simposio Internacional de Investigación 2017</b>
                                        </h2>
                                        <span class="badge bg-yellow" style="font-size: 12pt">Inscripción</span><br />
                                    </div>
                                    <%--<div class="col-md-2">
                                            <img style="height: 200px" src="public/assets/images/fondo/Logo.jpg " class="img-responsive" alt="" />
                                        </div>--%>
                                </div>

                                <hr />
                                <div class="box-body">
                                    <div class="col-md-4">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Tipo documento</label>
                                                <asp:DropDownList ID="t_tdocumento" runat="server" CssClass="form-control" title="No se ha seleccionado el tipo de documento" required>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group" style="">
                                                <label>Nro identificación</label>
                                                <asp:TextBox ID="t_ndocumento" runat="server" CssClass="form-control" MaxLength="12" pattern="[0-9]+" required></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group" style="">
                                                <label>Nombres</label>
                                                <asp:TextBox ID="t_nombres" runat="server" CssClass="form-control" MaxLength="60" type="text" pattern="[a-zñ A-ZÑ]*" title="No se aceptan números, tíldes o caracteres especiales" onkeyup="javascript:this.value=this.value.toUpperCase();" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group" style="">
                                                <label>Apellidos</label>
                                                <asp:TextBox ID="t_apellidos" runat="server" CssClass="form-control" MaxLength="60" type="text" pattern="[a-zñ A-ZÑ]*" title="No se aceptan números, tíldes o caracteres especiales" onkeyup="javascript:this.value=this.value.toUpperCase();" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="border-width: 0px 0px 0px 1px; border-color: green; border-style: dashed">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Departamento</label>
                                                <asp:DropDownList ID="t_dpto" runat="server" AutoPostBack="true" OnSelectedIndexChanged="t_dpto_SelectedIndexChanged" CssClass="form-control" title="No se ha seleccionado el tipo de documento" required>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Ciudad</label>
                                                <asp:DropDownList ID="t_mpio" runat="server" CssClass="form-control" title="No se ha seleccionado el tipo de documento" required>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group" style="">
                                                <label>Institución</label>
                                                <asp:TextBox ID="t_institución" runat="server" CssClass="form-control" type="text" onkeyup="javascript:this.value=this.value.toUpperCase();" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>¿Cuál es mi rol?</label>
                                                <asp:DropDownList ID="t_tipopers" runat="server" CssClass="form-control" title="No se ha seleccionado el tipo de documento" required>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="border-width: 0px 0px 0px 1px; border-color: green; border-style: dashed">

                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Tipo participante</label>
                                                <asp:DropDownList ID="t_tipopart" runat="server" CssClass="form-control" title="No se ha seleccionado el tipo de documento" required>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <label>Correo</label>
                                            <div class="form-group input-group">
                                                <span class="input-group-addon">@</span>
                                                <asp:TextBox ID="t_correo" TextMode="Email" CssClass="form-control" runat="server" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <label>Contraseña</label>
                                            <div class="form-group input-group">
                                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                                <asp:TextBox ID="t_password" TextMode="Password" CssClass="form-control" runat="server" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group" style="">
                                                <label>Observaciones</label>
                                                <asp:TextBox ID="t_observacion" TextMode="MultiLine" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 text-center">
                                        <br />
                                        <a href="Login.aspx" class="btn btn-primary" style="margin-right: 30px"><i class="fa fa-sign-in"></i>   Iniciar sesión</a>
                                        <asp:Button ID="Inscribir" runat="server" Text="Inscribirme en el Simposio" CssClass="btn btn-success" OnClick="Inscribir_Click" />
                                        <br />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="box-footer">
                            <div class="box bg-gray-light text-center">
                                <div class="inner">
                                    <div class="col-lg-8 col-md-offset-2">
                                        <div class="col-md-2">
                                            <a href="http://www.udla.edu.co/v10/" target="_blank">
                                                <img src="public/assets/images/fondo/UA.gif" title="Universidad de la Amazonia" style="width: 70px; margin-top: 15px;" class="img-responsive" alt="" />
                                            </a>
                                        </div>
                                        <div class="col-md-2">
                                            <img src="public/assets/images/fondo/congreso.png" title="Ingeniería de Sistemas" style="width: 60px; margin-top: 0px;" class="img-responsive" alt="" />
                                        </div>
                                        <div class="col-md-3">
                                            <a href="http://giecom.co/" target="_blank">
                                                <img src="public/assets/images/fondo/giecom.png" title="Grupo de Investigación GIECOM" style="width: 150px; margin-top: 6px;" class="img-responsive" alt="" />
                                            </a>
                                        </div>

                                        <div class="col-md-5">
                                            <br />
                                            <h4><b>Universidad de la Amazonia 2017</b></h4>
                                            <h5>Grupo de Investigación <a target="_blank" href="http://giecom.co/">GIECOM</a> - Ingeniería de Sistemas</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="row">

                <div id="info" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title"><b>Credenciales de acceso a la Plataforma</b></h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Debes informar al administrador.
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="register" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title"><b>Proceso de Inscripción al Simposio Internacional UDLA 2017</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="col-lg-12 text-center">
                                            <asp:Panel ID="Resultados" runat="server" Visible="false" CssClass="alert alert-danger">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <h3>
                                                    <asp:Label ID="LResultado" runat="server" Text=""></asp:Label></h3>
                                            </asp:Panel>
                                        </div>
                                        <hr />
                                        <div class="col-lg-12 text-center">
                                            <h3>
                                                <asp:Label ID="LResult" runat="server" Text=""></asp:Label>
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="col-md-6 text-center">

                                        <asp:Label runat="server" ID="DatosPersona"></asp:Label>
                                        <asp:Image ID="QRPersona" CssClass="img-responsive qr" runat="server" />
                                        <br />
                                    </div>

                                </div>
                            </div>
                            <div class="modal-footer">
                                <a href="#" class="btn btn-default" onclick="irQR()"><i class="fa fa-print"></i>    Imprimir</a>
                                <a href="Login.aspx" class="btn btn-primary"><i class="fa fa-sign-in"></i>  Iniciar sesión</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="public/assets/content/boot/bower_components/jquery/dist/jquery.min.js"></script>
        <script src="public/assets/content/boot/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="public/assets/content/boot/bower_components/metisMenu/dist/metisMenu.min.js"></script>
        <script src="public/assets/content/boot/dist/js/sb-admin-2.js"></script>
    </form>
</body>
</html>
