<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CongresoTIC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar sesión</title>
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

    <script src="public/angular/lib/angular.min.js"></script>
    <script src="public/angular/lib/angular-resource.min.js"></script>
    <script src="public/angular/controllers/app.js" charset="utf-8"></script>
    <script src="public/angular/controllers/controller_menu.js" charset="utf-8"></script>

    <script type="text/javascript">

        function openInfo() {
            document.getElementById("TUsuario").value = ".";
            document.getElementById("T_Password").value = ".";
            $('#info').modal()
        }
        function nobackbutton() {
            window.location.hash = "no-back-button";
            window.location.hash = "Again-No-back-button" //chrome
            window.onhashchange = function () { window.location.hash = "no-back-button"; }
        }
    </script>
</head>
<body style="background-color: rgb(247, 247, 247)" onload="nobackbutton();">
    <form id="Form1" role="form" runat="server">
        <br />
        <br />
        <div class="container">
            <div class="row">

                <asp:Label ID="Label1" Visible="false" runat="server" Text="Label"></asp:Label>
                <div class="col-md-12 col-md-offset-0">
                        <div class="box box-widget widget-user">
                            <br />
                            <div class="bg-green">
                                <div class="text-center">
                                    <br />
                                    <h2><b>SIMPOSIO INTERNACIONAL DE INVESTIGACIÓN 2017</b></h2>
                                    
                                    <h4>Estrategia de Desarrollo Académico y Social</h4>
                                    <br />
                                </div>
                            </div>
                            <div class="panel-body">

                                <br />
                                
                                <div class="col-md-4" style="border-width: 0px 1px 0px 0px; border-color: green; border-style: dashed">
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <asp:Panel ID="Resultados" runat="server" Visible="false" CssClass="alert alert-danger">
                                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                    <asp:Label ID="LResultado" runat="server" Visible="true" Text=""></asp:Label>
                                                </asp:Panel>
                                            </div>
                                        </div>

                                        <div class="box box-success">

                                            <div class="box-body">

                                                <br />
                                                <div class="form-group input-group">
                                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                                    <asp:TextBox ID="TUsuario" runat="server" placeholder="Correo" CssClass="form-control" title="Digite su nombre de usuario"
                                                        required></asp:TextBox>
                                                </div>
                                                <div class="form-group input-group">
                                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                                    <asp:TextBox ID="T_Password" CssClass="form-control" placeholder="Contraseña" runat="server" TextMode="Password" required></asp:TextBox>
                                                </div>
                                                <div class="form-group input-group">
                                                    <asp:CheckBox Visible="false" ID="Recordar" runat="server" Text="   Recordar contraseña" />
                                                </div>
                                                <asp:Button ID="Iniciar" runat="server" Text="Ingresar al sistema" CssClass="btn btn-success btn-block" OnClick="Iniciar_Click"
                                                />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-md-offset-0">
                                                        <div class="pull-left">
                                                            <a href="#" class="btn btn-block btn-default " onclick="openInfo()"><i class="fa fa-lock"></i> Recuperar contraseña</a>
                                                        </div>
                                                        <div class="pull-right">
                                                            <a href="Inscripcion.aspx" class="btn btn-block btn-default"><i class="fa fa-user-plus"></i> Registrarme</a>
                                                        </div>
                                                        <!--<div class="pull-right">
                                                        <a href="#" onclick="openInfo()" class="btn btn-block btn-default btn-xs">¿Olvidaste tu contraseña?</a>
                                                    </div>-->
                                                    </div>
                                                </div>
                                                <br />

                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="col-md-5 text-center">
                                    <br/><br/>
                                    <img src="public/assets/images/fondo/banner.jpg" class="img-responsive" alt="" />
                                </div>
                                <div class="col-md-3 text-center">
                                    <br/>
                                    <img src="public/assets/images/fondo/Logo.jpg" class="img-responsive" alt="" />
                                </div>
                                <div class="col-md-12 text-center">
                                    <br/>
                                    <br/>

                                    <a href="http://200.21.7.94/simposio/Files/CronogramaSimposio2017.pdf" target="_blank" class="btn btn-default">
                                    <i class="fa fa-file-pdf-o">
                                    
                                    </i>    Descargue aquí el cronograma del evento
                                </a>
                                <a href="http://200.21.7.94/simposio/Files/android-debug.apk" target="_blank" class="btn btn-default">
                                    <i class="fa fa-mobile">
                                    
                                    </i>    Descargar instalador de la aplicación móvil (apk)
                                </a>
                                    <a href="Certificado.aspx" target="_blank" class="btn btn-default">
                                    <i class="fa fa-file">
                                    
                                    </i>    Descargar Certificado de Asistencia
                                </a>
                                    <br/>
                                </div>
                            </div>
                            <div class="box-footer">
                                <div class="box bg-gray-light text-center">
                                    <div class="inner">

                                        <div class="col-lg-8 col-md-offset-2">
                                            <div class="col-md-2 col-xs-4">
                                                <a href="http://www.udla.edu.co/v10/" target="_blank">
                                                <img src="public/assets/images/fondo/UA.gif" title="Universidad de la Amazonia" style="width: 70px; margin-top: 15px;" class="img-responsive" alt="" />
                                            </a>
                                            </div>
                                            <div class="col-md-2 col-xs-4">
                                                <img src="public/assets/images/fondo/congreso.png" title="Ingeniería de Sistemas" style="width: 60px; margin-top: 0px;" class="img-responsive"
                                                    alt="" />
                                            </div>
                                            <div class="col-md-3 col-xs-4">
                                                <a href="http://giecom.co/" target="_blank">
                                                <img src="public/assets/images/fondo/giecom.png" title="Grupo de Investigación GIECOM" style="width: 150px; margin-top: 6px;" class="img-responsive" alt="" />
                                            </a>
                                            </div>

                                            <div class="col-md-5 col-xs-12">
                                                <br/>
                                                <h4><b>Universidad de la Amazonia 2017</b></h4>
                                                <h5>Grupo de Investigación <a target="_blank" href="http://giecom.co/">GIECOM</a>                                                    - Ingeniería de Sistemas</h5>
                                            </div>
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
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title"><b>Recuperar contraseña</b></h4>
                        </div>
                        <div class="modal-body text-center">
                            <div class="row">
                                <p>
                                    Digite el correo con el cual se registró en la plataforma
                                    <br />
                                    <br />
                                </p>
                                <div class="col-md-8 col-md-offset-2">
                                    <asp:TextBox ID="TCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Recuperar" runat="server" CssClass="btn btn-success" Text="Enviar" OnClick="Recuperar_Click" />
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
