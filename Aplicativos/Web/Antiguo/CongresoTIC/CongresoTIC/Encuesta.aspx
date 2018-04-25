<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="CongresoTIC.Encuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Encuesta Simposio</title>
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

</head>
<body style="background-color: rgb(247, 247, 247)">
    <form id="Form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-md-offset-0">
                    <div class="box box-widget widget-user">
                        <div class="bg-green">
                            <div class="text-center">
                                <h2 style="padding: 10px"><b>ENCUESTA - SIMPOSIO INTERNACIONAL DE INVESTIGACIÓN 2017</b></h2>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Panel ID="Resultados" runat="server" Visible="true" CssClass="alert alert-danger">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                        <asp:Label ID="LResultado" runat="server" Visible="true" Text=""></asp:Label>
                                    </asp:Panel>
                                </div>
                            </div>
                            <iframe id="panelencuesta" runat="server" src="https://docs.google.com/forms/d/e/1FAIpQLSdqJ6UJ1wbeLtg4uN3q58wZQY7HmJJ-17Y6-sgCa8YGfEQoGw/viewform" style="min-height: 600px; width: 100%;"></iframe>
                        </div>
                        <%--<div class="box-footer">
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
                                            <br />
                                            <h4><b>Universidad de la Amazonia 2017</b></h4>
                                            <h5>Grupo de Investigación <a target="_blank" href="http://giecom.co/">GIECOM</a>                                                    - Ingeniería de Sistemas</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
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

                            </div>


                        </div>
                        <div class="modal-footer">
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
