<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificado.aspx.cs" Inherits="CongresoTIC.Certificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificado Simposio</title>
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
                                <h2 style="padding: 10px"><b>CERTIFICADO DE ASISTENCIA - SIMPOSIO INTERNACIONAL DE INVESTIGACIÓN 2017</b></h2>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-offset-3">
                                    <asp:Panel ID="Resultados" runat="server" Visible="false" CssClass="alert alert-danger">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                        <asp:Label ID="LResultado" runat="server" Visible="true" Text=""></asp:Label>
                                    </asp:Panel>
                                    <div class="text-center">
                                        <asp:Button ID="BEncuesta" runat="server" Visible="false" CssClass="btn btn-default" Text="Diligenciar encuesta" OnClick="Button2_Click" />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group">
                                        <label>Digite su número de identificación</label>
                                        <asp:TextBox required="true" title="Se aceptan sólo números en este campo" ID="TFCedula" runat="server" CssClass="form-control" pattern="[0-9]+"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="Button1" runat="server" Text="Generar certificado" CssClass="btn btn-success btn-block" OnClick="Button1_Click" />
                                    </div>
                                </div>
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
