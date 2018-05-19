<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPrivateView.aspx.cs" Inherits="Eventos.Vistas.Publico.LoginPrivateView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--     Fonts and icons     -->
    <link href="../../Estilo/Public/assets/css/Iconos.css" rel="stylesheet" />
    <link href="../../Estilo/Public/assets/css/all.css" rel="stylesheet" />

    <!-- CSS Files -->
    <link href="../../Estilo/Public/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Estilo/Public/assets/css/now-ui-dashboard.min.css?v=1.0.1" rel="stylesheet" />
    <link href="../../Estilo/Public/assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../Estilo/Public/assets/css/stylish-portfolio.css" rel="stylesheet">
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="../../Estilo/assets/demo/demo.css" rel="stylesheet" />
</head>
<body onload="nobackbutton()" class="sidebar-mini">
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-transparent  navbar-absolute bg-primary fixed-top">
        <div class="container-fluid">

            <div class="collapse navbar-collapse justify-content-end" id="navigation">
                <ul class="navbar-nav">
                    <li class="nav-item  active ">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Vistas/Publico/LoginView.aspx" CssClass="nav-link" runat="server"><i class="fa fa-user"></i> Login</asp:HyperLink>
                    </li>
                    <li class="nav-item ">
                        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Vistas/Publico/EventosView.aspx" CssClass="nav-link" runat="server"><i class="fa fa-university"></i> Eventos</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- End Navbar -->

    <div class="wrapper wrapper-full-page">
        <div class=" full-page login-page section-image header">
            <!--   you can change the color of the filter page using: data-color="blue | purple | green | orange | red | rose " -->
            <div class="content">
                <div class="container">
                    <form id="form1" runat="server">
                        <div class="col-md-4 ml-auto mr-auto">
                            <div class="card card-login card-plain">
                                <div class="card-header ">
                                    <div class="logo-container">
                                        <img src="../../Imagen/LogoUA.png" height="80" alt="" />
                                    </div>
                                    <h4 class="control-label text_align-center text-center" style="text-align: center; vertical-align: central">Sistema de eventos</h4>
                                </div>

                                <div class="card-body ">
                                    <div class="input-group no-border form-control-lg">
                                        <span class="input-group-addon">
                                            <i class="fa fa-user"></i>
                                        </span>
                                        <asp:TextBox ID="TXTUSUARIO" placeholder="Usuario..." CssClass="form-control" required="required" MaxLength="50" ValidateRequestMode="Disabled" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="input-group no-border form-control-lg">
                                        <span class="input-group-addon">
                                            <i class="fa fa-unlock-alt"></i>
                                        </span>
                                        <asp:TextBox ID="TXTPASS" TextMode="Password" placeholder="Contraseña..." required="required" CssClass="form-control" MaxLength="20" ValidateRequestMode="Disabled" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="card-footer ">
                                    <asp:Button ID="BTN_INGRESAR" CssClass="btn btn-primary btn-round btn-lg btn-block mb-3" OnClick="BTN_INGRESAR_Click" runat="server" Text="Ingresar" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>

            <footer class="footer">
                <div class="container-fluid">
                    <div class="copyright">
                        &copy;
                        <script>document.write(new Date().getFullYear())</script>
                        , Desarrollado por el grupos Investigació <a href="http://giecom.co/" target="_blank">Giecom</a>.
                    </div>
                </div>
            </footer>
        </div>
    </div>

    <!-- small modal -->
    <div class="modal fade modal-mini modal-primary" id="Alerta" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header justify-content-center">
                    <div class="modal-profile">
                        <i class="now-ui-icons users_circle-08"></i>
                    </div>
                </div>
                <div class="modal-body">
                    <p>Always have an access to your profile</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link btn-neutral" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!--    end small modal -->
</body>
<!--   Core JS Files   -->
<script src="../../Estilo/Public/assets/js/core/jquery.min.js"></script>
<script src="../../Estilo/Public/assets/js/core/popper.min.js"></script>
<script src="../../Estilo/Public/assets/js/core/bootstrap.min.js"></script>
<script src="../../Estilo/Public/assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
<script src="../../Estilo/Public/assets/js/plugins/moment.min.js"></script>
<!--  Plugin for Switches, full documentation here: http://www.jque.re/plugins/version3/bootstrap.switch/ -->
<script src="../../Estilo/Public/assets/js/plugins/bootstrap-switch.js"></script>
<!--  Plugin for Sweet Alert -->
<script src="../../Estilo/Public/assets/js/plugins/sweetalert2.min.js"></script>
<!-- Forms Validations Plugin -->
<script src="../../Estilo/Public/assets/js/plugins/jquery.validate.min.js"></script>
<!--  Plugin for the Wizard, full documentation here: https://github.com/VinceG/twitter-bootstrap-wizard -->
<script src="../../Estilo/Public/assets/js/plugins/jquery.bootstrap-wizard.js"></script>
<!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
<script src="../../Estilo/Private/assets/js/plugins/bootstrap-selectpicker.js"></script>
<!--  Plugin for the DateTimePicker, full documentation here: https://eonasdan.github.io/bootstrap-datetimepicker/ -->
<script src="../../Estilo/Public/assets/js/plugins/bootstrap-datetimepicker.js"></script>
<!--  DataTables.net Plugin, full documentation here: https://datatables.net/    -->
<script src="../../Estilo/Public/assets/js/plugins/jquery.dataTables.min.js"></script>
<!--	Plugin for Tags, full documentation here: https://github.com/bootstrap-tagsinput/bootstrap-tagsinputs  -->
<script src="../../Estilo/Public/assets/js/plugins/bootstrap-tagsinput.js"></script>
<!-- Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
<script src="../../Estilo/Public/assets/js/plugins/jasny-bootstrap.min.js"></script>
<!--  Full Calendar Plugin, full documentation here: https://github.com/fullcalendar/fullcalendar    -->
<script src="../../Estilo/Public/assets/js/plugins/fullcalendar.min.js"></script>
<!-- Vector Map plugin, full documentation here: http://jvectormap.com/documentation/ -->
<script src="../../Estilo/Public/assets/js/plugins/jquery-jvectormap.js"></script>
<!--  Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
<script src="../../Estilo/Public/assets/js/plugins/nouislider.min.js"></script>
<!-- Place this tag in your head or just before your close body tag. -->
<script async defer src="../../Estilo/Public/assets/js/core/buttons.js"></script>
<!-- Chart JS -->
<script src="../../Estilo/Public/assets/js/plugins/chartjs.min.js"></script>
<!--  Notifications Plugin    -->
<script src="../../Estilo/Public/assets/js/plugins/bootstrap-notify.js"></script>
<!-- Control Center for Now Ui Dashboard: parallax effects, scripts for the example pages etc -->
<script src="../../Estilo/Public/assets/js/core/now-ui-dashboard.min.js?v=1.0.1"></script>
<!-- Now Ui Dashboard DEMO methods, don't include it in your project! -->
<script src="../../Estilo/Public/assets/demo/demo.js"></script>
<!-- Sharrre libray -->
<script src="../../Estilo/Public/assets/demo/jquery.sharrre.js"></script>
</html>
